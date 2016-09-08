using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack myStack = new MyStack();
            myStack.Push("3");
            myStack.Push("2");
            myStack.Push("6");
            myStack.Push("7");
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Get(0));
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Pop());
            Console.Read();
        }
    }
}
