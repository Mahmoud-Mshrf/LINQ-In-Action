using _06_Shared;

namespace Take
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();

            var First10Elements = employees.Take(10);
            First10Elements.Print("first 10 elements");

            var takeUntilYouFindEmployeeHasThisSalary = employees.TakeWhile(x => x.Salary != 320700); // after find this salary it will stop taking any employee after it
            takeUntilYouFindEmployeeHasThisSalary.Print("employees before find employee his salary equal 320,700 $");

            var Last10Elements = employees.TakeLast(10);
            Last10Elements.Print(" last 10 elements");

        }
    }
}
