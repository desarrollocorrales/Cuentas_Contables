using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CuentasContablesClientesSrc.clases;

namespace CuentasContablesClientesSrc.GUIs
{
    public partial class FrmPrincipal : Form
    {
        bool cancelar;
        ConfiguracionMicrosip confMicrosip;
        ConfiguracionMysql confMysql;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblSucursal.Text = string.Empty;
            cancelar = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Validar
            DialogResult dr = MessageBox.Show("¡Actualizar?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                progressBar1.Visible = true;
                Actualizar();
                txbDescripcion.Enabled = true;
                txbDescripcion.ReadOnly = true;
            }

            ActualizarDescripcion("Proceso Terminado");
        }

        private void Actualizar()
        {
            int iConsecutivo=0;
            try
            {
                MysqlDAL mysql_dal = new MysqlDAL(confMysql, confMicrosip);
                FirebirdDAL firebird_dal = new FirebirdDAL(confMysql, confMicrosip);

                //Actualizar
                //Obtener clientes sin cuenta contable.
                List<Cliente> lstClientesSinCuentaCo = getClientesSinCuenta();
                progressBar1.Maximum = lstClientesSinCuentaCo.Count;
                progressBar1.Minimum = 0;
                progressBar1.Value = 0;

                //Obtener consecutivo
                iConsecutivo = getUltimoConteo();

                //Obtener datos de sucursal
                Conteo conteo = mysql_dal.getDatosSucursal();
                bool ValidaCliente;
                foreach (Cliente cliente in lstClientesSinCuentaCo)
                {
                    if (cancelar == true)
                        break;

                    //Validar si activo
                    ValidaCliente = firebird_dal.TieneMovimientos(cliente);
                    ValidaCliente = true;
                    if (ValidaCliente == true)
                    {
                        //insertar cliente
                        cliente.iConsecutivo = iConsecutivo;
                        cliente.Cuenta_CO = conteo.CuentaPadre + iConsecutivo.ToString();
                        mysql_dal.InsertCliente(cliente);

                        //actualizar microsip                    
                        //firebird_dal.InsertarCuentaContable(cliente);
                        firebird_dal.ActualizarCliente(cliente);

                        //actualizar consecutivo
                        iConsecutivo++;
                        mysql_dal.UpdateConsecutivo(iConsecutivo);

                        ActualizarDescripcion(
                            string.Format("Actualizado cliente '{0}' numero de cuenta '{1}', consecutivo '{2}'",
                                           cliente.Nombre, cliente.Cuenta_CO, cliente.iConsecutivo));

                        progressBar1.Value++;
                        progressBar1.Refresh();
                        Application.DoEvents();
                    }
                    else
                    {
                        //Cliente inactivo     
                        //firebird_dal.CambiarEstadoCliente(cliente);

                        //ActualizarDescripcion(
                          //  string.Format("cliente '{0}' sin movimientos, se cambia a estado Inactivo", cliente.Nombre));

                        progressBar1.Value++;
                        progressBar1.Refresh();
                        Application.DoEvents();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            txbConteo.Text = iConsecutivo.ToString();
        }

        private void CargarConfiguracionMicrosip()
        {
            confMicrosip = new ConfiguracionMicrosip();
            if (confMicrosip.LoadConfiguration() == true)
            {
                lblSucursal.Text = confMicrosip.empresa;
                ActualizarDescripcion(string.Format("La configuracion para la empresa '{0}' se ha cargado correctamente.", confMicrosip.empresa));
            }
            else
            {
                MessageBox.Show(confMicrosip.errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void CargarConfiguracionMysql()
        {
            confMysql = new ConfiguracionMysql();
            if (confMysql.LoadConfiguration() == true)
            {
                ActualizarDescripcion(string.Format("La configuración a la base de datos {0} se ha cargado correctamente..", confMicrosip.MysqlDatabase));
            }
            else
            {
                MessageBox.Show(confMysql.errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private int getUltimoConteo()
        {
            MysqlDAL DAL = new MysqlDAL(confMysql, confMicrosip);
            return DAL.getUltimoConteo();;
        }

        private List<Cliente> getClientesSinCuenta()
        {
            FirebirdDAL DAL = new FirebirdDAL(confMysql, confMicrosip);
            return DAL.getClientesSinCuentaCo(); ;
        }

        private void probar()
        {
            int i = getUltimoConteo();
            MessageBox.Show(i.ToString());
        }

        private void ActualizarDescripcion(string texto)
        {
            try
            {
                txbDescripcion.Paste(string.Format(texto));
                txbDescripcion.Paste(Environment.NewLine);
            }
            catch
            {
                Application.Exit();
            }
        }

        private void FrmPrincipal_Shown(object sender, EventArgs e)
        {
            CargarConfiguracionMicrosip();
            CargarConfiguracionMysql();
            CargarUltimoConteo();
        }

        private void CargarUltimoConteo()
        {
            txbConteo.Text = getUltimoConteo().ToString();
            ActualizarDescripcion("El último conteo para cuenta es: " + txbConteo.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar = true;
            this.Close();
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            cancelar = true;
        }
    }
}
