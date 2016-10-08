// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Set() { }
	
        public override void print(Node t, int n, bool p)
        {
            if (!p)
            {
                Node.printIndent(n);
                Console.Write("(set!");
                // n negative to print on same line
                Node.printCdr(t.getCdr(), -(Math.Abs(n) + 4));
                Console.WriteLine();
            }
            else
                Node.print(t, n, true);
        }
    }
}

