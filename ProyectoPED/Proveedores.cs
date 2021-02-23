using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPED
{
    public partial class Proveedores : Form
    {
        List<PProveedor> lProveedor = new List<PProveedor>();
        Conexionbd conec = new Conexionbd();
        public Proveedores()
        {
            InitializeComponent();
          
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            conec.CargarProveedores(Datosproveedores);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTextBoxs();
        }

        private void LimpiarTextBoxs()
        {
            txtnombres.Text = "";
            txtapellidos.Text = "";
            txttel.Text = "" ;
            txtdir.Text = "";
            
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            PProveedor miProveedor = new PProveedor();
            conec.CargarProveedores(Datosproveedores);

            if (miProveedor.InProveedor(lProveedor))
                MessageBox.Show("Proveedores ingresados " + lProveedor.Count);
            else
                MessageBox.Show("No se pudo ingresar ");


            conec.CargarArticulos(Datosproveedores);


        }

    }
    }

