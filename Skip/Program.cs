using _06_Shared;

namespace Skip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();

            var skipFirst10Elements = employees.Skip(10);
            skipFirst10Elements.Print("Employees without first 10 elements");

            var skipUntilYouFindEmployeeHasThisSalary = employees.SkipWhile(x=>x.Salary!=320_700); // after find this salary it will take any employee after it
            skipUntilYouFindEmployeeHasThisSalary.Print("employees after find employee his salary equal 320,700 $");

            var skipLast10Elements = employees.SkipLast(10);
            skipLast10Elements.Print("Employees without last 10 elements");

        }
    }
}
