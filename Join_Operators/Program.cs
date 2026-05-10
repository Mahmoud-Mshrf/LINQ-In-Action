using _09_Shared;

namespace Join_Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();
            var departments = Repository.LoadDepartment();
            //JoinMethodSyntax(employees,departments);
            //JoinQuerySyntax(employees, departments);
            GroupJoinQuerySyntax(employees, departments);
        }

        private static void GroupJoinQuerySyntax(IEnumerable<Employee> employees, IEnumerable<Department> departments)
        {
            var result = from dept in departments
                         join emp in employees
                         on dept.Id equals emp.DepartmentId into empgroup
                         select new Group
                         {
                             DepartmentName = dept.Name,
                             Employees = empgroup.Select(x => x.FullName).ToList()
                         };
            foreach (var item in result)
            {
                Console.WriteLine($"* {item.DepartmentName} employees :\n");
                foreach (var emp in item.Employees)
                {
                    Console.WriteLine($"\t- {emp}");
                }
            }
        }

        private static void GroupJoin(IEnumerable<Employee> employees, IEnumerable<Department> departments)
        {
            var result = departments.GroupJoin(employees, dept => dept.Id, emp => emp.DepartmentId,
                (dept, emps) => new Group { DepartmentName = dept.Name, Employees = emps.Select(x => x.FullName).ToList() });
            foreach (var item in result)
            {
                Console.WriteLine($"* {item.DepartmentName} employees :\n");
                foreach (var emp in item.Employees)
                {
                    Console.WriteLine($"\t- {emp}");
                }
            }
        }

        private static void JoinMethodSyntax(IEnumerable<Employee> employees, IEnumerable<Department> departments)
        {
            // here i'm using anynmous object
            var result = employees.Join(departments, emp => emp.DepartmentId, dept => dept.Id,
                (emp, dept) => new { Department = dept.Name, EmployeeName = emp.FullName });

            foreach (var item in result)
            {
                Console.WriteLine($"{item.EmployeeName} works on {item.Department} department");
            }
        }
        private static void JoinQuerySyntax(IEnumerable<Employee> employees, IEnumerable<Department> departments)
        {
            // here i'm using EmployeeDepartmentDTO
            var result = from emp in employees
                         join dept in departments on emp.DepartmentId equals dept.Id
                         select new EmployeeDepartmentDTO { DepartmentName = dept.Name, EmployeeName = emp.FullName };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.EmployeeName} works on {item.DepartmentName} department");
            }
        }
    }
    public class EmployeeDepartmentDTO
    {
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
    }
    public class Group
    {
        public string DepartmentName { get; set; }
        public List<string> Employees { get; set; }
    }
}
