using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPED
{
    class CArticulo
    {
        Conexionbd conexion = new Conexionbd();
        private string nombre;

        public string NOmbre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private double precio;

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private int categoria;

        public int Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private int id_proveedor;

        public int ID_Proveedor
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }

        private int existencias;

        public int Existencias
        {
            get { return existencias; }
            set { existencias = value; }
        }

        public CArticulo()
        {

        }

        public CArticulo(string nombre, double precio, int categoria, int id_proveedor, int existencias)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.categoria = categoria;
            this.id_proveedor = id_proveedor;
            this.existencias = existencias;
        }

        public bool InProducto(List<CArticulo> aInsertar)
        {
           conexion.Abrir();
            int filasAfectadas = -1;
            

            foreach (CArticulo item in aInsertar)
            {
                string insertar = "InsertarArticulos";
                SqlCommand cmdInsertar = new SqlCommand(insertar, conexion.con);
                cmdInsertar.CommandType = CommandType.StoredProcedure;
                SqlParameter param;

                param = cmdInsertar.Parameters.AddWithValue("@nombre", item.NOmbre);
                param = cmdInsertar.Parameters.AddWithValue("@precio", item.Precio);
                param = cmdInsertar.Parameters.AddWithValue("@categoria", item.Categoria);
                param = cmdInsertar.Parameters.AddWithValue("@id_proveedor", item.ID_Proveedor);
                param = cmdInsertar.Parameters.AddWithValue("@existencias", item.Existencias);
                filasAfectadas=cmdInsertar.ExecuteNonQuery();

            }
            

            int numIgresados = aInsertar.Count;
            
            conexion.Cerrar();
            if (filasAfectadas > 0) return true;
            else return false;
        }


        public bool UpdateArticulo (CArticulo articulo,int id_articulo)
        {



            string update = "update articulo set nombre=@nombre, precio=@precio,categoria=@categoria, id_proveedor=@id_proveedor, existencias=@existencias where id_articulo=@nombreArticulo";

            conexion.Abrir();
            SqlCommand cmd = new SqlCommand(update, conexion.con);
            SqlParameter param;
            param = cmd.Parameters.AddWithValue("@nombre", articulo.nombre);
            param = cmd.Parameters.AddWithValue("@precio", articulo.precio);
            param = cmd.Parameters.AddWithValue("@categoria", articulo.categoria);
            param = cmd.Parameters.AddWithValue("@id_proveedor", articulo.id_proveedor);
            param = cmd.Parameters.AddWithValue("@existencias", articulo.existencias);
            param = cmd.Parameters.AddWithValue("@nombreArticulo", id_articulo);
            int filasAfectadas = cmd.ExecuteNonQuery();

            conexion.Cerrar();

            return (filasAfectadas > 0) ? true : false;

        }

        public bool DeleteArticulo (CArticulo articulo, int id_articulo)
        {
            string update = "Delete articulo where id_articulo=@idArticulo and nombre=@nombre";

            conexion.Abrir();
            SqlCommand cmd = new SqlCommand(update, conexion.con);
            SqlParameter param;
            param = cmd.Parameters.AddWithValue("@nombre", articulo.nombre);
            
            param = cmd.Parameters.AddWithValue("@idArticulo", id_articulo);
            int filasAfectadas = cmd.ExecuteNonQuery();

            conexion.Cerrar();

            return (filasAfectadas > 0) ? true : false;
        }

    }
}
