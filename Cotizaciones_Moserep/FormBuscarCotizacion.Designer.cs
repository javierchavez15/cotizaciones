namespace Cotizaciones_Moserep
{
    partial class FormBuscarCotizacion
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
            this.dtgItems = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblContacto = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnGuardarCotizacion = new System.Windows.Forms.Button();
            this.btnCopiarPoducto = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoPrecotizacion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgItems
            // 
            this.dtgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgItems.Location = new System.Drawing.Point(1, 155);
            this.dtgItems.Margin = new System.Windows.Forms.Padding(4);
            this.dtgItems.Name = "dtgItems";
            this.dtgItems.ReadOnly = true;
            this.dtgItems.RowHeadersWidth = 5;
            this.dtgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgItems.Size = new System.Drawing.Size(687, 246);
            this.dtgItems.TabIndex = 1;
            this.dtgItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgItems_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 138;
            this.label3.Text = "CLIENTE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 139;
            this.label1.Text = "CONTACTO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 140;
            this.label2.Text = "SUBTOTAL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 25);
            this.label4.TabIndex = 141;
            this.label4.Text = "FECHA:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCliente.Location = new System.Drawing.Point(153, 9);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(102, 25);
            this.lblCliente.TabIndex = 142;
            this.lblCliente.Text = "CLIENTE:";
            this.lblCliente.Visible = false;
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContacto.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblContacto.Location = new System.Drawing.Point(153, 45);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(128, 25);
            this.lblContacto.TabIndex = 143;
            this.lblContacto.Text = "CONTACTO";
            this.lblContacto.Visible = false;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSubtotal.Location = new System.Drawing.Point(153, 79);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(120, 25);
            this.lblSubtotal.TabIndex = 144;
            this.lblSubtotal.Text = "SUBTOTAL";
            this.lblSubtotal.Visible = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFecha.Location = new System.Drawing.Point(153, 113);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(80, 25);
            this.lblFecha.TabIndex = 145;
            this.lblFecha.Text = "FECHA";
            this.lblFecha.Visible = false;
            // 
            // btnGuardarCotizacion
            // 
            this.btnGuardarCotizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarCotizacion.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGuardarCotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCotizacion.Location = new System.Drawing.Point(423, 108);
            this.btnGuardarCotizacion.Name = "btnGuardarCotizacion";
            this.btnGuardarCotizacion.Size = new System.Drawing.Size(264, 35);
            this.btnGuardarCotizacion.TabIndex = 164;
            this.btnGuardarCotizacion.Text = "COPIAR COTIZACION";
            this.btnGuardarCotizacion.UseVisualStyleBackColor = false;
            this.btnGuardarCotizacion.Visible = false;
            this.btnGuardarCotizacion.Click += new System.EventHandler(this.btnGuardarCotizacion_Click);
            // 
            // btnCopiarPoducto
            // 
            this.btnCopiarPoducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopiarPoducto.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCopiarPoducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiarPoducto.Location = new System.Drawing.Point(424, 108);
            this.btnCopiarPoducto.Name = "btnCopiarPoducto";
            this.btnCopiarPoducto.Size = new System.Drawing.Size(264, 35);
            this.btnCopiarPoducto.TabIndex = 165;
            this.btnCopiarPoducto.Text = "COPIAR PRODUCTO";
            this.btnCopiarPoducto.UseVisualStyleBackColor = false;
            this.btnCopiarPoducto.Visible = false;
            this.btnCopiarPoducto.Click += new System.EventHandler(this.btnCopiarPoducto_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(474, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 25);
            this.label5.TabIndex = 166;
            this.label5.Text = "FOLIO";
            // 
            // txtNoPrecotizacion
            // 
            this.txtNoPrecotizacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoPrecotizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoPrecotizacion.Location = new System.Drawing.Point(552, 42);
            this.txtNoPrecotizacion.Name = "txtNoPrecotizacion";
            this.txtNoPrecotizacion.ReadOnly = true;
            this.txtNoPrecotizacion.Size = new System.Drawing.Size(136, 30);
            this.txtNoPrecotizacion.TabIndex = 167;
            this.txtNoPrecotizacion.Text = "0";
            this.txtNoPrecotizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FormBuscarCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 401);
            this.Controls.Add(this.txtNoPrecotizacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCopiarPoducto);
            this.Controls.Add(this.btnGuardarCotizacion);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblContacto);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtgItems);
            this.Name = "FormBuscarCotizacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FormBuscarCotizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dtgItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnGuardarCotizacion;
        private System.Windows.Forms.Button btnCopiarPoducto;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtNoPrecotizacion;
    }
}