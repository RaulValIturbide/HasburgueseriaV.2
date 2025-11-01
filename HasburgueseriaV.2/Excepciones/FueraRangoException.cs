using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasburgueseriaV._2.Excepciones
{
    public class FueraRangoException : Exception
    {
        public FueraRangoException(string mensaje) : base(mensaje)
        { 
            
        }
    }
}
