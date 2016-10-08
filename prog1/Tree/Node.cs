// Node -- Base class for parse tree node objects

using System;

namespace Tree
{
    public class Node
    {
        // The argument of print(int) is the number of characters to indent.
        // Every subclass of Node must implement print(int).
        public virtual void print(int n) { }
        public static void printIndent(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write(" ");
        }

        public static void printEnd(Node t, int n)
        {
            if (t.isNull() || t.isPair())
                print(t, n, true);
            else
            {
                if (n >= 0)
                    printIndent(n);
                else
                    Console.Write(' ');
                Console.Write(". ");
                print(t, -Math.Abs(n), false);
                if (n >= 0)
                {
                    Console.WriteLine();
                    printIndent(n - 4);
                }
                Console.Write(')');
                if (n >= 0)
                    Console.WriteLine();
            }

        }
        // The first argument of print(int, bool) is the number of characters
        // to indent.  It is interpreted the same as for print(int).
        // The second argument is only useful for lists (nodes of classes
        // Cons or Nil).  For all other subclasses of Node, the boolean
        // argument is ignored.  Therefore, print(n,p) defaults to print(n)
        // for all classes other than Cons and Nil.
        // For classes Cons and Nil, print(n,TRUE) means that the open
        // parenthesis was printed already by the caller.
        // Only classes Cons and Nil override print(int, bool).
        // For correctly indenting special forms, you might need to pass
        // additional information to print.  What additional information
        // you pass is up to you.  If you only need one more bit, you can
        // encode that in the sign bit of n. If you need additional parameters,
        // make sure that you define the method print in all the appropriate
        // subclasses of Node as well.
        public virtual void print(int n, bool p)
        {
            print(n);
        }

        public static void print(Node t, int n, bool p)
        {
            t.print(n, p);
        }

        // For parsing Cons nodes, for printing trees, and later for
        // evaluating them, we need some helper functions that test
        // the type of a node and that extract some information.

        // TODO: implement these in the appropriate subclasses to return true :: DONE
        public virtual bool isBool()   { return false; }  // BoolLit
        public virtual bool isNumber() { return false; }  // IntLit
        public virtual bool isString() { return false; }  // StringLit
        public virtual bool isSymbol() { return false; }  // Ident
        public virtual bool isNull()   { return false; }  // Nil
        public virtual bool isPair()   { return false; }  // Cons

        public virtual string getName() { return ""; }

        // TODO: Report an error in these default methods and implement them
        // in class Cons.  After setCar, a Cons cell needs to be `parsed' again
        // using parseList. :: DONE
        public virtual Node getCar()
        {
            Console.Error.WriteLine("Cant get car if not cons node");
            return null;
        }
        public virtual Node getCdr()
        {
            Console.Error.WriteLine("Cant get cdr if not cons node");
            return null;
        }
        public virtual void setCar(Node a)
        {
            Console.Error.WriteLine("Cant set car if not cons node");
        }
        public virtual void setCdr(Node d)
        {
            Console.Error.WriteLine("Cant set cdr if not cons node");
        }
    }
}

