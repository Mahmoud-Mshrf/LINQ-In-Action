using _04_Shared;

namespace ProjectUsingSelect
{
    // Projection : refers to the operation of transforming an object into a new form that is going to be used 
    // - construct a new type 
    // - project a new property
    // - perform mathematical operation
    internal class Program
    {
        static void Main(string[] args)
        {
            RunExample01();
            RunExample02();
            RunExample03();
        }
        private static void RunExample01() // project a new property (uppercase of words)
        {
            List<string> words = new() { "mahmoud", "mshrf", "mogahed" };
            var result = words.Select(x => x.ToUpper());// extension method syntax
            var result01 = from word in words
                           select word.ToUpper(); // Query syntax
            foreach (var item in result01)
            {
                Console.WriteLine(item);
            }
        }

        private static void RunExample02() // mathematical operation
        {
            List<int> numbers = new() {1,2,3,4,5,6,7,8,9,10};
            var result = numbers.Select(x => x*x);// extension method syntax
            var result01 = from num in numbers
                           select num * num; // Query syntax
            foreach (var item in result01)
            {
                Console.WriteLine(item);
            }
        }

        private static void RunExample03() // construct new type
        {
            var employees = Repository.LoadEmployees();

            var result = employees.Select(x => new EmployeeDto { Name = x.FullName, CountOfSkills = x.Skills.Count });

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class EmployeeDto
    {
        public string Name { get; set; }
        public int CountOfSkills { get; set; }

        public override string ToString()
        {
            return $"Name : {Name} , has {CountOfSkills} skills";
        }
    }
}
