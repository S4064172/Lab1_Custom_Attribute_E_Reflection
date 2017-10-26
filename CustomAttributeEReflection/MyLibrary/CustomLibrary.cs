using System;
using MyAttribute;

namespace MyLibrary
{
    
    class MyClass1
    {
        private int _first;

        public MyClass1()
        {
            _first = 0;
        }

        [ExecuteMe(5)]
        [ExecuteMe(10)]
        public void Method1(int fisrt)
        {
            _first = fisrt;
            Console.WriteLine("Method1 : new value-->" + _first);
        }

        [ExecuteMe(20)]
        [ExecuteMe(30)]
        public void Method2(int fisrt)
        {
            _first += fisrt;
            Console.WriteLine("Method2 : new value-->" + _first);
        }

        //this method is visible only if u build this project
        [ExecuteMe(5)]
        public void Method3(int first)
        {
            _first *= first;
            Console.WriteLine("Method3 : new value-->" + _first);

        }
    }


    class MyClass2
    {
        private string _first;

        public MyClass2()
        {
            _first = null;
        }

        [ExecuteMe("_test1")]
        [ExecuteMe("_test2")]
        public void Method1(string fisrt)
        {
            _first = fisrt;
            Console.WriteLine("Method1 : new value-->" + _first);
        }

        [ExecuteMe("_test1")]
        [ExecuteMe("_test2","_test3")] //this attribute is not correct for this method because has 2 args
        public void Method2(string fisrt)
        {
            _first += " "+fisrt;
            Console.WriteLine("Method2 : new value-->" + _first);
        }
    }

    class MyClass3
    {
        private string _first;
        private int _a;
        private int _b;
        private string _second;
       
        [CustomConstructor("string",5,6,"string")]
        public MyClass3(string first, int a, int b = 5 ,string second = "second")
        {
            Console.WriteLine("yeah "+a);
            _first = first;
            _a = a;
            _b = b;
            _second = second;
        }

        [CustomConstructor("string")]
        public MyClass3(string first)
        {
            _first = first;
        }


        [ExecuteMe("_test1")]
        [ExecuteMe("_test2")]
        public void Method1(string fisrt)
        {
            _first += " "+fisrt;
            var t = new MyClass3("",5,second:"");
            Console.WriteLine("Method1 : new value-->" + _first+" "+_a+" "+_b+" "+_second+"");
        }
        
    }


}

