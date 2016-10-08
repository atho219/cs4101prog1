// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public If() { }

        public override void print(Node t, int n, bool p)
        {
            if (!p)
            {
                Node.printIndent(n);
                Console.Write("(if");
                if (t.getCdr().isPair())
                {
                    Console.Write(' ');
                    //print exp after if and its parentheses, n negative to print on same line
                    Node.print(t.getCdr().getCar(), -(Math.Abs(n) + 4), false);
                    //newline after car (conditional) printed
                    Console.WriteLine();
                    // increment, make sign bit positive because printing on a new line (indent -> print -> newline)
                    Node.printCdr(t.getCdr().getCdr(), Math.Abs(n) + 4);
                }
                else
                {
                    //if cdr is not a cons node, print with n negative on same line
                    Node.printCdr(t.getCdr(), -(Math.Abs(n) + 4));
                    Console.WriteLine();
                }
            }
            else
                Node.print(t, n, true);
        }
    }
}