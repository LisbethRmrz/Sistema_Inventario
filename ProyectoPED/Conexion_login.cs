using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPED
{
    class Conexion_login
    {
       
        public string cadena;
        public void conec()
        {

            cadena = @"Data Source=localhost; Initial Catalog=tienda_kat3; Integrated Security = True; user id = sa; password = 1234";
        }
    }
}
