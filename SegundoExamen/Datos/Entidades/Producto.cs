using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades{
    public class Producto{
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Inventario { get; set; }


        public Producto()
        { //constructor vacio
        }

        public Producto(string codigo, string descripcion, decimal precio, int inventario)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Precio = precio;
            Inventario = inventario;

        }

    }
}
