using _12And13_Shared;

namespace Concatination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Method1();
            //Method2();
            //Method3();
            //Method4();
            Method5();
        }

        private static void Method4()
        {

            var quiz1 = QuestionBank.Randomize(3);
            var quiz2 = QuestionBank.Randomize(2);
            var quiz3 = new[] { quiz1, quiz2 }.SelectMany(q => q);
            quiz3.ToQuiz();

        }

        private static void Method2()
        {
            var quiz1 = QuestionBank.Randomize(3);
            var quiz2 = QuestionBank.Randomize(2);
            var quizQuestionsOnly = quiz1.Select(x => x.Title).Concat(quiz2.Select(x => x.Title));
            foreach (var question in quizQuestionsOnly)
            {
                Console.WriteLine(question);
            }
        }
        private static void Method3()
        {

            var quizQuestionsOnly = QuestionBank.Randomize(3).Select(x => x.Title)
                .Concat(QuestionBank.Randomize(2).Select(x => x.Title))
                .Concat(QuestionBank.GetQuestionRange(Enumerable.Range(11, 14)).Select(x => x.Title));
            foreach (var question in quizQuestionsOnly)
            {
                Console.WriteLine(question);
            }
        }

        private static void Method1()
        {
            var quiz1 = QuestionBank.Randomize(3);
            var quiz2 = QuestionBank.Randomize(2);
            var quiz3 = quiz2.Concat(quiz1);
            quiz3.ToQuiz();
        }
        private static void Method5()
        {
            int[] ints = { 1, 2, 3, 4, 5 };
            int[] ints2 = { 16, 17, 18, 19, 20 };
            var ints3 = ints.Concat(ints2);
            foreach (var i in ints3)
            {
                Console.WriteLine(i);
            }
        }

    }
}
