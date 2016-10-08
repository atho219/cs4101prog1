// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {

        public Regular() { }

        public override void print(Node t, int n, bool p)
        {
            Node.printIndent(n);
            if (!p)
                Console.Write('(');
            Node.print(t.getCar(), 0, false);
            Node.print(t.getCdr(), 1, true);
        }
    }
}


