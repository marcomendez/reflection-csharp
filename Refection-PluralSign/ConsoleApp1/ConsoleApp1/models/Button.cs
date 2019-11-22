using System;

namespace ConsoleApp1.models
{
    public class Button : IClickleable
    {
        public void Click()
        {
            Console.WriteLine("Click from Button");
        }
    }
}
