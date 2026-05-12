using IEnumerable_VS_IQueryable_DataSource;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IEnumerable
{
    // IQueryable builds an expression tree that is translated into a query by the underlying provider(like EF Core) and executed on the data source, usually a database.
    // IEnumerable operates on in-memory collections using delegates, so filtering and processing happen in the application after data has been loaded.
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new BookContext();
            IEnumerable<Book> books = db.Books;

            IEnumerable<Book> booksOver50 = books.Where(x => x.Price >50m);
            foreach (var item in booksOver50)
            {
                Console.WriteLine(item);
            }

        }
        // IEnumerable :
        // once materialized, LINQ runs in memory
        // uses delegates, not expression trees
    }
}
