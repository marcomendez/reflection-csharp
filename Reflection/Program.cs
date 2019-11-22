using Reflection.Controles;
using Reflection.View;
using System;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            ///*************** Execute Controls ************
            object[] parameters = new object[] { "Hello" };
            ExecuteMethod("TextBox", "SentText", parameters);

            ExecuteMethod("Button", "Click");
            ExecuteMethod("Link", "Click");

            ExecuteMethod("Button", "Message", parameters);

            parameters = new object[] { "Hello", "world" };
            ExecuteMethod("Button", "Message2", parameters);
           // Execute("Button");




            ///*/***************  Execute controls from views **************
            ExecuteClassAndMethodWithAlias("Login", "UserName", "SentText", parameters);





            Console.ReadLine();
        }

        private static void ExecuteMethod(string type, string methodName, object[] parameters = null)
        {
            // Get Assemble path
            var assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "\\" + Assembly.GetExecutingAssembly().GetName().Name + ".exe");

            // Get type control
            Type typeControl = assembly.GetType($"Reflection.Controles.{type}"); 

            // Instance the control
            dynamic control = Activator.CreateInstance(typeControl);

            // Execute method
            control.GetType().GetMethod(methodName).Invoke(control, parameters);
        }


        private static void ExecuteClassAndMethodWithAlias(string view, string control, string method, object[] parameters = null)
        {
            // Get Assemble path
            var assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "\\" + Assembly.GetExecutingAssembly().GetName().Name + ".exe");

            Type[] types = assembly.GetTypes();


            foreach(Type type in types)
            {
                ViewAlias attribute = (ViewAlias) type.GetCustomAttribute(typeof(ViewAlias));

                if(attribute?.Name == view)
                {
                    // Instance the control
                    Iview viewInstance = Activator.CreateInstance(type) as Iview;


                    //Get the control (class property)
                    var controlInstance = viewInstance.GetType().GetProperty(control);


                    dynamic controlOK = Activator.CreateInstance();


                    controlOK.GetType().GetMethod(method).Invoke(controlInstance, parameters);


                }
            }

     

        }



        private static void Execute(string type)
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
