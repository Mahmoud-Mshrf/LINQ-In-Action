using IEnumerable_VS_IQueryable_DataSource;
using System.Collections;

namespace IQueryable
{
    internal class Program
    {
        // IQueryable builds an expression tree that is translated into a query by the underlying provider (like EF Core) and executed on the data source, usually a database.
        // IEnumerable operates on in-memory collections using delegates, so filtering and processing happen in the application after data has been loaded.
        static void Main(string[] args)
        {
            var db = new BookContext();
            IQueryable<Book> books= db.Books;

            IQueryable<Book> booksOver50 = books.Where(x => x.Price > 50m);
            foreach (var item in booksOver50)
            {
                Console.WriteLine(item);
            }
        }
        /*
        IQueryable = translated to SQL (provider side)
         
        IQueryable<Book> books = dbContext.Books;
          
         - builds an expression tree
         - EF Core translates it to SQL
         - executed on database server
         */
    }
}
