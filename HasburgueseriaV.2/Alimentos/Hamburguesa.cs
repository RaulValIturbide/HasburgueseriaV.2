using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasburgueseriaV._2.Alimentos
{
    public class Hamburguesa : Alimento
    {
        public List<Ingrediente> listaIngredientes { get; set; } = new List<Ingrediente>();

        public Hamburguesa(List<Ingrediente> listaIngredientes,double precio, string nombre) : base(precio, nombre)
        {
            this.listaIngredientes = listaIngredientes;
            this.precio = precio;
            this.nombre = nombre;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
