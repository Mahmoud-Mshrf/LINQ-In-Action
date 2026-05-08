namespace StatementVsExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Statement: is an instruction that performs an action 
            // examples 
            // declaration statement:
            int x;
            // assignment statement:
            x = 0;
            // declare and initialization statement
            int y = 0;
            // for , foreach , do-while , while , if , if-else , switch statement 
            // all of these performs an action then it's statement
            // --------------------------------------

            // Expression: is a code that produces a value
            // x + y;      // expression returns sum of two numbers
            // method invokation // produce method return value 
            // object creation 
            // --------------------------------------

            // switch statemnt Vs switch expression :
            string name;
            x = 0;
            // switch statement
            switch (x)
            {
                case 1:
                    name = "a";
                    break;
                case 2:
                    name = "b";
                    break;
                case 3:
                    name = "c";
                    break;
                default:
                    name = "z";
                    break;
            }
            // switch expression
            name = x switch
            {
                1 => "a",
                2 => "b",
                3 => "c",
                _ => "z",
            };

            // --------------------------------------
            /*
             🔹 Statements Categories
                Examples:

                  if
                  for
                  foreach
                  while
                  return
                  break
                  declaration statements

             🔹 Expression Categories
                Examples:
                
                  literals
                  arithmetic
                  method calls
                  lambda expressions
                  object creation
                  comparisons
             */

        }
    }
}
