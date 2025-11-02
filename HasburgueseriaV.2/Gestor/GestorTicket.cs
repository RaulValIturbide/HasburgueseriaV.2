using HasburgueseriaV._2.Alimentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HasburgueseriaV._2.Tickets
{
    public class GestorTicket
    {
       public static List<Ticket> ListaTicket = new List<Ticket>();
       private static string rutaArchivo = "ListaTicketBBDD.json";

        /// <summary>
        /// Metodo para inciar la lista de ticket si aun no existe
        /// </summary>
        public static void InicializarLista()
        {
            FileInfo data = new FileInfo(rutaArchivo);

            if (data.Exists)
            {
                string contenido = File.ReadAllText(rutaArchivo);
                ListaTicket = JsonSerializer.Deserialize<List<Ticket>>(contenido) ?? new List<Ticket>();
            }
            else
            {
                ListaTicket = new List<Ticket>();
            }
        }

        /// <summary>
        /// Este metodo crea busca el nuevo ID para nuestros tickets
        /// </summary>
        /// <returns> Devuelve un entero que será el numero de nuestro ticket </returns>
        public static int AgregarNuevoTicketID()
        {
            int ID = 0;
            if (GestorTicket.ListaTicket.Count > 0)
            {
                ID = GestorTicket.ListaTicket.Max(t => t.ID) + 1; //Buscamos el ticket máximo a través de la función lambda
            }
            else
            {
                ID = 1;
            }
            return ID;
        }

        /// <summary>
        /// Metodo para escribir un ticket serializado en formato JSON
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>Devuelve un controlador para comprobar si se la escritura se ha completado o no</returns>
        public static Controlador GuardarTicket(Ticket ticket)
        {
            Controlador con = new Controlador();
            try
            {
                FileInfo data = new FileInfo(rutaArchivo);

                if (data.Exists)
                {
                  string contenido = File.ReadAllText(rutaArchivo);
                  ListaTicket = JsonSerializer.Deserialize<List<Ticket>>(contenido) ?? new List<Ticket>(); //->Deserializamos el contenido, si nos salta nulo porque está vacío pues creamos una nueva lista
                }
                  ListaTicket.Add(ticket); //Añadimos el ticket a la lista (estatica)
                  string serializacion = JsonSerializer.Serialize(ListaTicket); //Serialización
                    
                File.WriteAllText(rutaArchivo, serializacion); 
                    
                con.codigoError = 0; //Controlador
                con.mensajeError = "Ticket guardado";              
            }
            catch (Exception ex) 
            {
                con.codigoError = 500;
                con.mensajeError = "Error con la escritura del ticket, cancelando operación";
            }

            return con;
        }
        /// <summary>
        /// Si existen menus en la lista menú comprueba el precio del ticket sumando los precios de los menú
        /// </summary>
        /// <param name="ticket"></param>
        /// <returns>Devuelve un numero decimal de la suma del precio de los menus de la lista del ticket</returns>
        public static double SumaPrecioTicket(Ticket ticket)
        {
            double total = 0;
            if (ticket.listaMenu.Count != 0)
            {
                foreach (Menu m in ticket.listaMenu)
                {
                    total += m.precio;
                }
            }
            return total;
        }
    }
}
