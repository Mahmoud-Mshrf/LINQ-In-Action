using _15_Shared;

namespace SetsOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Distinct();
            //Except();
            //Intersect();
            //Union();
            int[] ints1 = { 1, 2, 3 };
            int[] ints2 = { 3, 4, 5, 6 };
            var union = ints1.Union(ints2);
            var intersect = ints1.Intersect(ints2);
            var except = ints1.Except(ints2);
            var distinct = ints1.Distinct();

            foreach (int i in union)
            {
                Console.WriteLine(i);
            }
            foreach (int i in intersect)
            {
                Console.WriteLine(i);
            }
            foreach (int i in except)
            {
                Console.WriteLine(i);
            }
            foreach (int i in distinct)
            {
                Console.WriteLine(i);
            }
        }

        private static void Union()
        {
            var Meet1Participants = Repository.Meeting1.Participants;
            var Meet2Participants = Repository.Meeting2.Participants;

            var UniqueConcat = Meet1Participants.Union(Meet2Participants);// need override equality methods 
            UniqueConcat.Print("the union of two meetings");
            var UniqueConcatt = Meet1Participants.UnionBy(Meet2Participants, x => x.EmployeeNo);
            UniqueConcatt.Print("the union of two meetings");
        }

        private static void Intersect()
        {
            var Meet1Participants = Repository.Meeting1.Participants;
            var Meet2Participants = Repository.Meeting2.Participants;
            var commonParticipants = Meet1Participants.Intersect(Meet2Participants);// return the common , need override equality methods
            commonParticipants.Print("Common Participants in The Two Meetings");
            var commonParticipantss = Meet1Participants.IntersectBy(Meet2Participants.Select(x => x.EmployeeNo), x => x.EmployeeNo);
            commonParticipantss.Print("Common Participants in The Two Meetings");
        }

        private static void Except()
        {

            var Meet1Participants = Repository.Meeting1.Participants;
            var Meet2Participants = Repository.Meeting2.Participants;
            var ParticipantNotShared = Meet1Participants.Except(Meet2Participants);//return the difference, need override equality methods
            ParticipantNotShared.Print("Participants don't exist in the two meetings");
            var ParticipantNotSharedd = Meet1Participants.ExceptBy(Meet2Participants.Select(x => x.EmployeeNo), x => x.EmployeeNo);
            ParticipantNotSharedd.Print("Participants don't exist in the two meetings");

        }

        private static void Distinct()
        {
            var Meet1Participants = Repository.Meeting1.Participants;
            var Meet2Participants = Repository.Meeting2.Participants;
            var meet1and2Participants = Meet1Participants.Concat(Meet2Participants);
            var DistinctParticipants = meet1and2Participants.Distinct();// it will works if you make override for the equality methods
            DistinctParticipants.Print("Distinct Participants:");
            var DistinctParticipantss = meet1and2Participants.DistinctBy(x => x.EmployeeNo);// doesn't need override for the equality methods
            DistinctParticipantss.Print("Distinct Participants:");

        }
    }
}
