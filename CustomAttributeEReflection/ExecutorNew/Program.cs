using System;
using System.Diagnostics;
using System.Reflection;
using MyAttribute;
    

namespace ExecutorNew
{
    class Program
    {
        public static void Wait()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void Main()
        {
            Console.WriteLine("Hello World!");
            Wait();

           
            var listType = Assembly.LoadFrom("MyLibrary.dll");
            
            foreach (var type in listType.GetTypes())
            {
                if (type.IsClass)
                    Console.WriteLine("This class is this project-->" + type.FullName);
            }

            Wait();

            foreach (var typeClass in listType.GetTypes())
            {
                Console.WriteLine("processing class-->"+typeClass);
                if (typeClass.IsClass)
                    foreach (var typeMethod in typeClass.GetMethods())
                    {
                        if (!typeMethod.IsPublic)
                            continue;
                        foreach (var typeAttribute in typeMethod.GetCustomAttributes<ExecuteMeAttribute>())
                        {
                            try
                            {
                                typeMethod.Invoke(Activator.CreateInstance(typeClass), typeAttribute.GetParams());
                            }
                            catch (Exception e)
                            {
                                Debug.WriteLine(e.Message);
                                Console.WriteLine("Cannot invoke {0} method",typeMethod.Name);
                            }

                        }
                    }
                Wait();
            }

        }
    }
}
