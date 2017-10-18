using System;
using MyAttribute;

namespace MyLibrary
{
    
    class myClass_1
    {
        private int _first;

        public myClass_1()
        {
            _first = 0;
            Console.WriteLine("new value-->" + _first);
        }

        [ExecuteMe(5)]
        [ExecuteMe(10)]
        public void Method1(int fisrt)
        {
            _first = fisrt;
            Console.WriteLine("new value-->" + _first);
        }

        [ExecuteMe(20)]
        [ExecuteMe(30)]
        public void Method2(int fisrt)
        {
            _first += fisrt;
            Console.WriteLine("new value-->" + _first);
        }
    }


    class myClass_2
    {
        private string _first;

        public myClass_2()
        {
            _first = null;
            Console.WriteLine("new value-->" + _first);
        }

        [ExecuteMe("_test1")]
        [ExecuteMe("_test2")]
        public void Method1(string fisrt)
        {
            _first = fisrt;
            Console.WriteLine("new value-->" + _first);
        }

        [ExecuteMe("_test1")]
        [ExecuteMe("_test2")]
        public void Method2(string fisrt)
        {
            _first += " "+fisrt;
            Console.WriteLine("new value-->" + _first);
        }
        

    }
}
