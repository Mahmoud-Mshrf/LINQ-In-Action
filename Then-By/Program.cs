using _05_Shared;

namespace Then_By
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();
            var orderedEmployees01 = employees.OrderBy(x => x.Name).ThenBy(x => x.Salary);
            orderedEmployees01.Print("Employees order by EmployeeName then by EmployeeSalary");

            var orderedEmployees02 = employees.OrderBy(x => x.Name).ThenByDescending(x => x.Salary);
            orderedEmployees02.Print("Employees order by EmployeeName Ascending then by EmployeeSalary Descending");
        }
    }
}
