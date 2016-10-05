// Parser -- the parser for the Scheme printer and interpreter
//
// Defines
//
//   class Parser;
//
// Parses the language
//
//   exp  ->  ( rest
//         |  #f
//         |  #t
//         |  ' exp
//         |  integer_constant
//         |  string_constant
//         |  identifier
//    rest -> )
//         |  exp+ [. exp] )
//
// and builds a parse tree.  Lists of the form (rest) are further
// `parsed' into regular lists and special forms in the constructor
// for the parse tree node class Cons.  See Cons.parseList() for
// more information.
//
// The parser is implemented as an LL(0) recursive descent parser.
// I.e., parseExp() expects that the first token of an exp has not
// been read yet.  If parseRest() reads the first token of an exp
// before calling parseExp(), that token must be put back so that
// it can be reread by parseExp() or an alternative version of
// parseExp() must be called.
//
// If EOF is reached (i.e., if the scanner returns a NULL) token,
// the parser returns a NULL tree.  In case of a parse error, the
// parser discards the offending token (which probably was a DOT
// or an RPAREN) and attempts to continue parsing with the next token.

using System;
using Tokens;
using Tree;

namespace Parse
{
    public class Parser {
	
        private Scanner scanner;

        public Parser(Scanner s) { scanner = s; }
  
        public Node parseExp()
        {
            // TODO: write code for parsing an exp
            return parseExp(scanner.getNextToken());
        }
  
        protected Node parseRest()
        {
            // TODO: write code for parsing a rest
            return parseRest(scanner.getNextToken());
        }

        // TODO: Add any additional methods you might need.

        public Node parseExp(Token tok)
        {
            if (tok == null)
                return null;
            else if(tok.getType() == TokenType.LPAREN)
            {
                return parseRest();
            }
            else if (tok.getType() == TokenType.TRUE)
                return BoolLit.getBool(true);                
            else if (tok.getType() == TokenType.FALSE)
                return BoolLit.getBool(false);
            else if (tok.getType() == TokenType.QUOTE)
                return new Cons(new Ident("quote"), new Cons(parseExp(), Nil.getNil()));
            else if (tok.getType() == TokenType.INT)
                return new IntLit(tok.getIntVal());
            else if (tok.getType() == TokenType.STRING)
                return new StringLit(tok.getStringVal());
            else if (tok.getType() == TokenType.IDENT)
                return new Ident(tok.getName());
            //if none of these, its dot or rparen, which should be impossible in exp
            return parseExp();
        }

        protected Node parseRest(Token tok)
        {
            if (tok == null)
                return null;
            else if (tok.getType() == TokenType.RPAREN)
            {
                return Nil.getNil();
            }
            else
            {
                return new Cons(parseExp(), parseNT());
            }
        }

        protected Node parseNT()
        {
            Token tok = scanner.getNextToken();
            if (tok.getType() == TokenType.DOT)
            {
                return new Cons(new )
            }
        }
        
    }
}

