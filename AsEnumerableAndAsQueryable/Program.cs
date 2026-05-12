using IEnumerable_VS_IQueryable_DataSource;
using Test_Shared;

namespace AsEnumerableAndAsQueryable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EnumerableToQueryable();
            QueryableToEnumerable();

        }

        private static void QueryableToEnumerable()
        {
            var db = new BookContext();
            IQueryable<Book> books = db.Books;
            var query = books.AsEnumerable().Where(b => b.Price > 50);
            /*
             * AsEnumerable() : “Treat this as in-memory collection (LINQ to Objects)”
             Before AsEnumerable() → SQL
             After AsEnumerable() → C# memory filtering
             */
            foreach (var b in query)
            {
                Console.WriteLine(b.Title);
            }//👉 NOW execution happens
        }

        private static void EnumerableToQueryable()
        {
            var db = new BookContext();
            IEnumerable<Book> books = db.Books;
            var query = books.AsQueryable().Where(b => b.Price > 50);
            /*
             🧠 What happens here?
             ✔ Step 1
             
             AsQueryable():
             
             wraps the collection
             enables expression tree building
             ✔ Step 2
             
             Where(...):
             
             NOT executed yet
             stored as expression
             ✔ Step 3
             
             Iteration:
             */
            foreach (var b in query)
            {
                Console.WriteLine(b.Title);
            }//👉 NOW execution happens
        }
    }
}
