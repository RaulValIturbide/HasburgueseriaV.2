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
            if (bucle > 0) { InterfazUsuario.PresioneEnterParaContinuar(); InterfazUsuario.LimpiarPantalla(); }
            bucle++;
            switch (InterfazUsuario.MenuPrincipal())
            {
                //Prueba
                case 1://Hacer Pedido
                    
                    Ticket t = new Ticket(); 
                    t.ID = GestorTicket.AgregarNuevoTicketID();
                    do
                    {
                        InterfazUsuario.LimpiarPantalla();
                        GestorMenu.CrearMenu(t,false);

                    } while (!InterfazUsuario.TerminarPedido()); //Se repetirá hasta que el usuario haya terminado de pedir menús

                    t.Precio = GestorTicket.SumaPrecioTicket(t);

                    InterfazUsuario.LimpiarPantalla();

                    if (t.Precio == -1 || !InterfazUsuario.PagarPedido(t))
                    {
                        Console.WriteLine("Cancelando Ticket...");
                        
                    }
                    else
                    {
                        GestorTicket.GuardarTicket(t);
                    }
                    break;
                case 2://Buscar un ticket
                    Console.WriteLine(TicketMostrado().mensajeError); //Ejecutamos la busqueda del ticket y mostramos el resultado
                    break;
                case 3://Ver Menus
                    Menu mostrarMenu = new Menu();
                    mostrarMenu  = GestorMenu.CrearMenu(null,true);
                    InterfazUsuario.LimpiarPantalla();
                    Console.WriteLine(mostrarMenu.ToString());              
                    break;
                case 4:
                    finPrograma = true;
                    break;
                }
        } while (!finPrograma);

    }

    private static Controlador TicketMostrado()
    {
        Controlador con = new Controlador();
        Ticket ticketBuscado = null;
        int IDBuscado = 0;

        if (GestorTicket.ListaTicket.Count == 0)
        {
            con.codigoError = 101;
            con.mensajeError = "Todavía no hay tickets en la BBDD";
        }
        else
        {
             IDBuscado = InterfazUsuario.MostrarTicket();

            foreach (Ticket t in GestorTicket.ListaTicket)
            {
                if (t.ID == IDBuscado)
                {
                    ticketBuscado = t;
                }
            }
            
            if (ticketBuscado != null)
            {
                
                con.codigoError = 0;
                con.mensajeError = "\n\nGracias por su compra,¡¡Esperamos que vuelva pronto!!";

                Console.WriteLine(ticketBuscado.ToString());
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