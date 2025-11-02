using HasburgueseriaV._2.Alimentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasburgueseriaV._2.Gestor
{
    public class GestorHamburguesa
    {
        public static List<Ingrediente> listaIngredientes = new List<Ingrediente>();
        public static List<Ingrediente> CrearIngredientesHamburguesa(int IdHamburguesa)
        {
     
                listaIngredientes = new List<Ingrediente>();
            
            switch (IdHamburguesa)
            {
                case 1: //Carlos II
                    listaIngredientes.Add(new Ingrediente(3.55, "Vaca Hechizada de El Escorial"));
                    listaIngredientes.Add(new Ingrediente(1.50, "Lechuga Austriaca"));
                    listaIngredientes.Add(new Ingrediente(1.25, "Tomate de la Corte de Madrid"));
                    listaIngredientes.Add(new Ingrediente(0.55, "Pepinillo Real"));
                    listaIngredientes.Add(new Ingrediente(2.50, "Queso Azul de los Austrias"));
                    break;

                case 2: //Juana la Loca
                    listaIngredientes.Add(new Ingrediente(2.36, "Vaca Loca de Tordesillas"));
                    listaIngredientes.Add(new Ingrediente(1.27, "Lechuga Desquiciada"));
                    listaIngredientes.Add(new Ingrediente(1.32, "Tomate de la Reina"));
                    listaIngredientes.Add(new Ingrediente(0.53, "Pepinillo del Trono"));
                    listaIngredientes.Add(new Ingrediente(2.67, "Queso Azul Melancólico"));
                    break;

                case 3://La endogamia de los Habsburgo
                    listaIngredientes.Add(new Ingrediente(2.66, "Vaca Endogámica"));
                    listaIngredientes.Add(new Ingrediente(1.27, "Lechuga Consanguínea"));
                    listaIngredientes.Add(new Ingrediente(1.25, "Tomate Austrohúngaro"));
                    listaIngredientes.Add(new Ingrediente(0.45, "Pepinillo de Cámara"));
                    listaIngredientes.Add(new Ingrediente(2.50, "Queso Azul Degenerado"));
                    break;
            }
            return listaIngredientes;          
        }
        public static double SumaPreciosIngrediente()
        {
            double total = 0;
            
            foreach (Ingrediente i in listaIngredientes)
            {
                total += i.precio;
            }
            return total;
        }

        public static void MostrarIngredientesHamburguesa(int IDHamburguesa)
        {
            CrearIngredientesHamburguesa(IDHamburguesa);//Creamos los ingredientes en la lista
            foreach (Ingrediente i in listaIngredientes)
            {
                i.ToString();
            }
        }

    }
}
