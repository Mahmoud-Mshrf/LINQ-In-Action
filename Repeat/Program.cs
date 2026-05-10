using _10_Shared;

namespace Repeat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var question1 = QuestionBank.PickOne();

            var questions = Enumerable.Repeat(question1, 10).ToList();
            // repeat the same element not creating new 10 elements 
            Console.WriteLine(ReferenceEquals(questions[0], questions[4]));// true because its the same element and repeated

            foreach (var item in questions)
            {
                Console.WriteLine(item);
            }
        }
    }
}
