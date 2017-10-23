using System;


namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = true)]
    public class ExecuteMeAttribute : Attribute
    {
        private object[] _myParams;

        public ExecuteMeAttribute(params object[] parm)
        {
           _myParams = parm;
        }

        public object[] GetParams()
        {
            return _myParams;
        }
    }


    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false)]
    public class CustomConstructorAttribute : Attribute
    {
        private object[] _myParams;

        public CustomConstructorAttribute(params object[] parm)
        {
            _myParams = parm;
        }

        public object[] GetParams()
        {
            return _myParams;
        }

    }
}
