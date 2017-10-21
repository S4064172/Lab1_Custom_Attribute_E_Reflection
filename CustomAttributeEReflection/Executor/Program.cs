using System;
using System.Reflection;
using System.Reflection.Metadata;
using MyLibrary;

namespace Executor
{
    class Program
    {
        public static void Wait()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Wait();

            CustomAttribute _customAttribute;
            CustomLibrary _customLibrary;

            var _listType = Assembly.LoadFrom("MyLibrary.dll");
            foreach (var type in _listType.GetTypes())
            {
                if(type.IsClass)
                    Console.WriteLine(type.FullName);
                Wait();
            }



        }
    }
}
