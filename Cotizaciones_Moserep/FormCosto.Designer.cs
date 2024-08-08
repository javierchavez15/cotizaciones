namespace Cotizaciones_Moserep
{
    partial class FormCosto
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
            this.lblcosto = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.lblTax = new System.Windows.Forms.Label();
            this.txtShipping = new System.Windows.Forms.TextBox();
            this.lblshipping = new System.Windows.Forms.Label();
            this.txtImportacion = new System.Windows.Forms.TextBox();
            this.lblimportacion = new System.Windows.Forms.Label();
            this.txtOtros = new System.Windows.Forms.TextBox();
            this.lblOtros = new System.Windows.Forms.Label();
            this.ckTax = new System.Windows.Forms.CheckBox();
            this.ckImportacion = new System.Windows.Forms.CheckBox();
            this.btnGuardarCotizacion = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblcosto
            // 
            this.lblcosto.AutoSize = true;
            this.lblcosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcosto.Location = new System.Drawing.Point(12, 24);
            this.lblcosto.Name = "lblcosto";
            this.lblcosto.Size = new System.Drawing.Size(86, 25);
            this.lblcosto.TabIndex = 120;
            this.lblcosto.Text = "COSTO";
            // 
            // txtCosto
            // 
            this.txtCosto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(258, 22);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(123, 27);
            this.txtCosto.TabIndex = 1;
            this.txtCosto.Text = "0.00";
            this.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCosto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCosto_KeyDown);
            // 
            // txtTax
            // 
            this.txtTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTax.Location = new System.Drawing.Point(258, 65);
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(123, 27);
            this.txtTax.TabIndex = 339;
            this.txtTax.Text = "0.00";
            this.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTax.Location = new System.Drawing.Point(12, 67);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(101, 25);
            this.lblTax.TabIndex = 338;
            this.lblTax.Text = "TAX  0.08";
            // 
            // txtShipping
            // 
            this.txtShipping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShipping.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShipping.Location = new System.Drawing.Point(258, 108);
            this.txtShipping.Name = "txtShipping";
            this.txtShipping.Size = new System.Drawing.Size(123, 27);
            this.txtShipping.TabIndex = 3;
            this.txtShipping.Text = "0.00";
            this.txtShipping.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtShipping.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShipping_KeyDown);
            // 
            // lblshipping
            // 
            this.lblshipping.AutoSize = true;
            this.lblshipping.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblshipping.Location = new System.Drawing.Point(12, 110);
            this.lblshipping.Name = "lblshipping";
            this.lblshipping.Size = new System.Drawing.Size(105, 25);
            this.lblshipping.TabIndex = 340;
            this.lblshipping.Text = "SHIPPING";
            // 
            // txtImportacion
            // 
            this.txtImportacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImportacion.Location = new System.Drawing.Point(258, 151);
            this.txtImportacion.Name = "txtImportacion";
            this.txtImportacion.ReadOnly = true;
            this.txtImportacion.Size = new System.Drawing.Size(123, 27);
            this.txtImportacion.TabIndex = 343;
            this.txtImportacion.Text = "0.00";
            this.txtImportacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblimportacion
            // 
            this.lblimportacion.AutoSize = true;
            this.lblimportacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblimportacion.Location = new System.Drawing.Point(12, 153);
            this.lblimportacion.Name = "lblimportacion";
            this.lblimportacion.Size = new System.Drawing.Size(196, 25);
            this.lblimportacion.TabIndex = 342;
            this.lblimportacion.Text = "IMPORTACION 0.08";
            // 
            // txtOtros
            // 
            this.txtOtros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtros.Location = new System.Drawing.Point(258, 196);
            this.txtOtros.Name = "txtOtros";
            this.txtOtros.Size = new System.Drawing.Size(123, 27);
            this.txtOtros.TabIndex = 5;
            this.txtOtros.Text = "0.00";
            this.txtOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOtros.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOtros_KeyDown);
            // 
            // lblOtros
            // 
            this.lblOtros.AutoSize = true;
            this.lblOtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtros.Location = new System.Drawing.Point(12, 198);
            this.lblOtros.Name = "lblOtros";
            this.lblOtros.Size = new System.Drawing.Size(177, 25);
            this.lblOtros.TabIndex = 344;
            this.lblOtros.Text = "OTROS COSTOS";
            // 
            // ckTax
            // 
            this.ckTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckTax.AutoSize = true;
            this.ckTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckTax.Location = new System.Drawing.Point(391, 72);
            this.ckTax.Name = "ckTax";
            this.ckTax.Size = new System.Drawing.Size(18, 17);
            this.ckTax.TabIndex = 2;
            this.ckTax.UseVisualStyleBackColor = true;
            this.ckTax.CheckedChanged += new System.EventHandler(this.ckTax_CheckedChanged);
            this.ckTax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ckTax_KeyDown);
            // 
            // ckImportacion
            // 
            this.ckImportacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckImportacion.AutoSize = true;
            this.ckImportacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckImportacion.Location = new System.Drawing.Point(391, 155);
            this.ckImportacion.Name = "ckImportacion";
            this.ckImportacion.Size = new System.Drawing.Size(18, 17);
            this.ckImportacion.TabIndex = 4;
            this.ckImportacion.UseVisualStyleBackColor = true;
            this.ckImportacion.CheckedChanged += new System.EventHandler(this.ckImportacion_CheckedChanged);
            this.ckImportacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ckImportacion_KeyDown);
            // 
            // btnGuardarCotizacion
            // 
            this.btnGuardarCotizacion.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGuardarCotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCotizacion.Location = new System.Drawing.Point(12, 328);
            this.btnGuardarCotizacion.Name = "btnGuardarCotizacion";
            this.btnGuardarCotizacion.Size = new System.Drawing.Size(151, 35);
            this.btnGuardarCotizacion.TabIndex = 7;
            this.btnGuardarCotizacion.Text = "GUARDAR";
            this.btnGuardarCotizacion.UseVisualStyleBackColor = false;
            this.btnGuardarCotizacion.Click += new System.EventHandler(this.btnGuardarCotizacion_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(258, 240);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(123, 27);
            this.txtTotal.TabIndex = 352;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(12, 242);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(79, 25);
            this.lblTotal.TabIndex = 351;
            this.lblTotal.Text = "TOTAL";
            // 
            // txtNota
            // 
            this.txtNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNota.Location = new System.Drawing.Point(116, 284);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(293, 27);
            this.txtNota.TabIndex = 6;
            this.txtNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNota.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNota_KeyDown);
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNota.Location = new System.Drawing.Point(12, 286);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(83, 25);
            this.lblNota.TabIndex = 353;
            this.lblNota.Text = "NOTAS";
            // 
            // FormCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 378);
            this.Controls.Add(this.txtNota);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnGuardarCotizacion);
            this.Controls.Add(this.ckImportacion);
            this.Controls.Add(this.ckTax);
            this.Controls.Add(this.txtOtros);
            this.Controls.Add(this.lblOtros);
            this.Controls.Add(this.txtImportacion);
            this.Controls.Add(this.lblimportacion);
            this.Controls.Add(this.txtShipping);
            this.Controls.Add(this.lblshipping);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.lblcosto);
            this.MaximumSize = new System.Drawing.Size(435, 425);
            this.Name = "FormCosto";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "COSTO";
            this.Load += new System.EventHandler(this.FormCosto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblcosto;
        public System.Windows.Forms.TextBox txtCosto;
        public System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.Label lblTax;
        public System.Windows.Forms.TextBox txtShipping;
        private System.Windows.Forms.Label lblshipping;
        public System.Windows.Forms.TextBox txtImportacion;
        private System.Windows.Forms.Label lblimportacion;
        public System.Windows.Forms.TextBox txtOtros;
        private System.Windows.Forms.Label lblOtros;
        public System.Windows.Forms.CheckBox ckTax;
        public System.Windows.Forms.CheckBox ckImportacion;
        private System.Windows.Forms.Button btnGuardarCotizacion;
        public System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Label lblNota;
    }
}