using _06_Shared;

namespace Pagination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emps = Repository.LoadEmployees();
            emps.ShowPaginate();
        }

        
    }
    public static class Extensions
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source , int page =1 , int size=10)
        {
            if (page <= 0)
                page = 1;
            if (size <= 0)
                size = 10;
            return source.Skip((page - 1) * size).Take(size);
            
        }
        public static void ShowPaginate<T>(this IEnumerable<T> source)
        {
            var page = 1;
            var size = 10;
            Console.WriteLine("Page size: ");
            if (int.TryParse(Console.ReadLine(), out int sizeResult))
            {
                size = sizeResult;
            }

            var NoPages = (int)Math.Ceiling((decimal)source.Count() / size);

            Console.WriteLine($"Page number: (from 1 to {NoPages})");
            if (int.TryParse(Console.ReadLine(), out int pageResult))
            {
                if (pageResult <= NoPages)
                    page = pageResult;
                else
                    page = NoPages;

            }
            var result = source.Paginate(page, size);
            var count = result.Count();

            var startRecord = (page * size) - size + 1;// or
            //var startRecord = (page - 1) * size + 1;

            var endRecord = startRecord + count - 1;

            result.Print($"Employees from {startRecord} to {endRecord}");
        }
    }
}
