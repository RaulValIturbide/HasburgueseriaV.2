using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasburgueseriaV._2.Alimentos
{
    public class Alimento
    {
        public double precio { get; set; }
        public string nombre { get; set; }

        public Alimento(double precio, string nombre)
        {
            this.precio = precio;
            this.nombre = nombre;
        }

        public override string ToString()
        {
            return $"Nombre: {nombre}\nPrecio:{precio}";
        }
    }
}
