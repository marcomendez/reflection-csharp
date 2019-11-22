using ConsoleApp1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "\\" + Assembly.GetExecutingAssembly().GetName().Name + ".exe");

            Type type = assembly.GetType("TextBox");
            object instance = Activator.CreateInstance(type);

            IClickleable clickleable = instance as IClickleable;
            clickleable.Click();
        }
    }
}
