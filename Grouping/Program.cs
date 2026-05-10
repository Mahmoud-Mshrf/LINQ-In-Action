using _08_Shared;

namespace Grouping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emps = Repository.LoadEmployees();
            GroupByMethod(emps);
            GroupByQuery(emps);
            ToLookUp(emps);
        }

        private static void ToLookUp(IEnumerable<Employee> emps)
        {
            var groups = emps.ToLookup(x => x.Department); // Immediate execution
            foreach (var group in groups)
            {
                group.Print($"Employees in {group.Key} Department");
            }
        }

        private static void GroupByQuery(IEnumerable<Employee> emps)
        {
            // deffered execution
            var groups = from emp in emps
                         group emp by emp.Department;
            foreach (var group in groups)
            {
                group.Print($"Employees in {group.Key} Department");
            }
        }

        private static void GroupByMethod(IEnumerable<Employee> emps)
        {
            // deffered execution
            var groups = emps.GroupBy(x => x.Department);
            foreach (var group in groups)
            {
                group.Print($"Employees in {group.Key} Department");
            }
        }
    }
}
