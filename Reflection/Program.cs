using Reflection.Controles;
using Reflection.View;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            ///*************** Execute Controls ************
            object[] parameters = new object[] { " Hello" };
            ExecuteControl("TextBox", "SentText", parameters);

            ExecuteControl("Button", "Click");
            ExecuteControl("Link", "Click");

            ExecuteControl("Button", "Message", parameters);

           






            ///*/***************  Execute controls from views **************
            ExecuteClassAndMethodWithAlias("Login", "User Name", "SentText", parameters);

            ExecuteClassAndMethodWithAlias("Login", "User Name", "Click");

            var result = (int) ExecuteClassAndMethodWithAlias("Login", "Get Int", "GetInt");
            Console.WriteLine(result);


            parameters = new object[] { "Hello", "world" };
            ExecuteClassAndMethodWithAlias("Login", "Save", "Message2", parameters);
            Console.ReadLine();




            //parameters = new object[] { "Hello", "world" };
            //ExecuteMethod("Button", "Message2", parameters);
            // Execute("Button");
        }

        private static void ExecuteControl(string type, string methodName, object[] parameters = null)
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


        private static object ExecuteClassAndMethodWithAlias(string viewName, string controlName, string method, object[] parameters = null)
        {
            // Get Assemble path
            var assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + "\\" + Assembly.GetExecutingAssembly().GetName().Name + ".exe");

            Type[] types = assembly.GetTypes();

            foreach(Type type in types)
            {
                ViewAlias viewAlias = (ViewAlias) type.GetCustomAttribute(typeof(ViewAlias));

                if(viewAlias?.Name == viewName)
                {
                    // Instance the control
                    Iview viewInstance = Activator.CreateInstance(type) as Iview;

                    var properties = viewInstance.GetType().GetProperties();
                    return ExecuteProperty(controlName, method, parameters, viewInstance, properties);
                }
            }

            return null;
        }

        private static object ExecuteProperty(string controlName, string method, object[] parameters, Iview viewInstance, PropertyInfo[] properties)
        {
            foreach(var property in properties)
            {
                ControlAlias controlAlias = (ControlAlias) property.GetCustomAttribute(typeof(ControlAlias));
                if (controlAlias?.Name == controlName)
                {
                    Type propertyasa = property.PropertyType;
                    dynamic controlOK = Activator.CreateInstance(propertyasa);
                    return controlOK.GetType().GetMethod(method).Invoke(controlOK, parameters);
                }
            }
            return null;
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
