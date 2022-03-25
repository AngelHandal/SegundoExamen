using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Usuario
    {

        //referencia a nuestra base de datos
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string contrasena { get; set; }

        public Usuario()
        { //constructor vacio
        }

        public Usuario(string codigo, string nombre, string apellido, string contrasena)
        { //constructor
            Codigo = codigo;
            Nombre = nombre;
            Apellido = apellido;
            this.contrasena = contrasena;
        }
    }
}
