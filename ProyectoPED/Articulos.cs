using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPED
{
   
   
    public partial class Articulos : Form
    {
        List<CArticulo> lArticulos = new List<CArticulo>();
        Conexionbd conec = new Conexionbd();
        DataSet miDataset2;// pertenece a proveedor
        DataSet miDataset;// pertenece a categoria

        int id_articulo;


        




        private SqlConnection con;
        private SqlDataAdapter da;
        private DataTable dt;

        public Articulos()
        {
            InitializeComponent();
            LlenarComboboxCategoria();
            LlenarComboBoxProveedor();
        }

        private void Articulos_Load(object sender, EventArgs e)
        {
            conec.CargarArticulos(Datosarticulos);
            Datosarticulos.Columns[0].Visible = false;
            Datosarticulos.Columns[2].DefaultCellStyle.Format = "0.00";

        }
        
        private void btnagregar_Click(object sender, EventArgs e)
        {
            

            CArticulo articulo = new CArticulo
            {
                NOmbre = txtnombrearticulo.Text,
                Precio = Convert.ToDouble(txtprecio.Text),
                Categoria = int.Parse(cmbCategoria.SelectedValue.ToString()),
                ID_Proveedor = int.Parse(cmbProveedor.SelectedValue.ToString()),
                Existencias = int.Parse(txtcantidad.Text)
            };

            

            lArticulos.Add(articulo);

            LimpiarTextBoxs();

            conec.CargarArticulos(Datosarticulos);
            Datosarticulos.Columns[0].Visible = false;
            Datosarticulos.Columns[2].DefaultCellStyle.Format = "0.00";

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTextBoxs();
        }


        private void LimpiarTextBoxs()
        {
            txtnombrearticulo.Text = "";
            txtprecio.Text = "";
            cmbCategoria.SelectedIndex = 0;
            cmbProveedor.SelectedIndex = 0;
            txtcantidad.Text = "";
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            CArticulo miArticulo = new CArticulo();
           conec.CargarArticulos(Datosarticulos);




            if (miArticulo.InProducto(lArticulos))
                MessageBox.Show("Articulos ingresados " + lArticulos.Count);
            else
                MessageBox.Show("No se pudo ingresar ");


            conec.CargarArticulos(Datosarticulos);


        }

        private void LlenarComboboxCategoria()
        {
            string categoria = "select id_categoria, Nombre_Categoria from categoria";
            

            DataTable dt = new DataTable();
            


            conec.Abrir();
            //esto llena el comboBox de Categoria
            miDataset = new DataSet();
            SqlDataAdapter cat = new SqlDataAdapter(categoria, conec.con);
            cat.Fill(miDataset, "dt");
            cmbCategoria.DataSource = miDataset.Tables[0];
            cmbCategoria.ValueMember = "id_categoria";
            cmbCategoria.DisplayMember = "Nombre_Categoria";
            conec.Cerrar();
        }

        public void LlenarComboBoxProveedor()
        {
            string proveedor = "select id_proveedor, nombre from proveedor";
            //esto llena el combobox de Proveedor
            DataTable dt = new DataTable();
            miDataset2=new DataSet();

            conec.Abrir();
            

            SqlDataAdapter prov = new SqlDataAdapter(proveedor, conec.con);
            prov.Fill(miDataset2, "dt");
            cmbProveedor.DataSource = miDataset2.Tables[0];
            cmbProveedor.ValueMember = "id_proveedor";
            cmbProveedor.DisplayMember = "nombre";
            
            conec.Cerrar();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos()) 
            {
                return;
            }
            
            CArticulo articulo = new CArticulo
            {
                NOmbre = txtnombrearticulo.Text,
                Precio = Convert.ToDouble(txtprecio.Text),
                Categoria = int.Parse(cmbCategoria.SelectedValue.ToString()),
                ID_Proveedor = int.Parse(cmbProveedor.SelectedValue.ToString()),
                Existencias = int.Parse(txtcantidad.Text)
            };



            if (articulo.DeleteArticulo(articulo, id_articulo))
                MessageBox.Show("Articulo eliminado ");
            else
                MessageBox.Show("No se pudo eliminar");


            conec.CargarArticulos(Datosarticulos);
            Datosarticulos.Columns[0].Visible = false;
            Datosarticulos.Columns[2].DefaultCellStyle.Format = "0.00";
            LimpiarTextBoxs();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
                return;

            CArticulo articulo = new CArticulo
            {
                NOmbre = txtnombrearticulo.Text,
                Precio = Convert.ToDouble(txtprecio.Text),
                Categoria = int.Parse(cmbCategoria.SelectedValue.ToString()),
                ID_Proveedor = int.Parse(cmbProveedor.SelectedValue.ToString()),
                Existencias = int.Parse(txtcantidad.Text)
            };



            if (articulo.UpdateArticulo(articulo,id_articulo))
                MessageBox.Show("Articulo actualizado ");
            else
                MessageBox.Show("No se pudo actualizar");


            conec.CargarArticulos(Datosarticulos);
            Datosarticulos.Columns[0].Visible = false;
            Datosarticulos.Columns[2].DefaultCellStyle.Format = "0.00";


        }

        private void Datosarticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow fila = Datosarticulos.Rows[e.RowIndex];
            txtnombrearticulo.Text = Convert.ToString(fila.Cells[1].Value);
            id_articulo = Convert.ToInt32(Convert.ToString(fila.Cells[0].Value));
            txtprecio.Text = Convert.ToString(fila.Cells[2].Value);


            string valorCategoria = Convert.ToString(fila.Cells[3].Value);
            int indice = cmbCategoria.FindString(valorCategoria);
            cmbCategoria.SelectedIndex = indice;

            string valorProveedor = Convert.ToString(fila.Cells[4].Value);
            int indice1 = cmbProveedor.FindString(valorProveedor);
            cmbProveedor.SelectedIndex = indice1;
            
            txtcantidad.Text = Convert.ToString(fila.Cells[5].Value);
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            Conexionbd conexion = new Conexionbd();
            conexion.Abrir();
            da = new SqlDataAdapter("select id_articulo, A.nombre as Nombre, A.precio as Precio, C.Nombre_Categoria as Categoria, P.nombre as Proveedor, A.existencias as Existencias from articulo as A inner join categoria as c on A.categoria = c.id_categoria inner join proveedor as P on A.id_proveedor = P.id_proveedor where A.nombre LIKE'%"+txtbuscar.Text+"%'", conexion.con);
            dt = new DataTable();
            da.Fill(dt);
            Datosarticulos.DataSource = dt;
            Datosarticulos.Columns[0].Visible = false;
            Datosarticulos.Columns[2].DefaultCellStyle.Format = "0.00";
            conexion.Cerrar();
        }

        private bool ValidarCampos()
        {
            if (txtnombrearticulo.Text == "" || txtprecio.Text == "" || txtcantidad.Text == "")
            {
                MessageBox.Show("Deben ser llenados todos los campos");
                return true;
            }
                
            else return false;
            
        }
    }
}

