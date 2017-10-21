using System;
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
                    Console.WriteLine(type.FullName);
                Wait();
            }

            Wait();

            foreach (var typeClass in listType.GetTypes())
            {
                if (typeClass.IsClass)
                    foreach (var typeMethod in typeClass.GetMethods())
                    {
                        if (!typeMethod.IsPublic)
                            continue;
                        foreach (var typeAttribute in typeMethod.GetCustomAttributes<ExecuteMeAttribute>())
                        {
                            typeMethod.Invoke(Activator.CreateInstance(typeClass), typeAttribute.GetParams());
                            Wait();
                        }
                    }
                Wait();
            }

        }
    }
}
