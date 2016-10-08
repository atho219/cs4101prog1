// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Define() { }

        //cons print overridden by define print because it starts with a special
        public override void print(Node t, int n, bool p)
        {
            if (!p)
            {
                Node.printIndent(n);
                //Manually printing ( and car
                Console.Write("(define");
                //if cdr of cons node (everything after define) is another cons node
                if (t.getCdr().isPair())
                {
                    //check if its t.cdr.car (item after define) is a cons node, if so print it, newline, print the rest
                    if (t.getCdr().getCar().isPair())
                    {
                        Console.Write(' ');
                        //n negative to print on same line
                        Node.print(t.getCdr().getCar(), -(Math.Abs(n) + 4), false);
                        Console.WriteLine();
                        //n positive because printing on new line
                        Node.printCdr(t.getCdr().getCdr(), Math.Abs(n) + 4);
                    }
                    //if its not a cons node print the whole thing and then newline after )
                    else
                    {
                        //n negative to print items on same line with a space between
                        Node.print(t.getCdr(), -(Math.Abs(n) + 4), true);
                        Console.WriteLine();
                    }
                }
                else
                {
                    //if not another cons node, dot or nil. negative n so that it wont indent or make a new line
                    Node.printCdr(t.getCdr(), -(Math.Abs(n) + 4));
                    Console.WriteLine();
                }
            }
            else
                Node.print(t, n, true);
        }
    }
}


