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
using System.Data.SqlClient;

namespace ProyectoPED
{
    public partial class Login : Form
    {
        private SqlConnection conect;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private string sCn;

        Conexionbd conexion = new Conexionbd();
        public Login()
        {
            InitializeComponent();
            sCn = conexion.cadena;
            conect = new SqlConnection(sCn);

        }


        //Metodo para el inicio de sesion
       public void login (string usuario, string contraseña)
        {
            conect.Open();
           
            int es = 0;
            string consulta = "SELECT COUNT(*) AS total FROM usuarios WHERE usuario='" + usuario + "' AND contraseña='" + contraseña + "'";
            da = new SqlDataAdapter(consulta, conect);
            dr = da.SelectCommand.ExecuteReader();
            while (dr.Read())
            {
                es = (int)dr["total"];
            }
            dr.Close();
            if (es != 0)
            {
                string consulta1 = "SELECT usuario,tipo_usuario FROM usuarios WHERE usuario='" + usuario + "' AND contraseña='" + contraseña + "'";
                da = new SqlDataAdapter(consulta1, conect);
                dr = da.SelectCommand.ExecuteReader();
                while (dr.Read())
                {
                    string rol = dr["tipo_usuario"].ToString().Trim();
                    string nombre = dr["tipo_usuario"].ToString().Trim();
                    MessageBox.Show("Bienvenid@: " + nombre + "", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (rol == "Administrador")
                    {
                        Form1 MP = new Form1();
                        MP.Visible = true;
                        this.Visible = false;
                    }
                    else
                    {
                        Auxiliar MS = new Auxiliar();
                        MS.Visible = true;
                        this.Visible = false;
                    }

                }
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrecta", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcontraseña.Clear();
            }
            dr.Close();
            conect.Close();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
       
        

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtusuario_Enter(object sender, EventArgs e)
        {
            if (txtusuario.Text == "USUARIO")
            {
                txtusuario.Text = "";
                txtusuario.ForeColor = Color.Black;
            }
        }

        private void txtusuario_Leave(object sender, EventArgs e)
        {
            if (txtusuario.Text == "")
            {
                txtusuario.Text = "USUARIO";
                txtusuario.ForeColor = Color.Black;
            }
        }

        private void txtcontraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcontraseña_Enter(object sender, EventArgs e)
        {
            if (txtcontraseña.Text == "CONTRASEÑA")
            {
                txtcontraseña.Text = "";
                txtcontraseña.ForeColor = Color.Black;
                txtcontraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtcontraseña_Leave(object sender, EventArgs e)
        {
            if (txtcontraseña.Text == "")
            {
                txtcontraseña.Text = "CONTRASEÑA";
                txtcontraseña.ForeColor = Color.Black;
                txtcontraseña.UseSystemPasswordChar = false;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnacceder_Click(object sender, EventArgs e)
        {
            login(this.txtusuario.Text, this.txtcontraseña.Text);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
