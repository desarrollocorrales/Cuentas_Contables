using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImportarCuentasContables.clases;

namespace ImportarCuentasContables.GUIs
{
    public partial class Frm_Principal : Form
    {
        bool cancelar;
        ConfiguracionMicrosip confMicrosip;
        ConfiguracionMysql confMysql;

        public Frm_Principal()
        {
            InitializeComponent();

            txbDescripcion.ScrollBars = ScrollBars.Both;
            cancelar = false;
        }

        private void Importar()
        {
            if (confMicrosip != null)
            {
                FirebirdDAL FB_DAL = new FirebirdDAL(confMicrosip);
                MysqlDAL MYSQL_DAL = new MysqlDAL(confMysql);
                try
                {
                    string sucursal = confMicrosip.empresa;
                    int idMicroCuentaPadre = confMicrosip.idMicroCuentaPadre;

                    //Obtener clientes sin importar
                    List<Cliente> lstClientes = MYSQL_DAL.getClientesNoImportados(sucursal);
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = lstClientes.Count;
                    progressBar1.Value = 0;

                    foreach (Cliente cliente in lstClientes)
                    {
                        if (cancelar == true)
                            break;

                        //Insertar a Microsip
                        FB_DAL.ImportarCuentaContable(confMicrosip.idMicroCuentaPadre, cliente);

                        //Cambiar Status en Mysql
                        MYSQL_DAL.CambiarStatusCorrecto(sucursal, cliente.ID_Microsip);

                        //Actualizar txbDescripcion
                        StringBuilder sbMensaje = new StringBuilder();
                        sbMensaje.Append("Se ha insertado el CLIENTE: " + cliente.Nombre);
                        sbMensaje.Append(" con numero de SUBCUENTA: " + cliente.iConsecutivo);
                        sbMensaje.Append(" y IDCUENTAPADRE: " + idMicroCuentaPadre);
                       
                        ActualizarDescripcion(sbMensaje.ToString());
                        progressBar1.Value++;
                        progressBar1.Refresh();
                        Application.DoEvents();
                    }

                    if (cancelar != true)
                    {
                        progressBar1.Value = progressBar1.Maximum;
                        ActualizarDescripcion("El proceso ha terminado correctamente");
                        MessageBox.Show("El proceso ha terminado correctamente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Frm_Principal_Shown(object sender, EventArgs e)
        {
            CargarConfiguracionMysql();
            llenarComboSucursales();
            llenarComboTiposConexion();
        }

        private void CargarConfiguracionMysql()
        {
            confMysql = new ConfiguracionMysql();
            if (confMysql.LoadConfiguration() == true)
            {
                ActualizarDescripcion(string.Format("La configuración a la base de datos {0} se ha cargado correctamente..", confMysql.database));
            }
            else
            {
                MessageBox.Show(confMysql.errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void llenarComboSucursales()
        {
            MysqlDAL DAL = new MysqlDAL(confMysql);
            List<Conteo> lstConteo = DAL.getConteos();
            cbSucursales.DataSource = lstConteo;
            cbSucursales.DisplayMember = "Sucursal";
            cbSucursales.ValueMember = "IdConteo";
            cbSucursales.Refresh();
        }

        private void llenarComboTiposConexion()
        {
            MysqlDAL DAL = new MysqlDAL(confMysql);
            List<string> lstTipos = DAL.getTiposConexion();

            cbTiposConexion.DataSource = lstTipos;
            cbTiposConexion.DisplayMember = "tipo";
            cbTiposConexion.Refresh();
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

        private void btnCargarConfig_Click(object sender, EventArgs e)
        {
            MysqlDAL DAL = new MysqlDAL(confMysql);
            confMicrosip = DAL.getDatosMicrosip(cbSucursales.Text, cbTiposConexion.Text);
            FirebirdDAL FbDal = new FirebirdDAL(confMicrosip);

            try
            {
                if (FbDal.probarConexion())
                {
                    MessageBox.Show("Conexión Exitosa.");
                    btnImportar.Enabled = true;
                }
                else
                {
                    btnImportar.Enabled = false;
                    confMicrosip = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Actualizar?", "Validar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Importar();
            }
        }

        private void Frm_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancelar = true;
        }
    }
}
