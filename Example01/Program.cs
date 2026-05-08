using _03_Shared;

namespace Example01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();

            // first way using filter 
            var femalesWithNamesStartingWithS = employees.
                Filter(e => e.Gender=="female" && e.FirstName.ToLowerInvariant().StartsWith("s"));
            femalesWithNamesStartingWithS.Print("Females with names starting with 'S' / using filter ");

            Console.WriteLine();
            // using linq
            employees.Where(e => e.Gender == "female" && e.FirstName.ToLowerInvariant().StartsWith("s"));
            femalesWithNamesStartingWithS.Print("Females with names starting with 'S' / using where");

        }
    }
}
