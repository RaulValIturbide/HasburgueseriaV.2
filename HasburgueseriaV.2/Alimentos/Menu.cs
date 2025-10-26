using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasburgueseriaV._2.Alimentos
{
    public class Menu 
    {
        public double precio;
        public string nombre;
        public Hamburguesa hamburguesa;
        public Bebida bebida;
        public Complemento complemento;

        public Menu(string nombre) 
        {
            this.nombre = nombre;
        }
        public Menu()
        { 
            
        }
        public override string ToString()
        {
            return $"Hamburguesa: {this.hamburguesa.nombre} " +
                   $"\n\tLista Ingredientes: " +
                   $"\n\t\t{MostrarListaIngredientes()} " +
                   $"\nBebida: {this.bebida.nombre} " +
                   $"\nComplemento: {this.complemento.nombre}";
        }
        private string MostrarListaIngredientes()
        {
            string lista = "";
            foreach (Ingrediente i in this.hamburguesa.listaIngredientes)
            {
                lista += i.nombre + "\n\t\t";
            }
            return lista;
        }

        
        
    }
}
