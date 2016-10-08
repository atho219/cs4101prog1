// Nil -- Parse tree node class for representing the empty list

using System;

namespace Tree
{
    public class Nil : Node
    {
        public Nil() { }
  
        public override void print(int n)
        {
            print(n, false);
        }

        private static Nil nilInstance = new Nil();

        public static Nil getNil()
        {
            return nilInstance;
        }

        public override bool isNull() { return true; }

        public override void print(int n, bool p) {
            printIndent(n-4);
            if (p)
                Console.Write(")");
            else
                Console.Write("()");
        }
    }
}
