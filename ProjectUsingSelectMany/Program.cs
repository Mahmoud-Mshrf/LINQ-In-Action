using _04_Shared;

namespace ProjectUsingSelectMany
{
    /*
     SelectMany in LINQ is used when each item in a collection produces another collection, and you want to flatten all results into a single sequence.

     🔹 Core Idea
     Select → 1 input item → 1 output item
     SelectMany → 1 input item → many output items → flattened
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            RunExample01();
            RunExample02();
        }

        private static void RunExample01()
        {
            List<string> strings = new() { "mahmoud mshrf mogahed", "mohamed ali hossam" };

            var result = strings.SelectMany(x => x.Split(" "));

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private static void RunExample02()
        {
            var employees = Repository.LoadEmployees();
            var result = employees.SelectMany(x => x.Skills).Distinct();

            var result01 = (from emp in employees
                           from skill in emp.Skills
                           select skill).Distinct();

            foreach (var item in result01)
            {
                Console.WriteLine(item);
            }
        }
    }

}
