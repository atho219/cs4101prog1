// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Define() { }

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
            if (!p)
            {
                Node.printIndent(n);
                Console.Write("(define");
                if (t.getCdr().isPair())
                {
                    if (t.getCdr().getCar().isPair())
                    {
                        Console.Write(' ');
                        Node.print(t.getCdr().getCar(), -(Math.Abs(n) + 4), false);
                        Console.WriteLine();
                        Node.printEnd(t.getCdr().getCdr(), Math.Abs(n) + 4);
                    }
                    else
                    {
                        Node.print(t.getCdr(), -(Math.Abs(n) + 4), true);
                        Console.WriteLine();
                    }
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


