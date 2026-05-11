namespace _12And13_Shared
{
    public class Choice:IEquatable<Choice>
    {
        public int Order { get; set; }
        public string Description { get; set; }
        public bool Equals(Choice? other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return this.Order == other.Order &&
                this.Description == other.Description;

        }
        public override bool Equals(object? obj)
        {
            return Equals(obj as Choice);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Order, Description);
        }
        public static bool operator ==(Choice ch1,Choice ch2)
        {
            return EqualityComparer<Choice>.Default.Equals(ch1, ch2);
            /*
             EqualityComparer<Employee>.Default.Equals(left, right) is used because it safely handles:
              - null
              - custom equality
              - consistent comparison behavior
             */
        }
        /*
        public static bool operator ==(Choice ch1, Choice ch2)
        {
            return EqualityComparer<Choice>.Default.Equals(ch1, ch2); // this line do the following :

            if (ch1 is null && ch2 is null)
                return true;

            if (ch1 is null || ch2 is null)
                return false;

            return ch1.Equals(ch2);
        }
        */
        public static bool operator !=(Choice ch1, Choice ch2)
        {
            return !(ch1 == ch2);
        }
    }
}
