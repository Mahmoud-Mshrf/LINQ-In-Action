using _05_Shared;

namespace ThenBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();
            var orderedEmployees = employees.OrderBy(x => x.EmployeeNo).ThenBy(x => x.Name);
            employees.Print("Employees order by EmployeeNo then by EmployeeName");
        }
    }
}
