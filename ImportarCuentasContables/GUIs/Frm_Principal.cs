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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Actualizar?", "Validar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                //Actualizar
            }
        }

        private void Actualizar()
        {

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
            ConfiguracionMicrosip MicrosipConfig = DAL.getDatosMicrosip(cbSucursales.Text, cbTiposConexion.Text);
            FirebirdDAL FbDal = new FirebirdDAL(MicrosipConfig);
            if (FbDal.probarConexion())
            {
                MessageBox.Show("Conexión Exitosa.");
            }
        }


    }
}
