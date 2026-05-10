namespace DeferredExecution_Vs_ImmediateExecution
{
    // Deferred Execution : The query is defined but NOT executed until you actually iterate over it.
    /*
     Execution is delayed until:

     foreach
     .ToList()
     .Count()
     .First()
     */

    // Immediate Execution : The query is executed immediately and results are stored
    /*
     methods force execution like:

     ToList()
     ToArray()
     Count()
     First()
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            // deferred execution :
            var result = numbers.Where(x => x % 2 == 0);
            /*
             LINQ does NOT store the final filtered data immediately.
             Instead, it stores:
             
             reference to the source (numbers)
             the query logic/predicate (x => x % 2 == 0)
             
             Then when iteration happens:
             */
            foreach (var x in result)
            {
                Console.WriteLine(x);
            }
            /*
             LINQ executes the query at that moment using the CURRENT state of numbers.
             So modifications before iteration affect the result.
             */
            // ---------------------------------------------------------
            // Immediate Execution :
            var result02 = numbers.Where(x => x % 2 == 0).ToList();
            /*
             ToList() forces LINQ to:

             execute immediately
             evaluate all items now
             store the results in a new collection
             
             After that:
             
             result becomes independent from future changes in numbers
             */
        }
    }
}
