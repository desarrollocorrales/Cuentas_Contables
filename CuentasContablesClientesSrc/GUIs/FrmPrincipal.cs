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
        int ultimoConteo;
        ConfiguracionMicrosip confMicrosip;
        ConfiguracionMysql confMysql;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblSucursal.Text = string.Empty;           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            probar();
            txbDescripcion.Text += "Tremesco" + Environment.NewLine;
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
            int iUltimoConteo = DAL.getUltimoConteo();
            return iUltimoConteo;
        }

        private void probar()
        {
            int i = getUltimoConteo();
            MessageBox.Show(i.ToString());
        }

        private void ActualizarDescripcion(string texto)
        {
            txbDescripcion.Paste(string.Format(texto));
            txbDescripcion.Paste(Environment.NewLine);
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
    }
}
