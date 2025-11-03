using HasburgueseriaV._2.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HasburgueseriaV._2.Excepciones;

namespace HasburgueseriaV._2.Pantalla
{
    public class InterfazUsuario
    {
        /// <summary>
        /// Metodo de interfaz principal
        /// </summary>
        /// <returns>Devuelve un numero entre 1 y 4 de la eleccion del usuario</returns>
        public static int MenuPrincipal()
        {
            int usuario = -1;
            bool correcto = false;
            do
            {
                try
                {
                    Console.WriteLine("Bienvenido a la Hasburguesería,dígame,¿que desea?\n1-Hacer Pedido\n2-Leer Tickets\n3-Ver menús\n4-Salir");
                    Console.Write(">>");
                    usuario = Convert.ToInt32(Console.ReadLine());

                    if (EleccionUsuario(1, 4, usuario))
                    {
                        correcto = true;
                    }
                    else
                    {
                        throw new FueraRangoException("Elija un número entre los posibles e intentelo de nuevo\n");
                    }

                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Elija un número\n");
                }
                catch (FueraRangoException fre)
                {
                    Console.WriteLine(fre.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR FATAL: {ex.StackTrace}");
                }
            } while (!correcto);

            return usuario;
        }

        /// <summary>
        /// Metodo que pregunta al usuario cual es su numero de ticket
        /// </summary>
        /// <returns>devuelve un numero</returns>
        public static int MostrarTicket()
        {
            int IDBuscado = 0;

            try
            {
                Console.WriteLine("¿Dame el número del ticket que quieres ver");
                Console.Write(">>");
                IDBuscado = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException fe)
            {

            }
            catch (Exception ex)
            { 
            }
            return IDBuscado;
        }
        public static void LimpiarPantalla()
        {
            //Console.Clear(); -> Deja información de "Tickets fantasma" ¿buffer? ¿solución?
            Console.WriteLine(new string('\n', 50)); //-> Servirá aunque no es lo más técnico, me gustaría resolver el problema de arriba
        }
        public static void PresioneEnterParaContinuar()
        {
            Console.WriteLine("\n>> Presione enter para continuar");
            Console.ReadLine();           
        }

        
        public static int EleccionMenu()
        {
            int menuElegido = -1;
            bool correcto = false;
            int bucle = 0;
            do
            {
                try
                {
                    if (bucle > 0) { PresioneEnterParaContinuar(); LimpiarPantalla(); } //Si el usuario se equivoca le mostraremos el error y limpiaremos pantalla para que se vea más limpio
                    Console.WriteLine("¿Que menú quieres?\n1-Menú Carlos II\n2-Menú Juana La Loca\n3-Menú Endogámico Familiar");
                    Console.Write(">>");
                    bucle++;
                    menuElegido = Convert.ToInt32(Console.ReadLine());
                    if (EleccionUsuario(1, 3, menuElegido))
                    {
                        correcto = true;
                    }
                    else
                    {
                        throw new FueraRangoException("Elija un numero entre 1 y 3");
                    }

                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Elige un número");
                }
                catch (FueraRangoException fre)
                {
                    Console.WriteLine(fre.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR FATAL\n: {ex.StackTrace}");
                }               
        }while(!correcto);

         return menuElegido;
        }

        /// <summary>
        /// Metodo para enseñarle al usuario su pedido y preguntarle si desea pagarlo o no
        /// </summary>
        /// <param name="ticketActual"></param>
        /// <returns>Si se elije que si (1) devolverá true y se pagará el pedido</returns>
        public static bool PagarPedido(Ticket ticketActual)
        {
            LimpiarPantalla();
            bool correcto = false;
            int usuario = 2;
            do
            {
                try
                {
                    Console.WriteLine($"Tu pedido se compone de :\n" +
                                      $"{ticketActual.ToString()}\n\n" +
                                      $"¿Deseas pagarlo? Precio:{ticketActual.Precio:F2}\n" +
                                      $"1-Si\n2-No");
                    Console.Write(">>");
                    usuario = Convert.ToInt32(Console.ReadLine());
                    if (EleccionUsuario(1, 2, usuario)) { correcto = true; } else { throw new FueraRangoException("Elija un numero entre 1 y 2"); } //Comprobamos que el usuario elija entre los posibles y salimos del bucle
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Elije un número");
                    PresioneEnterParaContinuar();
                    LimpiarPantalla();
                }
                catch (FueraRangoException fre)
                {
                    Console.WriteLine(fre.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR FATAL:\n" + ex.StackTrace);
                }
            } while (!correcto);
            return usuario == 1 ? true : false;
        }

        /// <summary>
        /// Metodo que pregunta al usuario si desea pedir otro menú al ticket
        /// </summary>
        /// <returns>Devolverá true si el usuario decide terminar el pedido y no añadir otro menu al ticket</returns>
        public static bool TerminarPedido()
        {
            bool correcto = false;
            int usuario = -1;
            do
            {
                try
                {
                    Console.WriteLine("¿Deseas Pedir otro Menú?\n1-Si\n2-No");
                    Console.Write(">>");
                    usuario = Convert.ToInt32(Console.ReadLine());
                    if (EleccionUsuario(1, 2, usuario))
                    {
                        correcto = true;
                    }
                    else
                    {
                        throw new FueraRangoException("Elija un numero entre 1 y 2");
                    }

                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Escriba un numero");
                }
                catch (FueraRangoException fre)
                {
                    Console.WriteLine(fre.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR FATAL: {ex.StackTrace}");
                }
            } while (!correcto);

            return usuario == 2 ? true : false;
        }

        public static int ElegirLista()
        {
            int usuario = -1;
            bool correcto = false;
            do
            {
                try
                {
                    Console.WriteLine("\n¿Que información deseas?\n1-Ver ingredientes de los menú\n2-Ver precios de los menú");
                    Console.Write(">>");
                    usuario = Convert.ToInt32(Console.ReadLine());
                    if (EleccionUsuario(1, 2, usuario)){ correcto = true; } else { throw new FueraRangoException("Elija un numero entre 1 y 2"); }
                }
                catch (FueraRangoException fre)
                {
                    Console.WriteLine(fre.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Elija un número");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR FATAL:\n{ex.StackTrace}");
                }

                return usuario;
            
            } while (!correcto);
        }

        #region Metodos Privados
        /// <summary>
        /// Este metodo comprueba que nuestro usuario elija entre los parámetros que nosotros le pasamos, igual o mayor que el mas pequeño
        /// e igual o menor que el mas grande
        /// </summary>
        /// <param name="menor"></param>
        /// <param name="mayor"></param>
        /// <param name="usuario"></param>
        /// <returns>True si la eleccion se encuentra entre los numeros correspondientes</returns>
        private static bool EleccionUsuario(int menor, int mayor, int usuario)
        {
            return usuario >= menor && usuario <= mayor ? true : false;
        }
        #endregion
    }
}
