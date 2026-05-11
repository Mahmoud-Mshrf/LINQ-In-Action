using System.Collections.Generic;
using System.Linq;

namespace _12And13_Shared
{
    public class Question:IEquatable<Question>
    {
        public string Title { get; set; }
        public List<Choice> Choices { get; set; } = new();
        public int CorrectAnswer { get; set; }

        public bool Equals(Question? other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Title == other.Title &&
                Choices.SequenceEqual(other.Choices) &&
                CorrectAnswer == other.CorrectAnswer;
        }
        public override bool Equals(object? obj)
        {
            return Equals(obj as Question);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Choices, CorrectAnswer);
        }
        public static bool operator ==(Question left , Question right)
        {
            return EqualityComparer<Question>.Default.Equals(left, right);

        }
        public static bool operator !=(Question left,Question right)
        {
            return !(left == right);
        }
        public override string ToString()
        {
            var choices = "";

            foreach (var item in Choices)
            {
                choices += $"\n\t{item.Order}) {item.Description}";
            }

            return $"{Title}" +
                   $"{choices}";


        }
    }
}
