// Ident -- Parse tree node class for representing identifiers

using System;

namespace Tree
{
    public class Ident : Node
    {
        private string name;

        public Ident(string n)
        {
            name = n;
        }

        public override string getName()
        {
            return this.name;
        }

        public override bool isSymbol() { return true; }

        public override void print(int n)
        {
            printIndent(n);
            Console.Write(name);
            if (n >= 0)
                Console.WriteLine();
        }
    }
}

