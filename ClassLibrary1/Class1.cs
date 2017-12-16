using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Demo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("this is a placeholder");
            Console.ReadKey(true);
        }
    }
    public class AnotherClass
    {
        string message;
        public AnotherClass(string str)
        {
            message = str;
        }
        public AnotherClass()
        {

        }
        public static void ShowStatic()
        {
            Console.WriteLine("static");
        }
        public void ShowMessage()
        {
            Console.WriteLine("hello");
        }
        public string Show()
        {
            return message;
        }
    }
    internal class MyClass
    {
        int i, j;
        public MyClass(int i = 0)
        {
            this.i = j = i;
        }
        public MyClass()
        {

        }
        public MyClass(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
        private Boolean isbetween(int v)
        {
            return v >= i && v <= j;
        }
        public int sum()
        {
            return i + j;
        }
        public void show()
        {
            Console.WriteLine("{0} and {1}", i, j);
        }
        public static void Work(int i)
        {
            Console.WriteLine("Doing work {0}", i);
        }

    }
}
