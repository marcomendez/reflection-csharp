using Reflection.Controles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {

            //ExecuteMethod("Button", "Click");
            //ExecuteMethod("Link", "Click");

            object[] parameters = new object[] { "Hello" };
            //ExecuteMethod("Button", "Message", parameters);

            parameters = new object[] { "Hello", "world" };
            xx("Button");

            Console.ReadLine();
        }

        private static void ExecuteMethod(string type, string methodName, object[] parameters = null)
        {
            // Get Assemble path
            var assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "\\" + Assembly.GetExecutingAssembly().GetName().Name + ".exe");

            // Get type control
            Type typeControl = assembly.GetTypes().Where(t => t.Name.Equals(type)).First(); 

            // Instance the control
            dynamic control = Activator.CreateInstance(typeControl);

            // Execute method
            control.GetType().GetMethod(methodName).Invoke(control, parameters);
        }


        private static void xx(string type)
        {
            // Get Assemble path
            var assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "\\" + Assembly.GetExecutingAssembly().GetName().Name + ".exe");

            // Get type control
            Type typeControl = assembly.GetTypes().Where(t => t.Name.Equals(type)).First();

            foreach (var t in assembly.GetTypes())
            {
                //get test method in types.
                var testMethods = t.GetMethods();

                foreach (var method in testMethods)
                {
                    MethodInfo methodInfo = t.GetMethod(method.Name);

                    if (methodInfo != null)
                    {
                        object result = null;
                        ParameterInfo[] parameters = methodInfo.GetParameters();
                        object classInstance = Activator.CreateInstance(type, null);

                        if (parameters.Length == 0)
                        {
                            // This works fine
                            result = methodInfo.Invoke(classInstance, null);
                        }
                        else
                        {
                            object[] parametersArray = new object[] { "Hello" };

                            // The invoke does NOT work;
                            // it throws "Object does not match target type"             
                            result = methodInfo.Invoke(classInstance, parametersArray);
                        }
                    }

                }
            }
        }
    }
}
