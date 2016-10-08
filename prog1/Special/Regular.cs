// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {

        public Regular() { }

        public override void print(Node t, int n, bool p)
        {
            if (!p)
            {
                Node.printIndent(n);
                Console.Write('(');
                Node.print(t.getCar(), -(Math.Abs(n) + 4), false);
                Node.printEnd(t.getCdr(), -(Math.Abs(n) + 4));
                if (n >= 0)
                    Console.WriteLine();
            }
            else
            {
                if (n < 0)
                    Console.Write(' ');
                Node.print(t.getCar(), n, false);
                Node.printEnd(t.getCdr(), n);
            }
        }
    }
}


