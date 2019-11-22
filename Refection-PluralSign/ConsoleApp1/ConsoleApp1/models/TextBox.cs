using System;

namespace ConsoleApp1.models
{
    public class TextBox : IClickleable
    {
        public void Click()
        {
            Console.WriteLine("Click from TextBox");
        }
    }
}
