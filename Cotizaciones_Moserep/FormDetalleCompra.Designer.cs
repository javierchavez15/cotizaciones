namespace Cotizaciones_Moserep
{
    partial class FormDetalleCompra
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
            this.btnALtaContacto = new System.Windows.Forms.Button();
            this.btnALtaClinte = new System.Windows.Forms.Button();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.cbContacto = new System.Windows.Forms.ComboBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblUrl1 = new System.Windows.Forms.Label();
            this.txtUrl1 = new System.Windows.Forms.TextBox();
            this.lblUrl2 = new System.Windows.Forms.Label();
            this.txtUrl2 = new System.Windows.Forms.TextBox();
            this.lblCotizacion = new System.Windows.Forms.Label();
            this.txtCotizacion = new System.Windows.Forms.TextBox();
            this.lblNotas = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnALtaContacto
            // 
            this.btnALtaContacto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnALtaContacto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnALtaContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnALtaContacto.Location = new System.Drawing.Point(573, 66);
            this.btnALtaContacto.Name = "btnALtaContacto";
            this.btnALtaContacto.Size = new System.Drawing.Size(79, 34);
            this.btnALtaContacto.TabIndex = 153;
            this.btnALtaContacto.Text = "ALTA";
            this.btnALtaContacto.UseVisualStyleBackColor = true;
            this.btnALtaContacto.Click += new System.EventHandler(this.btnALtaContacto_Click);
            // 
            // btnALtaClinte
            // 
            this.btnALtaClinte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnALtaClinte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnALtaClinte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnALtaClinte.Location = new System.Drawing.Point(573, 20);
            this.btnALtaClinte.Name = "btnALtaClinte";
            this.btnALtaClinte.Size = new System.Drawing.Size(79, 34);
            this.btnALtaClinte.TabIndex = 152;
            this.btnALtaClinte.Text = "ALTA";
            this.btnALtaClinte.UseVisualStyleBackColor = true;
            this.btnALtaClinte.Click += new System.EventHandler(this.btnALtaClinte_Click);
            // 
            // cbProveedor
            // 
            this.cbProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(172, 22);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(378, 30);
            this.cbProveedor.TabIndex = 1;
            this.cbProveedor.SelectedIndexChanged += new System.EventHandler(this.cbProveedor_SelectedIndexChanged);
            // 
            // cbContacto
            // 
            this.cbContacto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbContacto.DisplayMember = "Contacto";
            this.cbContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContacto.FormattingEnabled = true;
            this.cbContacto.Location = new System.Drawing.Point(172, 66);
            this.cbContacto.Name = "cbContacto";
            this.cbContacto.Size = new System.Drawing.Size(378, 30);
            this.cbContacto.TabIndex = 2;
            this.cbContacto.ValueMember = "Contacto";
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContacto.Location = new System.Drawing.Point(8, 69);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(128, 25);
            this.lblContacto.TabIndex = 149;
            this.lblContacto.Text = "CONTACTO";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(8, 27);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(137, 25);
            this.lblProveedor.TabIndex = 148;
            this.lblProveedor.Text = "PROVEEDOR";
            // 
            // lblUrl1
            // 
            this.lblUrl1.AutoSize = true;
            this.lblUrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUrl1.Location = new System.Drawing.Point(12, 112);
            this.lblUrl1.Name = "lblUrl1";
            this.lblUrl1.Size = new System.Drawing.Size(66, 25);
            this.lblUrl1.TabIndex = 333;
            this.lblUrl1.Text = "URL 1";
            // 
            // txtUrl1
            // 
            this.txtUrl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl1.Location = new System.Drawing.Point(172, 113);
            this.txtUrl1.Name = "txtUrl1";
            this.txtUrl1.Size = new System.Drawing.Size(480, 27);
            this.txtUrl1.TabIndex = 3;
            // 
            // lblUrl2
            // 
            this.lblUrl2.AutoSize = true;
            this.lblUrl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUrl2.Location = new System.Drawing.Point(12, 154);
            this.lblUrl2.Name = "lblUrl2";
            this.lblUrl2.Size = new System.Drawing.Size(66, 25);
            this.lblUrl2.TabIndex = 335;
            this.lblUrl2.Text = "URL 2";
            // 
            // txtUrl2
            // 
            this.txtUrl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl2.Location = new System.Drawing.Point(172, 155);
            this.txtUrl2.Name = "txtUrl2";
            this.txtUrl2.Size = new System.Drawing.Size(480, 27);
            this.txtUrl2.TabIndex = 4;
            // 
            // lblCotizacion
            // 
            this.lblCotizacion.AutoSize = true;
            this.lblCotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCotizacion.Location = new System.Drawing.Point(12, 199);
            this.lblCotizacion.Name = "lblCotizacion";
            this.lblCotizacion.Size = new System.Drawing.Size(137, 25);
            this.lblCotizacion.TabIndex = 343;
            this.lblCotizacion.Text = "COTIZACION";
            // 
            // txtCotizacion
            // 
            this.txtCotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCotizacion.Location = new System.Drawing.Point(172, 200);
            this.txtCotizacion.Name = "txtCotizacion";
            this.txtCotizacion.Size = new System.Drawing.Size(135, 27);
            this.txtCotizacion.TabIndex = 5;
            // 
            // lblNotas
            // 
            this.lblNotas.AutoSize = true;
            this.lblNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotas.Location = new System.Drawing.Point(12, 241);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(83, 25);
            this.lblNotas.TabIndex = 345;
            this.lblNotas.Text = "NOTAS";
            // 
            // txtNotas
            // 
            this.txtNotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotas.Location = new System.Drawing.Point(172, 242);
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(480, 27);
            this.txtNotas.TabIndex = 6;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGuardar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(12, 331);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(146, 35);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 346;
            this.label1.Text = "FECHA";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(172, 285);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(321, 28);
            this.dtpFecha.TabIndex = 7;
            // 
            // FormDetalleCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 378);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblNotas);
            this.Controls.Add(this.txtNotas);
            this.Controls.Add(this.lblCotizacion);
            this.Controls.Add(this.txtCotizacion);
            this.Controls.Add(this.lblUrl2);
            this.Controls.Add(this.txtUrl2);
            this.Controls.Add(this.lblUrl1);
            this.Controls.Add(this.txtUrl1);
            this.Controls.Add(this.btnALtaContacto);
            this.Controls.Add(this.btnALtaClinte);
            this.Controls.Add(this.cbProveedor);
            this.Controls.Add(this.cbContacto);
            this.Controls.Add(this.lblContacto);
            this.Controls.Add(this.lblProveedor);
            this.Name = "FormDetalleCompra";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DETALLE DE COMPRA";
            this.Load += new System.EventHandler(this.FormDetalleCompra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnALtaContacto;
        private System.Windows.Forms.Button btnALtaClinte;
        public System.Windows.Forms.ComboBox cbProveedor;
        public System.Windows.Forms.ComboBox cbContacto;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblUrl1;
        public System.Windows.Forms.TextBox txtUrl1;
        private System.Windows.Forms.Label lblUrl2;
        public System.Windows.Forms.TextBox txtUrl2;
        private System.Windows.Forms.Label lblCotizacion;
        public System.Windows.Forms.TextBox txtCotizacion;
        private System.Windows.Forms.Label lblNotas;
        public System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dtpFecha;
    }
}