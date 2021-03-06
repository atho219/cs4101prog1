// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree
{
    public class Cond : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Cond() { }

        public override void print(Node t, int n, bool p)
        {
            if (!p)
            {
                Node.printIndent(n);
                Console.WriteLine("(cond");
                // make n positive for printing on new line
                Node.printCdr(t.getCdr(), Math.Abs(n) + 4);
            }
            else
                Node.print(t, n, true);
        }
    }
}


