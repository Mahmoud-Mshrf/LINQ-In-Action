using Test_Shared;

namespace Materialize_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = Repository.LoadStudents();

            ToList(students);
            ToArray(students);
            ToDictionary(students);
            ToLookup(students);
            /*
             Dictionary	                      Lookup
             single value per key	          multiple values per key
             error on duplicates	          supports duplicates
             strict	                          grouping-friendly
             */
        }

        private static void ToLookup(IEnumerable<Student> students)
        {
            var lookup = students.ToLookup(s => s.Department);
            /*
             🧠 Result:
              CS → [Mahmoud, Sara, Omar]
              IT → [Ali]
              IS → [Mona]
              🔥 Step-by-step
              Step 1:
              
              iterate collection
              
              Step 2:
              
              compute key (Department)
              
              Step 3:
              
              group values under same key
             */
        }

        private static void ToDictionary(IEnumerable<Student> students)
        {
            var dict = students.ToDictionary(s => s.Id);
            /*
             🧠 Result structure:
              1 → Mahmoud
              2 → Ali
              3 → Sara
              🔥 Step-by-step behavior
              Step 1:
              
              iterate collection
              
              Step 2:
              
              extract key (Id)
              
              Step 3:
              
              store key-value pair
              
              ❗ Rule:
              
              Keys must be unique
              
              💥 If duplicate exists:
              System.ArgumentException
             */
        }

        private static void ToArray(IEnumerable<Student> students)
        {

            var result = students
                .Where(s => s.Age > 21)
                .ToArray();
            /*
             🧠 Behavior:
             
             Same as ToList but:
             
             ToList	ToArray
             List<T>	T[]
             dynamic size	fixed size
             ⚡ When to use:
             ToArray → performance-sensitive loops
             ToList → manipulation (Add/Remove)
             */
        }
        private static void ToList(IEnumerable<Student> students)
        {

            var result = students
                .Where(s => s.Age > 21)
                .ToList();
            /*
             🧠 What happens step-by-step?
             Step 1:
             
             Query is built
             
             Step 2:
             
             ToList() executes immediately
             
             Step 3:
             
             Data is stored in memory list
             
             💡 Result:
             database/query executed ONCE
             result cached in memory
             */
        }
    }
}
