using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
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
                            catch (TargetParameterCountException e)
                            {
                                Debug.WriteLine(e.Message);
                                Console.WriteLine("Cannot invoke {0} method because the arguments does not match with attribute's arguments {1}", typeMethod.Name,e.GetType());
                            }
                            catch (MissingMethodException e1)
                            {
                                Debug.WriteLine(e1.Message);
                                Console.WriteLine("Cannot invoke {0} method because the default constructor is absent {1}",typeMethod.Name,e1.GetType());
                               
                                foreach (var typeConstructors in typeClass.GetConstructors())
                                {
                                    foreach (var typeConstructorAttribute in typeConstructors.GetCustomAttributes<CustomConstructorAttribute>())
                                    {
                                        Console.Write("\nDo you want use this constructor : ");
                                        foreach (var param in typeConstructors.GetParameters())
                                        {
                                            Console.Write(param.ParameterType + " ");
                                            /*Console.WriteLine(string.Format("Param {0} is named {1} and is of type {2}",
                                                param.Position, param.Name, param.ParameterType));*/
                                        }
                                        Console.Write("?[y][any other key] \n ->>");
                                        var key = Console.ReadKey().KeyChar;
                                        if (key == 'y')
                                        {
                                            int index = typeConstructors.GetParameters().Length;
                                            object[] att = new object[index];
                                            for (var i = 0; i < index; i++)
                                            {
                                                Console.Write("\ninsert element of type {0} -->", typeConstructors.GetParameters()[i].ParameterType);
                                                att[i] = Convert.ChangeType(Console.ReadLine(), typeConstructors.GetParameters()[i].ParameterType);
                                            }
                                            typeMethod.Invoke(typeConstructors.Invoke(att), typeAttribute.GetParams());
                                            goto executeContructor;
                                        }
                                        
                                    }

                                }
                                executeContructor:;
                            }

                        }
                    }
              
                Wait();
            }

        }
    }
}
