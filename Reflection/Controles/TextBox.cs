using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Controles
{
   public class TextBox : ControlBase
    {
        public void SentText(string message)
        {
            Console.WriteLine("menssage from text box" +  message);
        }

        public void Click()
        {
            Console.WriteLine("click from Textbox ");
        }

        public int GetInt()
        {
            return 100;
        }
    }
}
