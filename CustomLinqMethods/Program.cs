using _19_Shared;

namespace CustomLinqMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.Employees;
            employees.Paginate().Print("First Page 10 Employees");
            employees.Paginate2(1, 10, x => x.HasPensionPlan).Print("First page HasPensionPlan");
            Employee random = employees.Random(x => x.HasPensionPlan);
            Console.WriteLine("Random Employee With Pansion Plan");
            Console.WriteLine(random);
        }
    }
}
