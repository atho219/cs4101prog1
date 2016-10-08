// Lambda -- Parse tree node strategy for printing the special form lambda

using System;

namespace Tree
{
    public class Lambda : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Lambda() { }

        public override void print(Node t, int n, bool p)
        {
            if (!p)
            {
                Node.printIndent(n);
                Console.Write("(lambda");
                if (t.getCdr().isPair())
                {
                    Console.Write(' ');
                    Node.print(t.getCdr().getCar(), -(Math.Abs(n) + 4), false);
                    Console.WriteLine();
                    Node.printEnd(t.getCdr().getCdr(), Math.Abs(n) + 4);
                }
                else
                {
                    Node.printEnd(t.getCdr(), -(Math.Abs(n) + 4));
                    Console.WriteLine();
                }
            }
            else
                Node.print(t, n, true);
  	    }
    }
}

