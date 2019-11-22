using System;

namespace Reflection.Controles
{
    public class Button
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
