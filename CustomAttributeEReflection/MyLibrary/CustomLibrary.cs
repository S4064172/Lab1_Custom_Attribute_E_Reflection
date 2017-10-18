using System;
using MyAttribute;

namespace MyLibrary
{
    public class CustomLibrary
    {

        class myClass_1
        {
            private int _first;

            myClass_1()
            {
                _first = 0;
                Console.WriteLine("new value-->" + _first);
            }

            [ExecuteMe("test1","reflection","ready","relace")]
            [ExecuteMe("test2", "reflection", "ready", "relace")]
            public void Method1(int fisrt)
            {
                _first = fisrt;
                Console.WriteLine("new value-->" + _first);
            }

            [ExecuteMe("test1", "reflection", "ready","add")]
            [ExecuteMe("test2", "reflection", "ready", "add")]
            public void Method2(int fisrt)
            {
                _first += fisrt;
                Console.WriteLine("new value-->" + _first);
            }
        }


        class myClass_2
        {
            private string _first;

            myClass_2()
            {
                _first = null;
                Console.WriteLine("new value-->" + _first);
            }

            [ExecuteMe("test1", "reflection", "ready", "relace")]
            [ExecuteMe("test2", "reflection", "ready", "relace")]
            public void Method1(string fisrt)
            {
                _first = fisrt;
                Console.WriteLine("new value-->" + _first);
            }

            [ExecuteMe("test1", "reflection", "ready", "add")]
            [ExecuteMe("test2", "reflection", "ready", "add")]
            public void Method2(string fisrt)
            {
                _first += " "+fisrt;
                Console.WriteLine("new value-->" + _first);
            }
        }

    }
}
