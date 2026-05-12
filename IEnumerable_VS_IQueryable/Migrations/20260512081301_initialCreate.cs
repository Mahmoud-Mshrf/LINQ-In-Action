using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IEnumerable_VS_IQueryable_DataSource.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", 550m, "Clean Code" },
                    { 2, "Jeffrey Richter", 750m, "CLR via C#" },
                    { 3, "Jon Skeet", 680m, "C# in Depth" },
                    { 4, "Gang of Four", 900m, "Design Patterns" },
                    { 5, "Andrew Hunt", 620m, "The Pragmatic Programmer" },
                    { 6, "Eric Freeman", 500m, "Head First Design Patterns" },
                    { 7, "Martin Fowler", 800m, "Refactoring" },
                    { 8, "Eric Evans", 950m, "Domain-Driven Design" },
                    { 9, "Robert Sedgewick", 720m, "Algorithms" },
                    { 10, "Thomas H. Cormen", 1100m, "Introduction to Algorithms" },
                    { 11, "Bill Wagner", 670m, "Effective C#" },
                    { 12, "Steve McConnell", 870m, "Code Complete" },
                    { 13, "John Sonmez", 450m, "Soft Skills" },
                    { 14, "Robert C. Martin", 530m, "The Clean Coder" },
                    { 15, "Michael Feathers", 990m, "Working Effectively with Legacy Code" },
                    { 16, "Martin Fowler", 1050m, "Patterns of Enterprise Application Architecture" },
                    { 17, "Andrew Lock", 780m, "ASP.NET Core in Action" },
                    { 18, "Joseph Rattz", 640m, "Pro LINQ" },
                    { 19, "Jon P Smith", 890m, "Entity Framework Core in Action" },
                    { 20, "Mark Seemann", 710m, "Dependency Injection Principles" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
