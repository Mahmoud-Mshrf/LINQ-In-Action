using _14_Shared;

namespace Aggregate
{
    // Think of Aggregate as: “Take many values and keep combining them into ONE final result.”
    /*
     The accumulator function describes:
      - how values are combined
      - and what the running result becomes after each step
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            //MethodOne();
            //MethodTwo();
            //MethodThree();
            MethodFour();
        }

        private static void MethodFour()
        {
            var Questions = QuestionBank.All;
            var longestQuestionInList = Questions[0];

            longestQuestionInList = Questions.Aggregate(longestQuestionInList,
                (longest, next) => longest.Title.Length < next.Title.Length ? next : longest, (x => x));

            Console.WriteLine(longestQuestionInList);
        }

        private static void MethodThree()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            var sumOfNumbers = numbers.Aggregate(100, (a, b) => a + b);
            Console.WriteLine(sumOfNumbers);// 115 
        }

        private static void MethodTwo()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            var sumOfNumbers = numbers.Aggregate((a, b) => a + b);
            Console.WriteLine(sumOfNumbers);// 15
        }

        private static void MethodOne()
        {
            var names = new[] { "Mahmoud", "Badawi", "Ali", "Amr", "Hossam", "Mohamed" };

            var commaSeperatedNames = names.Aggregate((a, b) => $"{a},{b}");
            Console.WriteLine(commaSeperatedNames);
        }
    }
}
