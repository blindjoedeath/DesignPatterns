using System;

namespace Patterns.Singelton
{
    public class Application
    {
        private static Application _application;
        public static Application Instance
        {
            get
            {
                return _application;
            }
        }

        static Application()
        {
            Console.WriteLine("Static initialization");
            _application = new Application();
        }

        public void Run()
        {
            Console.WriteLine("Stated single application");
        }

        public void Close()
        {
            Console.WriteLine("Closed single application");
        }
    }
}
