using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasburgueseriaV._2.Alimentos
{
    public class Ingrediente : Alimento
    {
       
        public Ingrediente(double precio, string nombre) : base(precio, nombre)
        {
            this.precio = precio;
            this.nombre = nombre;        
        }

    }
}
