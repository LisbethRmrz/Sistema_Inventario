using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ProyectoPED
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void AbrirFormInPanel<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelcontenedor.Controls.OfType<MiForm>().FirstOrDefault();
            //Busca en la coleccion el formulario
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                panelcontenedor.Controls.Add(formulario);
                panelcontenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }

            else
            {
                formulario.BringToFront();
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int lx, ly;
        int sw, sh;

        private void btnmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnslide_Click(object sender, EventArgs e)
        {
            if (panelmenu.Width == 250)
            {
                panelmenu.Width = 61;
            }
            else
            {
                panelmenu.Width = 250;
            }
        }

        private void btnrestart_Click(object sender, EventArgs e)
        {
            btnrestart.Visible = false;
            btnmax.Visible = true;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void paneltitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel<Proveedores>();
        }

        private void btnarticulos_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel<Articulos>();
        }

        private void btnvendedores_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel<Vendedores>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureboss_Click(null, e);
        }

        private void pictureboss_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel<Inicio>();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel<Inicio>();
        }

        private void panelcontenedor_Paint(object sender, PaintEventArgs e)
        {
            Conexionbd conexion = new Conexionbd();
            
        }

        private void btnfin_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();
        }

        private void btncategorias_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel<Categoria>();
        }

        private void paneltitulo_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;

            btnrestart.Visible = true;
            btnmax.Visible = false;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }


    }
}
