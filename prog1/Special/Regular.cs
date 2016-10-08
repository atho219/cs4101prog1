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
                //indent and print (
                Node.printIndent(n);
                Console.Write('(');
                //print car node with proper print method, increment the indent parameter by 4
                //Negative & False: prints (, doesnt indent/doesnt newline after )
                //                  spaces if true reg
                Node.print(t.getCar(), -(Math.Abs(n) + 4), false);
                //print cdr, keep neg so it 
                // essentially printCdr handles ) and . exp ), which may have a newline and indent before it
                // checks if not cons to handle dots
                // n positive: go to next line and print reduced indent ) newline
                // n negative: print )
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


