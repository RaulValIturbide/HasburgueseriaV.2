using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasburgueseriaV._2.Alimentos
{
    public class Menu 
    {
        public double precio { get; set; }
        public string nombre { get; set; }
        public Hamburguesa hamburguesa { get; set; }
        public Bebida bebida { get; set; }
        public Complemento complemento { get; set; }

        public Menu(string nombre) 
        {
            this.nombre = nombre;
        }
        public Menu()
        { 
            
        }
        public override string ToString()
        {
            return $"{this.nombre}" +
                   $"\n\tHamburguesa: {this.hamburguesa.nombre} " +
                   $"\n\t\tLista Ingredientes: " +
                   $"\n{MostrarListaIngredientes()} " +
                   $"\n\tBebida: {this.bebida.nombre} " +
                   $"\n\tComplemento: {this.complemento.nombre}";
        }
        private string MostrarListaIngredientes()
        {
            string lista = "";
            foreach (Ingrediente i in this.hamburguesa.listaIngredientes)
            {
                lista += "\t\t\t" + i.nombre + "\n";
            }
            return lista;
        }

        
        
    }
}
