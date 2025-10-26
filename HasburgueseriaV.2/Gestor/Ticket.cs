using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HasburgueseriaV._2.Alimentos;

namespace HasburgueseriaV._2.Tickets

{
    public class Ticket
    {
        public int ID { get; set; }
        public double Precio { get; set; }
        public List<Menu> listaMenu = new List<Menu>();


        public override string ToString()
        {
            return $"------------Mostrando ticket-----------\nCódigo Ticket:{this.ID:D3}\nPrecio:{this.Precio:F2} {MostrarListaMenu()}";
        }

        private string MostrarListaMenu()
        {
            string lista = "";
            int numMenu = 0;
            foreach (Menu m in listaMenu)
            {
                numMenu++;
                lista += $"\nMenú {numMenu}:" + m.ToString();
            }
            return lista;
        }
    }
}
