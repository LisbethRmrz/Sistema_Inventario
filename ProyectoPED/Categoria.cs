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
    public partial class Categoria : Form
    {
        Conexionbd conectar = new Conexionbd();
        private SqlConnection conexion;
        private SqlCommand insert1;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private string sCn;
        
        public Categoria()
        {
            InitializeComponent();
            Conexion_login cn = new Conexion_login();
            cn.conec();
            sCn = cn.cadena;
            conexion = new SqlConnection(sCn);
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            conectar.CargarCategorias(DatosCategoria);
         
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            if (txtnombres.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Campos vacios");
            }
            else
            {
                try
                {
                    string InsertarCategorias;
                    InsertarCategorias = "INSERT INTO categoria(Nombre_Categoria, descripcion)";
                    InsertarCategorias += "VALUES (@Nombre_Categoria, @descripcion)";
                    insert1 = new SqlCommand(InsertarCategorias, conexion);
                    //insert1.Parameters.Add(new SqlParameter("id_categoria", SqlDbType.Int));
                    //insert1.Parameters["@id_categoria"].Value = textBox2.Text;
                    insert1.Parameters.Add(new SqlParameter("@Nombre_Categoria", SqlDbType.VarChar));
                    insert1.Parameters["@Nombre_Categoria"].Value = txtnombres.Text;
                    insert1.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar));
                    insert1.Parameters["@descripcion"].Value = textBox1.Text;
                    insert1.ExecuteNonQuery();

                    //Limpiamos los textbox
              
                    textBox1.Text = "";
                    codigo.Text = "";
                    txtnombres.Text = "";

                    MessageBox.Show("Registro agregado");
                    conectar.CargarCategorias(DatosCategoria);
                    conexion.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }

                }
                conexion.Close();
            }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE categoria SET Nombre_Categoria='" + txtnombres.Text + "',descripcion='" + textBox1.Text + "'where id_categoria ='" + codigo.Text + "'" , conexion);
                int filas = cmd.ExecuteNonQuery();
                conexion.Close();

                textBox1.Text = "";
                codigo.Text = "";
                txtnombres.Text = "";
                if (filas > 0)
                {
                    MessageBox.Show("Categoria actualizada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            conectar.CargarCategorias(DatosCategoria);
            conexion.Close();
        }

        private void DatosCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = DatosCategoria.Rows[e.RowIndex];
            codigo.Text = Convert.ToString(fila.Cells[0].Value);
            txtnombres.Text = Convert.ToString(fila.Cells[1].Value);
            //textBox1.Text = Convert.ToString(fila.Cells[2].Value);  
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtnombres.Text = "";
            textBox1.Text = "";
            codigo.Text = "";
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM categoria WHERE id_categoria='" + codigo.Text + "'", conexion);
                int filas = cmd.ExecuteNonQuery();
                conectar.CargarCategorias(DatosCategoria);
                conexion.Close();
                textBox1.Text = "";
                codigo.Text = "";
                txtnombres.Text = "";
                
                if (filas > 0)
                {
                    MessageBox.Show("Categoria eliminada correctamente.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

