using _10_Shared;

namespace ElementOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // this project reference _10_Shared

            //ElementAt();
            //First();
            //Last();
            Single();
        }

        private static void Single()
        {
            var questions = QuestionBank.All;
            //var question = questions.Single();// it will give exception as sequence contains more than one element
            //var question1 = questions.Single(x=> x.Title.Contains("#245"));// it will give exception as sequence contains more than one element that acheive this condition
            //var question2 = questions.Single(x=> x.Title.Length== 0);// it will give exception as no matching elements in the sequence
            var question3 = questions.SingleOrDefault(x => x.Title.Contains("#245"));// it will give exception as sequence contains more than one element that acheive this condition
            var question4 = questions.SingleOrDefault(x => x.Title.Contains("#2555"));//it will not give exception if doesn't match it will give default(null) 
            var question5 = questions.SingleOrDefault(x => x.Title.Length == 0);//it will not give exception if doesn't match it will give default(null) 
            if (question4 == null && question5 == null)
            {
                Console.WriteLine("question3== null && question4 == null");
            }
        }

        private static void Last()
        {
            var questions = QuestionBank.All;
            var question1 = questions.Last();// it will return the last element in the sequence
            var question2 = questions.Last(x => x.Title == "Q #2: In the streaming live audio/video category of audio/video services");
            // it will return the last element in the sequence that match the condition
            // the above will give exception if there are no element in the sequence that match the condition
            var question3 = questions.LastOrDefault();// return the last element in the sequence if it exists and return the default(null) if it doesn't exist
            var question4 = questions.LastOrDefault(x => x.Title == "24157");// return the last element in the sequence that match the condition if it exists and return the default(null) if it doesn't exist
            Console.WriteLine(question1);
        }

        private static void First()
        {
            var questions = QuestionBank.All;
            var question1 = questions.First();// it will return the first element in the sequence 
            var question2 = questions.First(x => x.Title == "Q #2: In the streaming live audio/video category of audio/video services");
            // it will return the first element in the sequence that match the condition,
            // the above will give exception if there are no element in the sequence that match the condition
            Console.WriteLine(question2);
            var question3 = questions.FirstOrDefault();// return the first element in the sequence if it exists and return the default(null) if it doesn't exist
            var question4 = questions.FirstOrDefault(x => x.Title == "24157");// return the first element in the sequence that match the condition if it exists and return the default(null) if it doesn't exist

        }

        private static void ElementAt()
        {
            var questions = QuestionBank.All;
            Question questionAt10 = questions.ElementAt(10);// it will give an exception if the element doesn't exist
            Console.WriteLine(questionAt10);
            Question questionAt300 = questions.ElementAtOrDefault(300);// it will not give an exception if the element doesn't exist , it make it default(null)
            if (questionAt300 is null)
            {
                Console.WriteLine("questionAt300 is null");
            }
        }
    }
}
