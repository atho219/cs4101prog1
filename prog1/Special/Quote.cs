// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree
{
    public class Quote : Special
    {
        // TODO: Add any fields needed.
  
        // TODO: Add an appropriate constructor.
	public Quote() { }

        public override void print(Node t, int n, bool p)
        {
            if (!p)
            {
                //if (t.getCdr().isPair())
                Node.printIndent(n);
                Console.Write('\'');
                // negative n to print on same line, add 1 to account for ' before (
                Node.print(t.getCdr().getCar(), -(Math.Abs(n) + 1), false);
                if (n >= 0)
                    Console.WriteLine();
            }
            else
                Node.print(t, n, true);
        }
    }
}

