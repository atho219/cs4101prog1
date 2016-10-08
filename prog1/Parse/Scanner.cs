// Scanner -- The lexical analyzer for the Scheme printer and interpreter

using System;
using System.IO;
using Tokens;

namespace Parse
{
    public class Scanner
    {
        private TextReader In;

        // maximum length of strings and identifier
        private const int BUFSIZE = 1000;
        private char[] buf = new char[BUFSIZE];

        public Scanner(TextReader i) { In = i; }
  
        // TODO: Add any other methods you need

        public Token getNextToken()
        {
            int ch;

            try
            {
                // It would be more efficient if we'd maintain our own
                // input buffer and read characters out of that
                // buffer, but reading individual characters from the
                // input stream is easier.
                ch = In.Read();

                // TODO: skip white space and comments :: DONE

                if (ch == -1)
                    return null;
                //ignore whitespace and new line characters
                //9 = tab, 12 = formfeed
                else if (ch == ' ' || ch == '\n' || ch == '\r' || ch == 9 || ch == 12)
                    return getNextToken();
                //ignore comments
                else if (ch == ';')
                {
                    In.ReadLine();
                    return getNextToken();
                }
                // Special characters
                else if (ch == '\'')
                    return new Token(TokenType.QUOTE);
                else if (ch == '(')
                    return new Token(TokenType.LPAREN);
                else if (ch == ')')
                    return new Token(TokenType.RPAREN);
                else if (ch == '.')
                    // We ignore the special identifier `...'.
                    return new Token(TokenType.DOT);

                // Boolean constants
                else if (ch == '#')
                {
                    ch = In.Read();

                    if (ch == 't')
                        return new Token(TokenType.TRUE);
                    else if (ch == 'f')
                        return new Token(TokenType.FALSE);
                    else if (ch == -1)
                    {
                        Console.Error.WriteLine("Unexpected EOF following #");
                        return null;
                    }
                    else
                    {
                        Console.Error.WriteLine("Illegal character '" +
                                                (char)ch + "' following #");
                        return getNextToken();
                    }
                }

                // String constants
                else if (ch == '"')
                {
                    // TODO: scan a string into the buffer variable buf :: DONE
                    int i = 0;
                    ch = In.Read();
                    while (ch != '"')
                    {
                        buf[i] = (char)ch;
                        ch = In.Read();
                        i++;
                    }
                    return new StringToken(new String(buf, 0, i));
                }


                // Integer constants
                else if (ch >= '0' && ch <= '9')
                {
                    int i = ch - '0';
                    // TODO: scan the number and convert it to an integer :: DONE
                    // make sure that the character following the integer
                    // is not removed from the input stream
                    while (In.Peek() >= '0' && In.Peek() <= '9')
                    {
                        ch = In.Read();
                        i = i * 10 + (ch - '0');
                    }


                    return new IntToken(i);
                }

                // Identifiers
                else if ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || ch == '!' || (ch >= '$' && ch <= '&') || ch == '*' || ch == '/' || ch == ':' || (ch >= '<' && ch <= '?') || ch == '^' || ch == '_' || ch == '~')
                // ch is a letter or ch is some other valid first character
                // for an identifier
                // Special initial idents: ! = 33, $ = 36, % = 37, & = 38, * = 42, / = 47, : = 58, < = 60, = = 61, > = 62, ? = 63, ^ = 94, _ = 95, ~ = 126
                // Special subsequent idents: + = 43, - = 45, . = 46, @ = 64
                {
                    // TODO: scan an identifier into the buffer :: DONE
                    // make sure that the character following the integer
                    // is not removed from the input stream
                    int i = 1;
                    Boolean isValidChar;
                    buf[0] = (char)ch;
                    do
                    {
                        ch = In.Peek();
                        if ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9') || ch == '!' || (ch >= '$' && ch <= '&') || ch == '*' || ch == '+' || (ch >= '-' && ch <= '/') || ch == ':' || (ch >= '<' && ch <= '@') || ch == '^' || ch == '_' || ch == '~')
                        {
                            isValidChar = true;
                            ch = In.Read();
                            //convert to lowercase
                            if (ch >= 'A' && ch <= 'Z') ch += 32;
                            buf[i] = (char)ch;
                            i++;
                        }
                        else isValidChar = false;
                    }
                    while (isValidChar);

                    return new IdentToken(new String(buf, 0, i));
                }

                //peculiar identifiers
                else if (ch == '+' || ch == '-')
                {
                    buf[0] = (char)ch;
                    return new IdentToken(new String(buf, 0, 1));
                }

                // Illegal character
                else
                {
                    Console.Error.WriteLine("Illegal input character '"
                                            + (char)ch + '\'');
                    return getNextToken();
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("IOException: " + e.Message);
                return null;
            }
        }
    }

}

