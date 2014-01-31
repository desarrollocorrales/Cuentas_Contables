namespace ImportarCuentasContables.GUIs
{
    partial class Frm_Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSucursales = new System.Windows.Forms.ComboBox();
            this.btnImportar = new System.Windows.Forms.Button();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.cbTiposConexion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCargarConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar la Sucursal:";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(784, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Importar cuentas contables para clientes";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbSucursales
            // 
            this.cbSucursales.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbSucursales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSucursales.FormattingEnabled = true;
            this.cbSucursales.Location = new System.Drawing.Point(354, 33);
            this.cbSucursales.Name = "cbSucursales";
            this.cbSucursales.Size = new System.Drawing.Size(228, 24);
            this.cbSucursales.TabIndex = 2;
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImportar.Enabled = false;
            this.btnImportar.Location = new System.Drawing.Point(342, 487);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(100, 30);
            this.btnImportar.TabIndex = 3;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDescripcion.Location = new System.Drawing.Point(12, 129);
            this.txbDescripcion.Multiline = true;
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(760, 352);
            this.txbDescripcion.TabIndex = 4;
            // 
            // cbTiposConexion
            // 
            this.cbTiposConexion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbTiposConexion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTiposConexion.FormattingEnabled = true;
            this.cbTiposConexion.Location = new System.Drawing.Point(354, 63);
            this.cbTiposConexion.Name = "cbTiposConexion";
            this.cbTiposConexion.Size = new System.Drawing.Size(228, 24);
            this.cbTiposConexion.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de conexion:";
            // 
            // btnCargarConfig
            // 
            this.btnCargarConfig.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCargarConfig.Location = new System.Drawing.Point(305, 93);
            this.btnCargarConfig.Name = "btnCargarConfig";
            this.btnCargarConfig.Size = new System.Drawing.Size(175, 30);
            this.btnCargarConfig.TabIndex = 7;
            this.btnCargarConfig.Text = "Cargar configuraciones";
            this.btnCargarConfig.UseVisualStyleBackColor = true;
            this.btnCargarConfig.Click += new System.EventHandler(this.btnCargarConfig_Click);
            // 
            // Frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 529);
            this.Controls.Add(this.btnCargarConfig);
            this.Controls.Add(this.cbTiposConexion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbDescripcion);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.cbSucursales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_Principal";
            this.Text = "Importar Clientes";
            this.Shown += new System.EventHandler(this.Frm_Principal_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSucursales;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.ComboBox cbTiposConexion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCargarConfig;
    }
}