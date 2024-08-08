using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cotizaciones_Moserep
{
    public partial class FormCosto : Form
    {
        public bool tieneCosto=false;
        public FormCosto()
        {
            InitializeComponent();
        }

        private void FormCosto_Load(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtTax.Text) > 0)
                    ckTax.Checked = true;
                if (Convert.ToDouble(txtImportacion.Text) > 0)
                    ckImportacion.Checked = true;
            }
            catch
            {

            }
        }

        private void btnGuardarCotizacion_Click(object sender, EventArgs e)
        {
            tieneCosto = true; 
            this.Close();
        }

        private void ckTax_CheckedChanged(object sender, EventArgs e)
        {
            calcular();
            ckImportacion.Checked = true;

        }

        private void calcular()
        {
            try
            {
                double costo=Convert.ToDouble(txtCosto.Text);
                double tax = 0;
                if (ckTax.Checked)
                {
                    tax = costo * 0.08;
                    txtTax.Text= tax.ToString("##0.00");
                }
                else
                    txtTax.Text = "0.00";
                double shiping= Convert.ToDouble(txtShipping.Text);
                double import = 0;
                if (ckImportacion.Checked)
                {
                    import = (costo + tax + shiping) * 0.08;
                    txtImportacion.Text = import.ToString("##0.00");
                }
                else
                    txtImportacion.Text = "0.00";
                double otros = Convert.ToDouble(txtOtros.Text);
                txtTotal.Text=(costo+ tax+shiping+import+otros).ToString("##0.00");
            }
            catch {
                MessageBox.Show("Se necesita capturas montros correctos");

            }
        }

        private void ckImportacion_CheckedChanged(object sender, EventArgs e)
        {
            calcular();
        }

        private void txtCosto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calcular();
                ckTax.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                ckTax.Focus();
            }
        }

        private void ckTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ckTax.Checked = true;
                calcular();
                txtShipping.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtShipping.Focus();
            }
        }

        private void txtShipping_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calcular();
                ckImportacion.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                ckImportacion.Focus();
            }
        }

        private void ckImportacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ckImportacion.Checked = true;
                calcular();
                txtOtros.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtOtros.Focus();
            }
        }

        private void txtOtros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calcular();
                txtNota.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtNota.Focus();
            }
        }

        private void txtNota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardarCotizacion.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                btnGuardarCotizacion.Focus();
            }
        }
    }
}
