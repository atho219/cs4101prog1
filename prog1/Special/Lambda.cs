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
                    // negative n to print on same line
                    Node.print(t.getCdr().getCar(), -(Math.Abs(n) + 4), false);
                    Console.WriteLine();
                    // positive n because its on a new line
                    Node.printCdr(t.getCdr().getCdr(), Math.Abs(n) + 4);
                }
                else
                {
                    // if not cons, handle dot/nil. n negative to print on same line
                    Node.printCdr(t.getCdr(), -(Math.Abs(n) + 4));
                    Console.WriteLine();
                }
            }
            else
                Node.print(t, n, true);
  	    }
    }
}