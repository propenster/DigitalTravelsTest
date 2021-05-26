using System;
using System.Collections.Generic;

namespace MyAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Queue<int> myIntQueue = new Queue<int>( );
            myIntQueue.Enqueue(1);
            myIntQueue.Enqueue(2);
            myIntQueue.Enqueue(4);
            Console.WriteLine("And the Queue peeked has : " + myIntQueue.Peek());
        }
    }
}
