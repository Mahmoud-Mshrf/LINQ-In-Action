using Microsoft.EntityFrameworkCore;

namespace IEnumerable_VS_IQueryable_DataSource
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new List<Book>
                {
                    new Book { Id = 1,  Title = "Clean Code",                   Author = "Robert C. Martin",   Price = 550m },
                    new Book { Id = 2,  Title = "CLR via C#",                   Author = "Jeffrey Richter",    Price = 750m },
                    new Book { Id = 3,  Title = "C# in Depth",                  Author = "Jon Skeet",          Price = 680m },
                    new Book { Id = 4,  Title = "Design Patterns",              Author = "Gang of Four",       Price = 900m },
                    new Book { Id = 5,  Title = "The Pragmatic Programmer",     Author = "Andrew Hunt",        Price = 620m },
                    new Book { Id = 6,  Title = "Head First Design Patterns",   Author = "Eric Freeman",       Price = 500m },
                    new Book { Id = 7,  Title = "Refactoring",                  Author = "Martin Fowler",      Price = 800m },
                    new Book { Id = 8,  Title = "Domain-Driven Design",         Author = "Eric Evans",         Price = 950m },
                    new Book { Id = 9,  Title = "Algorithms",                   Author = "Robert Sedgewick",   Price = 720m },
                    new Book { Id = 10, Title = "Introduction to Algorithms",   Author = "Thomas H. Cormen",  Price = 1100m },
                    new Book { Id = 11, Title = "Effective C#",                 Author = "Bill Wagner",        Price = 670m },
                    new Book { Id = 12, Title = "Code Complete",                Author = "Steve McConnell",    Price = 870m },
                    new Book { Id = 13, Title = "Soft Skills",                  Author = "John Sonmez",        Price = 450m },
                    new Book { Id = 14, Title = "The Clean Coder",              Author = "Robert C. Martin",   Price = 530m },
                    new Book { Id = 15, Title = "Working Effectively with Legacy Code", Author = "Michael Feathers", Price = 990m },
                    new Book { Id = 16, Title = "Patterns of Enterprise Application Architecture", Author = "Martin Fowler", Price = 1050m },
                    new Book { Id = 17, Title = "ASP.NET Core in Action",       Author = "Andrew Lock",        Price = 780m },
                    new Book { Id = 18, Title = "Pro LINQ",                     Author = "Joseph Rattz",       Price = 640m },
                    new Book { Id = 19, Title = "Entity Framework Core in Action", Author = "Jon P Smith",    Price = 890m },
                    new Book { Id = 20, Title = "Dependency Injection Principles", Author = "Mark Seemann",   Price = 710m }
                });
        }
    }

}
