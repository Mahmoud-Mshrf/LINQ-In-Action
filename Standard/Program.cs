using _14_Shared;

namespace Standard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RunCount();
            //RunMax();
            //RunMaxBy();
            //RunMin();
            //RunMinBy();
            RunSum();
            RunAvg();
        }

        private static void RunAvg()
        {
            var questions = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));
            var avg = questions.Average(x => x.Marks);
            Console.WriteLine(avg.ToString("#.##"));
        }

        private static void RunSum()
        {
            var questions = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));
            var sum = questions.Sum(x => x.Marks);
            Console.WriteLine(sum);
        }

        private static void RunMaxBy()
        {
            var questions = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));
            var questionWithHighestMark = questions.FirstOrDefault(x => x.Marks == questions.Max(x => x.Marks));// or use MaxBy()
            var questionWithHighestMarkk = questions.MaxBy(X => X.Marks);
            Console.WriteLine(questionWithHighestMark);
            Console.WriteLine(questionWithHighestMarkk);
        }

        private static void RunMax()
        {
            var questions = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));
            var HighestMark = questions.Max(x => x.Marks);
            Console.WriteLine(HighestMark);
        }
        private static void RunMinBy()
        {
            var questions = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));
            var questionWithLowestMark = questions.FirstOrDefault(x => x.Marks == questions.Min(x => x.Marks));// or use MaxBy()
            var questionWithLowestMarkk = questions.MinBy(X => X.Marks);
            Console.WriteLine(questionWithLowestMark);
            Console.WriteLine(questionWithLowestMarkk);
        }

        private static void RunMin()
        {
            var questions = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));
            var LowesttMark = questions.Min(x => x.Marks);
            Console.WriteLine(LowesttMark);
        }

        private static void RunCount()
        {
            var questions = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));
            var count = questions.Count();
            Console.WriteLine(count);
            var countHasOneMark = questions.Count(x => x.Marks == 1);
            var countHasOneMarkUsingWhere = questions.Where(x => x.Marks == 1).Count();
            Console.WriteLine(countHasOneMark);
            Console.WriteLine(countHasOneMarkUsingWhere);
        }
    }
}
