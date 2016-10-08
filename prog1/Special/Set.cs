// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Set() { }
	
        public override void print(Node t, int n, bool p)
        {
            Node.printIndent(n);
            if (!p)
                Console.Write("(set!");
            Node.print(t.getCar(), 0, false);
            Node.print(t.getCdr(), 1, true);
        }
    }
}

