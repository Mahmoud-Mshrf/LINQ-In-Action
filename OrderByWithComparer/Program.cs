using _05_Shared;

namespace OrderByWithComparer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();
            var orderedEmployees = employees.OrderBy(x=>x,new EmployeeComparer());
            orderedEmployees.Print("Ordered Employees");
        }
    }
    public class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee? e1, Employee? e2)
        {
            // EmployeeNo => 2014-HR-1434
            var e1Year = Convert.ToInt32(e1.EmployeeNo.Split("-")[0]);
            var e2Year = Convert.ToInt32(e2.EmployeeNo.Split("-")[0]);

            var e1Seq = Convert.ToInt32(e1.EmployeeNo.Split("-")[2]);
            var e2Seq = Convert.ToInt32(e2.EmployeeNo.Split("-")[2]);

            if (e1Year == e2Year)
            {
                return e1Seq.CompareTo(e2Seq);
            }
            else
                return e1Year.CompareTo(e2Year);

        }
    }
}
