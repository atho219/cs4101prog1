// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            if (!p)
            {
                Node.printIndent(n);
                Console.WriteLine("(begin");
                Node.printEnd(t.getCdr(), Math.Abs(n) + 4);
            }
            else
                Node.print(t, n, true);
        }
    }
}

