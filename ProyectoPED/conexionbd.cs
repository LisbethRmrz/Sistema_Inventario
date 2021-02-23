using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Windows.Forms;

namespace ProyectoPED
{
    class Conexionbd
    {



        public string cadena = @"Data Source=localhost; Initial Catalog=tienda_kat3; Integrated Security = True";
        public SqlConnection con = new SqlConnection();

        //Para el DGV
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;
        public Conexionbd()
        {
            con.ConnectionString = cadena;
        }


        public void Abrir()
        {
            try
            {
                con.Open();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error al abrir la conexion", MessageBoxButtons.OK);
            }
        }

        public void Cerrar()
        {
            con.Close();
        }

        //Procedimiento para cargar articulos en el DGV
        public void CargarArticulos(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("select id_articulo, A.nombre as Nombre, A.precio as Precio, C.Nombre_Categoria as Categoria, P.nombre as Proveedor, A.existencias as Existencias from articulo as A inner join categoria as c on A.categoria = c.id_categoria inner join proveedor as P on A.id_proveedor = P.id_proveedor", con);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los articulos");
                ex.ToString();
            }
        }

        //PRocedimiento para carga proveedores en el DGV
        public void CargarProveedores(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("select nombre as Nombre, ubicacion as Ubicacion, telefono as Telefono from proveedor", con);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los proveedores");
                ex.ToString();
            }
        }

        //Cargar Vendedores en el dgv
        public void CargarVendedores(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("select id_vendedor as Codigo, nombre as Nombres, apellido as Apellidos, telefono as Telefono, direccion as Direccion from vendedor", con);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los Vendedores");
                ex.ToString();
            }
        }

        //Cargar Categorias en el dgv
        public void CargarCategorias(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("select  id_categoria as Numero, Nombre_Categoria as [Nombre Categoria] from categoria", con);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las Categorias");
                ex.ToString();
            }
        }
    }
}
