using _07_Shared;

namespace Quantifiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var emps = Repository.LoadEmployees();
            // Any
            bool result1 = emps.Any(x => x.Salary > 20000);// true if there is any employee his salary more than 20000
            bool result2 = emps.Any(x => x.Skills.Count == 1);// true if there is any employee has only one skill
            bool result3 = emps.Any(x => x.Name.Contains("AA"));// true if there is any employee that his name contains 'AA'
            // any query syntax
            // Any with query syntax return the employees there hava C# in their skills
            var result00 = from employee in emps
                          where employee.Skills.Any(s => s == "C#")
                          select employee;
            var result01 = from employee in emps
                          where employee.Skills.Any(s => s.Length >= 3)// return employees with skills have more than 3 characters
                          select employee;
            // All
            bool result4 = emps.All(x => x.Salary > 1000);// true if all employees have salary more than 1000
            bool result5 = emps.All(x => x.Skills.Count >= 1);// true if all employees have more than one skill
            // Contains:
            // contains check if the list or string have an item 
            // it can be instance method if it applied to string ,
            // can be extension method if it applied to list and its complexity will be high except if we use hashset (ovveride equality methods)
            // determines whether there are an employee have "ee" in his name
            var result9 = emps.Any(e => e.Name.Contains("ee")); // here it instance method
            var e = new Employee { Email = "Cole.Cochran01@example.com" };
            var result10 = emps.Contains(e);
            // it will return false although there are an employee have the same email but it return false,
            // because it a reference type must ovveride equality methods to compare valuse not references
            // if we ovveride it will return true
            Console.WriteLine(result10);// true because we override equality
        }
    }
}
