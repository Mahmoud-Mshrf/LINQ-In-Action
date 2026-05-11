namespace EqualityOverride
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class Employee : IEquatable<Employee>
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public bool Equals(Employee? other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Id == other.Id
                && FullName == other.FullName
                && Email == other.Email;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Employee);
            /*
             The as operator:
              - tries casting
              - if cast fails → returns null
              - does NOT throw exception
             */
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, FullName, Email);
        }

        public static bool operator ==(Employee? left, Employee? right)
        {
            return EqualityComparer<Employee>.Default.Equals(left, right);// this like following:
            /*
             if (left is null && right is null)
                 return true;
             
             if (left is null || right is null)
                 return false;
             
             return left.Equals(right);
             */
        }

        public static bool operator !=(Employee? left, Employee? right)
        {
            return !(left == right);
        }
    }
    /*
     Why this is the best approach
     🔹 IEquatable<Employee>
     
     Provides strongly-typed equality:
     
     Equals(Employee other)
     
     Better performance than object boxing.
     
     🔹 ReferenceEquals
     ReferenceEquals(this, other)
     
     Fast path:
     
     same memory reference
     immediately true
     🔹 HashCode.Combine
     HashCode.Combine(...)
     
     Modern built-in safe hash generation.
     
     Avoid manual magic numbers like:
     
     hash = hash * 23 + ...
     🔹 EqualityComparer<T>.Default
     
     This is the safest implementation for operators because it handles:
     
     nulls
     custom equality
     consistency
     VERY IMPORTANT RULE
     
     Whenever you override:
     
     Equals
     
     you MUST also override:
     
     GetHashCode
     
     Otherwise collections like:
     
     HashSet
     Dictionary
     Distinct
     
     break logically.
     */
}
