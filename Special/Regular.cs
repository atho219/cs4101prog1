// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {

        public Regular() { }

        public override void print(Node t, int n, bool p)
        {
            //if ( hasnt been printed yet
            if (!p)
            {
                Node.printIndent(n);
                Console.Write('(');
                //print car node, increment the indent parameter by 4 to keep track of parens/indentation
                //negative n to print on same line without indenting or ending the line after
                Node.print(t.getCar(), -(Math.Abs(n) + 4), false);
                //n negative to print the cdr on same line
                Node.printCdr(t.getCdr(), -(Math.Abs(n) + 4));
                if (n >= 0)
                    Console.WriteLine();
            }
            else
            {
                if (n < 0)
                    Console.Write(' ');
                Node.print(t.getCar(), n, false);
                Node.printCdr(t.getCdr(), n);
            }
        }
    }
}


