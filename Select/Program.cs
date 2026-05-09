namespace Select
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
        }
        private static void RunExample01()
        {
            List<string> words = new () { "mahmoud" , "mshrf" , "mogahed" };
            var result = words.Select(x => x.ToUpper());// extension method syntax
            var result01 = from word in words
                           select word.ToUpper(); // Query syntax
            foreach (var item in result01)
            {
                Console.WriteLine(item);
            }
        }
    }
}
