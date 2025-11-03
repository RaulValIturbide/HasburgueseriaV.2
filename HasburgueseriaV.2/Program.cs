using HasburgueseriaV._2;
using HasburgueseriaV._2.Alimentos;
using HasburgueseriaV._2.Gestor;
using HasburgueseriaV._2.Pantalla;
using HasburgueseriaV._2.Tickets;
using System.Diagnostics;

public class Program
{
    private static void Main(string[] args)
    {
        GestorTicket.InicializarLista();
        bool finPrograma = false;
        int bucle = 0;
        do
        {
            if (bucle > 0) { InterfazUsuario.PresioneEnterParaContinuar();}//Si no es la primera vez que el usuario está en el Mprincipal, limpiamos la pantalla
            bucle++;
            InterfazUsuario.LimpiarPantalla();
            switch (InterfazUsuario.MenuPrincipal())
            {
                case 1://Hacer Pedido                   
                    Ticket t = new Ticket(); 
                    t.ID = GestorTicket.AgregarNuevoTicketID();
                    do
                    {
                        InterfazUsuario.LimpiarPantalla();
                        Menu menuElegido =  GestorMenu.CrearMenu(t);
                        Console.WriteLine($"\nAñadiendo {menuElegido.nombre} al ticket...\n" ); //Mostramos el menú elegido

                    } while (!InterfazUsuario.TerminarPedido()); //Se repetirá hasta que el usuario haya terminado de pedir menús

                    t.Precio = GestorTicket.SumaPrecioTicket(t);

                    InterfazUsuario.LimpiarPantalla();
                    //TODO ARREGLAR TICKETS FANTASMAS -> Problemas con ConsoleClear() -> Simulamos limpieza -> ¿profesor?
                    if (t.Precio == -1 || !InterfazUsuario.PagarPedido(t))
                    {
                        Console.WriteLine("Cancelando Ticket...");
                        
                    }
                    else
                    {
                        Console.WriteLine("Cobrando Ticket...");

                        GestorTicket.GuardarTicket(t);
                    }
                    break;
                case 2://Buscar un ticket
                    Console.WriteLine(TicketMostrado().mensajeError); //Ejecutamos la busqueda del ticket y mostramos el resultado
                    break;
                case 3://Ver Menus
                    Menu mostrarMenu = new Menu();
                    switch (InterfazUsuario.ElegirLista())
                    {
                        case 1: //Mostrar ingredientes
                            mostrarMenu = GestorMenu.CrearMenu(null);
                            InterfazUsuario.LimpiarPantalla();
                            if (mostrarMenu != null)
                            {
                                Console.WriteLine(mostrarMenu.ToString());
                            }
                            break;
                        case 2://Mostrar precios
                            mostrarMenu = GestorMenu.CrearMenu(null);
                            if (mostrarMenu != null)
                            {
                                Console.WriteLine($"El precio del {mostrarMenu.nombre} es de {mostrarMenu.precio} euros");
                            }
                            break;
                    }                  
                    break;
                case 4:
                    finPrograma = true;
                    break;
                }
        } while (!finPrograma);

    }

    /// <summary>
    /// Metodo para buscar un ticket específico al usuario de la lista de tickets
    /// </summary>
    /// <returns>Devuelve un Controlador que gestiona si se ha encontrado o el error que ha habido</returns>
    private static Controlador TicketMostrado()
    {
        Controlador con = new Controlador();
        Ticket ticketBuscado = null;
        int IDBuscado = 0;

        if (GestorTicket.ListaTicket.Count == 0 || GestorTicket.ListaTicket == null)
        {
            con.codigoError = 101;
            con.mensajeError = "Todavía no hay tickets en la BBDD";
        }
        else
        {
             IDBuscado = InterfazUsuario.MostrarTicket();
            InterfazUsuario.LimpiarPantalla();

            
            ticketBuscado = GestorTicket.ListaTicket.FirstOrDefault(t => t.ID == IDBuscado);
          
            
            if (ticketBuscado != null)
            {
                
                con.codigoError = 0;
                con.mensajeError = "\n\nGracias por su compra,¡¡Esperamos que vuelva pronto!!";

                Console.WriteLine(ticketBuscado.ToString());
                Console.WriteLine(ticketBuscado.listaMenu.Count);
            }
            else
            {
                con.codigoError = 500;
                con.mensajeError = "No se ha encontrado un ticket por ese código, intentelo de nuevo";
            }
            
        }
        return con;
    }
}