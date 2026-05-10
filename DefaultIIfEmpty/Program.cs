using _10_Shared;

namespace DefaultIIfEmpty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var questions1 = new List<Question>();

            // imagine that we have do some things here until we iterate over questions1
            // , it is not good thing to reserve memory here and don't use it
            foreach (var question in questions1)
            {

            }

            var questions2 = Enumerable.Empty<Question>();
            // better because this depends on deferred execution doesnt consume the memory 

            var questions3 = questions2.DefaultIfEmpty(); // this mean that if this list is empty then questions3 will contain the deafult of this object 
            var questions4 = questions2.DefaultIfEmpty(Question.Default); // if empty will contain what between barantheses

            List<int> ints = new List<int>();
            var questionsss = ints.DefaultIfEmpty();
            foreach (var questionss in questionsss)
            {
                Console.WriteLine(questionss);
            }

        }
    }
}
