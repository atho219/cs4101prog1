// BoolLit -- Parse tree node class for representing boolean literals

using System;

namespace Tree
{
    public class BoolLit : Node
    {
        private bool boolVal;

        private static BoolLit boolTrue = new BoolLit(true);
        private static BoolLit boolFalse = new BoolLit(false);
  
        public BoolLit(bool b)
        {
            boolVal = b;
        }

        public static BoolLit getBool(bool value)
        {
            if (value)
                return BoolLit.boolTrue;
            else
                return BoolLit.boolFalse;
        }

        public override bool isBool() { return true; }

        public override void print(int n)
        {
	    // There got to be a more efficient way to print n spaces.
	    for (int i = 0; i < n; i++)
                Console.Write(" ");

            if (boolVal)
                Console.WriteLine("#t");
            else
                Console.WriteLine("#f");
        }
    }
}
