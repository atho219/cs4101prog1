// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Define() { }

        //cons print overridden by define print because it starts with a special. t = cons node, n = spaces to indent, p if ( already
        public override void print(Node t, int n, bool p)
        {
            /*
            Node.printIndent(n);
            if (!p)
            {
                Console.Write("(define ");
                Node cdr = t.getCdr();
                if (cdr.isPair())
                {
                    Node car = cdr.getCar();
                    if (car.isPair())
                    {
                        Node.print(car, 0, false);
                        Console.WriteLine();
                        Node.print(cdr, n + 4, true);
                    }
                    else
                    {
                        Node.print(cdr, 0, true);
                        Console.WriteLine();
                    }

                }
            }
            Node.print(t.getCdr(), 0, false);
            Node.print(t.getCdr(), 1, true);
            */
            //if ( hasnt been printed yet
            if (!p)
            {
                //print specified indent before (
                Node.printIndent(n);
                //prints L paren and car of cons node
                Console.Write("(define");
                //if cdr of cons node (everything after define) is another cons node
                if (t.getCdr().isPair())
                {
                    //check if car of everything after define is a cons node, aka check if function define rather than variable definition
                    if (t.getCdr().getCar().isPair())
                    {
                        Console.Write(' ');
                        //print 1 space then let the cons node print itself as the correct type, then add 4 to indent, tell the node to print (
                        // n negative to not print ' ' and to end line after
                        Node.print(t.getCdr().getCar(), -(Math.Abs(n) + 4), false);
                        Console.WriteLine();
                        Node.printCdr(t.getCdr().getCdr(), Math.Abs(n) + 4);
                    }
                    //if its not a cons node, let it call its own print method and then go to next line
                    else
                    {
                        Node.print(t.getCdr(), -(Math.Abs(n) + 4), true);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Node.printCdr(t.getCdr(), -(Math.Abs(n) + 4));
                    Console.WriteLine();
                }
            }
            else
                Node.print(t, n, true);
        }
    }
}


