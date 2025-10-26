using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HasburgueseriaV._2.Alimentos;
using HasburgueseriaV._2.Gestor;
using HasburgueseriaV._2.Pantalla;
using HasburgueseriaV._2.Tickets;

namespace HasburgueseriaV._2.Gestor
{
    public class GestorMenu
    {
        /**
         * 
         * La idea de esta clase es que sea escalable, al estar encapsulada pueden crearse infinitos menus diferentes
         * 
         */
        public static Menu menuElegido = new Menu();

        /// <summary>
        /// Metodo para generar un Menu a través de la elecciones dadas por el usuario, lo podemos rehusar para
        /// mostrar los diferentes menus sin incluirlo en ningún ticket a través de los parametros
        /// si ticket es null no se añadirá a ningun ticket
        /// por otro lado el bool mostrar sirve para saber si estamos agrupando varios menus o solo mostrandolos
        /// si seleccionamos true significará que solo queremos mostrar el menu por lo que reiniciará la lista cada vez
        /// y no guardará los ingredientes
        /// </summary>
        /// <param name="t"></param>
        /// <param name="mostrar"></param>
        /// <returns>devuelve el Menu creado</returns>
        public static Menu CrearMenu(Ticket? t,bool mostrar) 
        {
            Controlador con = new Controlador();
            int hamburguesaInt = 0;
            int usuario = InterfazUsuario.EleccionMenu();
            List<Ingrediente> ingredientesHamburguesa = GestorHamburguesa.CrearIngredientesHamburguesa(usuario, mostrar); //Creamos los ingredientes de la hamburguesa seleccionada por el cliente
            double precioHamburguesa = GestorHamburguesa.SumaPreciosIngrediente(); // Sumamos los precios de la hamburguesa elegida
            switch (usuario)
            {
                case 1://Carlos II
                    menuElegido.hamburguesa = new Hamburguesa(ingredientesHamburguesa,precioHamburguesa, "Hamburguesa Imperial");
                    menuElegido.complemento = new Complemento(3.60, "Patatas de Cámara Real");
                    menuElegido.bebida = new Bebida(2.5, "Tisana de la Corte");
                    break;
                case 2://Juana la loca
                    menuElegido.hamburguesa = new Hamburguesa(ingredientesHamburguesa,precioHamburguesa, "Hamburguesa Trastámara Desatada");
                    menuElegido.complemento = new Complemento(2.27, "Pan de Maíz del Convento");
                    menuElegido.bebida = new Bebida(1.17, "Elixir de la Reina");
                    break;
                case 3://Familiar
                    menuElegido.hamburguesa = new Hamburguesa(ingredientesHamburguesa,precioHamburguesa, "Hamburguesa Genealógica Habsburga");
                    menuElegido.complemento = new Complemento(3.3, "Nuggets de Linaje Cruzado");
                    menuElegido.bebida = new Bebida(2.2, "Cerveza de Sangre Azul Austrohúngara");
                    break;
            }
            SumaPrecioMenu(menuElegido);
            if (t != null)
            {
                t.listaMenu.Add(menuElegido);
            }
            return menuElegido;
        }

        public static void SumaPrecioMenu(Menu m)
        {
            m.precio = m.hamburguesa.precio + m.complemento.precio + m.bebida.precio;
        
        }


    }
}
