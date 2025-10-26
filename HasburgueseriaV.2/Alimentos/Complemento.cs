using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasburgueseriaV._2.Alimentos
{
    public class Complemento : Alimento
    {


        public Complemento(double precio, string nombre) : base(precio, nombre)
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
