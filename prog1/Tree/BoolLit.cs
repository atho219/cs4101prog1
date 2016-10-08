// BoolLit -- Parse tree node class for representing boolean literals

using System;

namespace Tree
{
    public class BoolLit : Node
    {
        private bool boolVal;        
  
        public BoolLit(bool b)
        {
            boolVal = b;
        }

        private static BoolLit boolTrue = new BoolLit(true);
        private static BoolLit boolFalse = new BoolLit(false);
        
        public static BoolLit getBool(bool bVal)
        {
            if (bVal)
                return BoolLit.boolTrue;
            else
                return BoolLit.boolFalse;
        }

        public override bool isBool() { return true; }

        public override void print(int n)
        {
            printIndent(n);
            if (boolVal)
                Console.Write("#t");
            else
                Console.Write("#f");
            if (n >= 0)
                Console.WriteLine();
        }
    }
}
