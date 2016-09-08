using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class MyStack
    {
        private List<Object> stackValues;

        public MyStack()
        {
            stackValues = new List<object>();
        }

        public bool isEmpty()
        {
            return !stackValues.Any();
        }
        public void Push(Object item)
        {
            stackValues.Add(item);
        }

        public Object Pop()
        {
            if (this.isEmpty())
            {
                Console.WriteLine("Stack is empty.");
            }
            else
            {
                Object o = stackValues[stackValues.Count() - 1];
                stackValues.RemoveAt(stackValues.Count() - 1);
                return o;
            }
            return null;
        }

        public Object Get(int index)
        {
            if ((index >= 0) && (index < stackValues.Count()))
            {
                return stackValues[index];
            }
            else
            {
                Console.Write("Index is out of bound.");
            }
            return null;
        }
    }
}
