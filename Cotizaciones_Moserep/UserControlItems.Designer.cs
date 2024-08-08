namespace Cotizaciones_Moserep
{
    partial class UserControlItems
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnProveedor = new System.Windows.Forms.Button();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.cbMone = new System.Windows.Forms.ComboBox();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.txtCatalogo = new System.Windows.Forms.TextBox();
            this.txtTotalItem = new System.Windows.Forms.TextBox();
            this.txtPrecioU = new System.Windows.Forms.TextBox();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.txtCostoU = new System.Windows.Forms.TextBox();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(280, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 25);
            this.button1.TabIndex = 137;
            this.button1.Text = "Img";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.Enter += new System.EventHandler(this.button1_Enter);
            // 
            // btnProveedor
            // 
            this.btnProveedor.BackColor = System.Drawing.SystemColors.Control;
            this.btnProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedor.Location = new System.Drawing.Point(799, 2);
            this.btnProveedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Size = new System.Drawing.Size(76, 27);
            this.btnProveedor.TabIndex = 142;
            this.btnProveedor.Text = "Detalles";
            this.btnProveedor.UseVisualStyleBackColor = false;
            this.btnProveedor.Click += new System.EventHandler(this.btnProveedor_Click);
            this.btnProveedor.Enter += new System.EventHandler(this.btnProveedor_Enter);
            // 
            // txtItem
            // 
            this.txtItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItem.Location = new System.Drawing.Point(2, 5);
            this.txtItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtItem.Name = "txtItem";
            this.txtItem.ReadOnly = true;
            this.txtItem.Size = new System.Drawing.Size(34, 24);
            this.txtItem.TabIndex = 134;
            this.txtItem.Text = "1";
            this.txtItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtItem.Enter += new System.EventHandler(this.txtItem_Enter);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(310, 5);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(264, 26);
            this.txtDescripcion.TabIndex = 138;
            this.txtDescripcion.Text = "";
            this.txtDescripcion.Enter += new System.EventHandler(this.txtDescripcion_Enter);
            // 
            // cbMone
            // 
            this.cbMone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMone.FormattingEnabled = true;
            this.cbMone.Items.AddRange(new object[] {
            "MXN",
            "USD"});
            this.cbMone.Location = new System.Drawing.Point(727, 2);
            this.cbMone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbMone.Name = "cbMone";
            this.cbMone.Size = new System.Drawing.Size(62, 28);
            this.cbMone.TabIndex = 141;
            this.cbMone.SelectedIndexChanged += new System.EventHandler(this.cbMone_SelectedIndexChanged);
            this.cbMone.Enter += new System.EventHandler(this.cbMone_Enter);
            // 
            // txtAlias
            // 
            this.txtAlias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlias.Location = new System.Drawing.Point(164, 4);
            this.txtAlias.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(107, 26);
            this.txtAlias.TabIndex = 136;
            this.txtAlias.Enter += new System.EventHandler(this.txtAlias_Enter);
            // 
            // txtCatalogo
            // 
            this.txtCatalogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCatalogo.Location = new System.Drawing.Point(48, 4);
            this.txtCatalogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCatalogo.Name = "txtCatalogo";
            this.txtCatalogo.Size = new System.Drawing.Size(105, 26);
            this.txtCatalogo.TabIndex = 135;
            this.txtCatalogo.Enter += new System.EventHandler(this.txtCatalogo_Enter);
            this.txtCatalogo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCatalogo_KeyDown);
            // 
            // txtTotalItem
            // 
            this.txtTotalItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalItem.Location = new System.Drawing.Point(1006, 3);
            this.txtTotalItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTotalItem.Name = "txtTotalItem";
            this.txtTotalItem.ReadOnly = true;
            this.txtTotalItem.Size = new System.Drawing.Size(66, 26);
            this.txtTotalItem.TabIndex = 145;
            this.txtTotalItem.Text = "0.00";
            this.txtTotalItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalItem.Enter += new System.EventHandler(this.txtTotalItem_Enter);
            // 
            // txtPrecioU
            // 
            this.txtPrecioU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioU.Location = new System.Drawing.Point(930, 3);
            this.txtPrecioU.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPrecioU.Name = "txtPrecioU";
            this.txtPrecioU.ReadOnly = true;
            this.txtPrecioU.Size = new System.Drawing.Size(66, 26);
            this.txtPrecioU.TabIndex = 144;
            this.txtPrecioU.Text = "0.00";
            this.txtPrecioU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecioU.Enter += new System.EventHandler(this.txtPrecioU_Enter);
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.BackColor = System.Drawing.SystemColors.Info;
            this.txtPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcentaje.Location = new System.Drawing.Point(884, 3);
            this.txtPorcentaje.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(34, 26);
            this.txtPorcentaje.TabIndex = 143;
            this.txtPorcentaje.Text = "0";
            this.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorcentaje.Enter += new System.EventHandler(this.txtPorcentaje_Enter);
            this.txtPorcentaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPorcentaje_KeyDown);
            this.txtPorcentaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentaje_KeyPress);
            // 
            // txtCostoU
            // 
            this.txtCostoU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCostoU.Location = new System.Drawing.Point(657, 4);
            this.txtCostoU.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCostoU.Name = "txtCostoU";
            this.txtCostoU.Size = new System.Drawing.Size(60, 26);
            this.txtCostoU.TabIndex = 140;
            this.txtCostoU.Text = "0.00";
            this.txtCostoU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCostoU.Enter += new System.EventHandler(this.txtCostoU_Enter);
            this.txtCostoU.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCostoU_KeyDown);
            this.txtCostoU.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtCostoU_MouseDoubleClick);
            // 
            // txtCant
            // 
            this.txtCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCant.Location = new System.Drawing.Point(586, 4);
            this.txtCant.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(58, 26);
            this.txtCant.TabIndex = 139;
            this.txtCant.Text = "0";
            this.txtCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCant.Enter += new System.EventHandler(this.txtCant_Enter);
            this.txtCant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCant_KeyDown);
            this.txtCant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCant_KeyPress);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(-3, -4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 46);
            this.label1.TabIndex = 146;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(157, -4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 46);
            this.label2.TabIndex = 147;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(303, -4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(278, 46);
            this.label3.TabIndex = 148;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(652, -4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 46);
            this.label4.TabIndex = 149;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(794, -4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 46);
            this.label5.TabIndex = 150;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(925, -4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 46);
            this.label6.TabIndex = 151;
            // 
            // UserControlItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCostoU);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.txtTotalItem);
            this.Controls.Add(this.txtPrecioU);
            this.Controls.Add(this.txtPorcentaje);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnProveedor);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.cbMone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCatalogo);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserControlItems";
            this.Size = new System.Drawing.Size(1082, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button btnProveedor;
        public System.Windows.Forms.TextBox txtItem;
        public System.Windows.Forms.RichTextBox txtDescripcion;
        public System.Windows.Forms.ComboBox cbMone;
        public System.Windows.Forms.TextBox txtAlias;
        public System.Windows.Forms.TextBox txtCatalogo;
        public System.Windows.Forms.TextBox txtTotalItem;
        public System.Windows.Forms.TextBox txtPrecioU;
        public System.Windows.Forms.TextBox txtPorcentaje;
        public System.Windows.Forms.TextBox txtCostoU;
        public System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
