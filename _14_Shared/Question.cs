using System.Collections.Generic;

namespace _14_Shared
{
    public class Question /*:IComparable<Question>*/
    {
        public string Title { get; set; }
        public List<Choice> Choices { get; set; } = new();
        public int CorrectAnswer { get; set; }

        public int Marks { get; set; }

        public override string ToString()
        {
            var choices = "";

            foreach (var item in Choices)
            {
                choices += $"\n\t{item.Order}) {item.Description}";
            }

            return $"{Title} [{Marks} marks]" +
                   $"{choices}";


        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            Question other = (Question)obj;

            return Title.Equals(other.Title)
                 && CorrectAnswer == other.CorrectAnswer
                 && Choices.SequenceEqual(other.Choices);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            //check null
            hash = hash * 23 + Title.GetHashCode();
            hash = hash * 23 + CorrectAnswer.GetHashCode();
            hash = hash * 23 + Choices.GetHashCode();
            return hash;
        }

        //public int CompareTo(Question? other)
        //{
        //    if (this.Marks == other.Marks)
        //        return this.Title.CompareTo(other.Title);
        //    else
        //        return this.Marks.CompareTo(other.Marks);
        //}
    }
}
