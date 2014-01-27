﻿namespace CuentasContablesClientesSrc.GUIs
{
    partial class FrmPrincipal
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
            this.txbIdCuentaPadre = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbConteo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Cuenta Padre:";
            // 
            // txbIdCuentaPadre
            // 
            this.txbIdCuentaPadre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbIdCuentaPadre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbIdCuentaPadre.Location = new System.Drawing.Point(281, 63);
            this.txbIdCuentaPadre.Name = "txbIdCuentaPadre";
            this.txbIdCuentaPadre.Size = new System.Drawing.Size(284, 23);
            this.txbIdCuentaPadre.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(734, 30);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Actualización de cuentas contables para clientes en Microsip";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sucursal:";
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDescripcion.BackColor = System.Drawing.Color.White;
            this.txbDescripcion.Enabled = false;
            this.txbDescripcion.ForeColor = System.Drawing.Color.Black;
            this.txbDescripcion.Location = new System.Drawing.Point(12, 121);
            this.txbDescripcion.Multiline = true;
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(710, 345);
            this.txbDescripcion.TabIndex = 5;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(566, 472);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 28);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(647, 472);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 28);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblSucursal
            // 
            this.lblSucursal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSucursal.Location = new System.Drawing.Point(280, 36);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(77, 16);
            this.lblSucursal.TabIndex = 8;
            this.lblSucursal.Text = "lblSucursal";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Conteo de la ultima cuenta:";
            // 
            // txbConteo
            // 
            this.txbConteo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txbConteo.BackColor = System.Drawing.Color.White;
            this.txbConteo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbConteo.Enabled = false;
            this.txbConteo.ForeColor = System.Drawing.Color.Black;
            this.txbConteo.Location = new System.Drawing.Point(281, 92);
            this.txbConteo.Name = "txbConteo";
            this.txbConteo.Size = new System.Drawing.Size(146, 23);
            this.txbConteo.TabIndex = 10;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 512);
            this.Controls.Add(this.txbConteo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txbDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txbIdCuentaPadre);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmPrincipal";
            this.Text = "Actualizacion de cuentas contables";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.Shown += new System.EventHandler(this.FrmPrincipal_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbIdCuentaPadre;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbConteo;
    }
}