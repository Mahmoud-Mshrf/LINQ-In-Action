using _06_Shared;

namespace Chunk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();
            var chunks = employees.Chunk(10).ToList();
            for (int i = 0; i < chunks.Count; i++)
            {
                chunks[i].Print($"Chunk #{i+1}");
            }
        }
    }
}
