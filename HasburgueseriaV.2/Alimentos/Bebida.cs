using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HasburgueseriaV._2.Alimentos
{
    public class Bebida : Alimento
    {
        public Bebida(double precio,string nombre) : base(precio,nombre)
        {
            this.precio = precio;
            this.nombre = nombre;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
