using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasburgueseriaV._2.Alimentos
{
    public class Hamburguesa : Alimento
    {
        public List<Ingrediente> listaIngredientes = new List<Ingrediente>();

        public Hamburguesa(List<Ingrediente> listaIngrediente,double precio, string nombre) : base(precio, nombre)
        {
            this.listaIngredientes = listaIngrediente;
            this.precio = precio;
            this.nombre = nombre;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
