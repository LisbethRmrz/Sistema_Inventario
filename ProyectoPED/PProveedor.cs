using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPED
{
    class PProveedor
    {
        Conexionbd conexion = new Conexionbd();
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string apellidos;
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        private int telefono;
        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public PProveedor()
        {

        }

        public PProveedor(string nombre, string apellidos, int telefono, string direccion)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
           
        }

        public bool InProveedor(List<PProveedor> aInsertar)
        {
            conexion.Abrir();
            int filasAfectadas = -1;

            foreach (PProveedor item in aInsertar)
            {
                string insertar = "InsertarProveedor";
                SqlCommand cmdInsertar = new SqlCommand(insertar, conexion.con);
                cmdInsertar.CommandType = CommandType.StoredProcedure;
                SqlParameter param;

                param = cmdInsertar.Parameters.AddWithValue("@nombre", item.Nombre);
                param = cmdInsertar.Parameters.AddWithValue("@apellidos", item.Apellidos);
                param = cmdInsertar.Parameters.AddWithValue("@telefono", item.Telefono);
                param = cmdInsertar.Parameters.AddWithValue("@direccion", item.Direccion);
                
                filasAfectadas = cmdInsertar.ExecuteNonQuery();
            }

            int numIgresados = aInsertar.Count;

            conexion.Cerrar();
            if (filasAfectadas > 0) return true;
            else return false;
        }
      }

    }

