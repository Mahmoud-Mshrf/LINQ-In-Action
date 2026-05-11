using _12And13_Shared;

namespace EqualityOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunMethodOne();
            RunMethodTwo();
            RunMethodThree();
        }

        private static void RunMethodThree()
        {
            var list1 = new List<Question>(QuestionBank.GetQuestionRange(Enumerable.Range(1, 10)));
            var list2 = new List<Question>(QuestionBank.GetQuestionRange(Enumerable.Range(1, 10)));

            Console.WriteLine(list1.SequenceEqual(list2));// false without overriding equality in question class , true after overriding equality in question class
        }

        private static void RunMethodTwo()
        {
            var range = QuestionBank.GetQuestionRange(Enumerable.Range(1, 10));

            var list1 = new List<Question>(range);
            var list2 = new List<Question>(range);

            Console.WriteLine(list1.SequenceEqual(list2));// true without overriding equality in question class

        }

        private static void RunMethodOne()
        {
            var question1 = QuestionBank.PickOne();
            var question2 = QuestionBank.PickOne();
            var question3 = QuestionBank.PickOne();

            var list1 = new List<Question>(new [] {question1,question2,question3});
            var list2 = new List<Question>(new [] {question1,question2,question3});

            Console.WriteLine(list1.SequenceEqual(list2));// true without overriding equality in question class

        }
    }
}
