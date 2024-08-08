using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cotizaciones_Moserep
{
    public partial class Form1 : Form
    {
        private string numsolicitud="";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCotizar_Click(object sender, EventArgs e)
        {
            FormCotizaciones ventana = new FormCotizaciones();
            this.Hide();
            ventana.ShowDialog();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baseDatos.SetConnectionString("server=localhost;Database=cotizaciones;Uid=root;Password=; Convert Zero Datetime=True");

            if (Properties.Settings.Default.idUsuario == 0)
            {
                FormLogin ventana = new FormLogin();
                this.Hide();
                ventana.ShowDialog();
                if (users.usuarioActual != null)
                    this.Show();
                else
                    this.Close();
            }
            llenarListas();
            if (Properties.Settings.Default.idUsuario > 0)
            {
                controladorUsuario controladorUsuario = new controladorUsuario();
                controladorUsuario.obtenerUsuarioLogin(Properties.Settings.Default.idUsuario);
            }
            controladorCotizacion.tc = Properties.Settings.Default.tc;

            if (users.usuarioActual!=null)
                obtenerSolicitudCotizaciones(ckVerTodas.Checked, dtpInicio.Value);
            baseDatos.editarBorrarpersona();
        }

        private void llenarListas()
        {
            controladorCliente controladorCliente = new controladorCliente();
            controladorContactoCliente controladorContactoCliente = new controladorContactoCliente();
            controladorProveedor controladorProveedor = new controladorProveedor();
            controladorContactoProveedor controladorContactoProveedor = new controladorContactoProveedor();
            controladorUsuario controladorUsuario = new controladorUsuario();
            controladorIva controladorIva = new controladorIva();
            controladorUsuario.obtenerUsuarios();
            controladorCliente.obtenerClientes();
            controladorContactoCliente.obtenerContactos();
            controladorProveedor.obtenerProveedores();
            controladorContactoProveedor.obtenerContactos();
            controladorIva.obtenerIvas();
            controladorUsuario.obtenerPerfiles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            obtenerSolicitudCotizaciones(ckVerTodas.Checked, dtpInicio.Value);
        }


        private void actualizarSolicitud(string estatus)
        {
            if (numsolicitud != "") {
                baseDatos.SetConnectionString("server=secure251.inmotionhosting.com;Database=abdsto5_cotizaciones;Uid=abdsto5_felipe;Password=1945Inadescobi; Convert Zero Datetime=True");
                baseDatos.editarSolicitud(estatus, numsolicitud);
                baseDatos.SetConnectionString("server=box5819.bluehost.com;Database=socalmsc_moserep;Uid=socalmsc_user;Password=pipirrin1945##; Convert Zero Datetime=True");
                //42306
            }
        }

        private void obtenerSolicitudCotizaciones(bool verTodas , DateTime fecha)       
        {
            baseDatos.SetConnectionString("server=secure251.inmotionhosting.com;Database=abdsto5_cotizaciones;Uid=abdsto5_felipe;Password=1945Inadescobi; Convert Zero Datetime=True");
            // string nombreUsuario = baseDatos.consultas("select Nombre from usuario where ID=" + users.usuarioActual.id.ToString() + " limit 1");

            String error = "";
            string query = "SELECT cotizaciones.id as  No_solicitud, cotizaciones.asunto as Titulo, clientes.RAZON_SOCIAL as Cliente, cotizaciones.contacto as Contacto, " +
"cotizaciones.fechaRecibida as Fecha, cotizaciones.prioridad as Prioridad, cotizaciones.nomensaje, cotizaciones.idcliente, cotizaciones.id, cotizaciones.noprecotizacion as Cotizacion, cotizaciones.status as Status, cotizaciones.correo " +
"FROM cotizaciones " +
"JOIN clientes ON clientes.id = cotizaciones.idcliente " +
"WHERE cotizaciones.cotizador = '" + users.usuarioActual.user + "' and (cotizaciones.status='Asignada' or cotizaciones.status='Lista para revisar' or cotizaciones.status='En proceso' or cotizaciones.status='Cotizando' or cotizaciones.status='Cot. solicitada' or cotizaciones.status='Cot. recibida')" +
"GROUP BY cotizaciones.id limit 100";
            if (verTodas)
            {
                query = "SELECT cotizaciones.id as  No_solicitud, cotizaciones.asunto as Titulo, clientes.RAZON_SOCIAL as Cliente, cotizaciones.contacto as Contacto, " +
"cotizaciones.fechaRecibida as Fecha, cotizaciones.prioridad as Prioridad, cotizaciones.nomensaje, cotizaciones.idcliente, cotizaciones.id, cotizaciones.noprecotizacion as Cotizacion, cotizaciones.status as Status, cotizaciones.correo " +
"FROM cotizaciones " +
"JOIN clientes ON clientes.id = cotizaciones.idcliente " +
"WHERE cotizaciones.cotizador = '" + users.usuarioActual.user + "' and (fechaAsignada>="+ baseDatos.FormatoFecha(fecha)+") " +
"GROUP BY cotizaciones.id ";
            }
            DataTable dt = baseDatos.Tabla(query, ref error);
            
            dgv1.DataSource = dt;
            if (dgv1.RowCount < 1)
                dgv1.Visible = false;
            if (dgv1.Columns.Count > 0)
            {
                dgv1.Columns[0].Width = 100;
                dgv1.Columns[1].Width = 300;
                dgv1.Columns[2].Width = 300;
                dgv1.Columns[3].Width = 200;
                dgv1.Columns[4].Width = 130;
                dgv1.Columns[5].Width = 80;
                dgv1.Columns[6].Visible = false;
                dgv1.Columns[7].Visible = false;
                dgv1.Columns[8].Visible = false;
            }
            baseDatos.SetConnectionString("server=box5819.bluehost.com;Database=socalmsc_moserep;Uid=socalmsc_user;Password=pipirrin1945##; Convert Zero Datetime=True");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Properties.Settings.Default.idUsuario = 0;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void dgv1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            numsolicitud = Convert.ToString((dgv1.SelectedRows[0].Cells[0].Value)); //"22469";
        }

        private void dgv1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormCotizaciones ventana = new FormCotizaciones();
            this.Hide();
            ventana.txtsolicitud.Text = dgv1.SelectedRows[0].Cells[0].Value.ToString();
            ventana.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(numsolicitud!="")
            {
                actualizarSolicitud("Cot. solicitada");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            actualizarSolicitud("Cot. recibida");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            actualizarSolicitud("Enviada");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (numsolicitud != "")
            {
                actualizarSolicitud("Asignada");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (numsolicitud != "")
            {
                actualizarSolicitud("Cancelada");
            }
        }
    }
}
