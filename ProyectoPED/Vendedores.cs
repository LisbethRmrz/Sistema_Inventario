using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoPED
{
    public partial class Vendedores : Form
    {
        Conexionbd conectar = new Conexionbd();
        private SqlConnection conexion;
        private SqlCommand insert1;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private string sCn;
        public Vendedores()
        {
            InitializeComponent();
            Conexion_login cn = new Conexion_login();
            cn.conec();
            sCn = cn.cadena;
            conexion = new SqlConnection(sCn);
        }

        private void Vendedores_Load(object sender, EventArgs e)
        {
            conectar.CargarVendedores(DatosEmpleados);
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            if (txtnombres.Text == "" || txtapellidos.Text == "" || txttel.Text == "" || txtdir.Text == "" )
            {
                MessageBox.Show("Campos vacios");
            }
            else
            {
                try
                {
                    string InsertarVendedores;
                    InsertarVendedores = "INSERT INTO vendedor(nombre, apellido, telefono, direccion)";
                    InsertarVendedores += "VALUES (@nombre, @apellido, @telefono, @direccion)";
                    insert1 = new SqlCommand(InsertarVendedores, conexion);
                    insert1.Parameters.Add(new SqlParameter("@nombre", SqlDbType.VarChar));
                    insert1.Parameters["@nombre"].Value = txtnombres.Text;
                    insert1.Parameters.Add(new SqlParameter("@apellido", SqlDbType.VarChar));
                    insert1.Parameters["@apellido"].Value = txtapellidos.Text;
                    insert1.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar));
                    insert1.Parameters["@telefono"].Value = txttel.Text;
                    insert1.Parameters.Add(new SqlParameter("@direccion", SqlDbType.VarChar));
                    insert1.Parameters["@direccion"].Value = txtdir.Text;
                    insert1.ExecuteNonQuery();

                    //Limpiamos los textbox

                    txtnombres.Text = "";
                    txtapellidos.Text = "";
                    txttel.Text = "";
                    txtdir.Text = "";
                    codigovendedor.Text = "";

                    MessageBox.Show("Registro agregado");
                    conectar.CargarVendedores(DatosEmpleados);                   
                    conexion.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }

            }
            conexion.Close();
        }

        private void DatosEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = DatosEmpleados.Rows[e.RowIndex];
            codigovendedor.Text = Convert.ToString(fila.Cells[0].Value);
            txtnombres.Text = Convert.ToString(fila.Cells[1].Value);
            txtapellidos.Text = Convert.ToString(fila.Cells[2].Value);
            txttel.Text = Convert.ToString(fila.Cells[3].Value);
            txtdir.Text = Convert.ToString(fila.Cells[4].Value);
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtnombres.Text = "";
            txtapellidos.Text = "";
            txttel.Text = "";
            txtdir.Text = "";
            codigovendedor.Text = "";
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE vendedor SET nombre='" + txtnombres.Text + "',apellido='" + txtapellidos.Text + "',telefono='" + txttel.Text + "',direccion='" + txtdir.Text + "'where id_vendedor ='" + codigovendedor.Text + "'", conexion);
                int filas = cmd.ExecuteNonQuery();
                conexion.Close();

                txtnombres.Text = "";
                txtapellidos.Text = "";
                txttel.Text = "";
                txtdir.Text = "";
                codigovendedor.Text = "";

                if (filas > 0)
                {
                    MessageBox.Show("Vendedor actualizado correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Error al actualizar.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            conectar.CargarVendedores(DatosEmpleados);
            conexion.Close();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM vendedor WHERE id_vendedor='" + codigovendedor.Text + "'", conexion);
                int filas = cmd.ExecuteNonQuery();
                conectar.CargarVendedores(DatosEmpleados);
                conexion.Close();

                txtnombres.Text = "";
                txtapellidos.Text = "";
                txttel.Text = "";
                txtdir.Text = "";
                codigovendedor.Text = "";



                if (filas > 0)
                {
                    MessageBox.Show("Vendedor eliminado correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Error al eliminar.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
            conexion.Close();
        }
    }
}
