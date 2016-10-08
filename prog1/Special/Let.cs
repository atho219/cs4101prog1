// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            if (!p)
            {
                Node.printIndent(n);
                Console.WriteLine("(let");
                Node.printEnd(t.getCdr(), Math.Abs(n) + 4);
            }
            else
                Node.print(t, n, true);
        }
    }
}


