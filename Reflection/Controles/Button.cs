using Reflection.Controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
  public class Button: Clickeable
    {

      
        public void Click()
        {
            Console.WriteLine("click from button");
        }

        public void Message(string mensaje)
        {
            Console.WriteLine($"click from button with message:{mensaje}");
        }

        public void Message2(string mensaje, string mensaje2)
        {
            Console.WriteLine($"click from button with message:{mensaje} : {mensaje2}");
        }
    }
}
