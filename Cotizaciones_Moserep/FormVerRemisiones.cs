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
    public partial class FormVerRemisiones : Form
    {
        public FormVerRemisiones()
        {
            InitializeComponent();
        }

        private void FormVerRemisiones_Load(object sender, EventArgs e)
        {
            dtgItems.DataSource = controladorCotizacion.verRemisiones();
        }
    }
}
