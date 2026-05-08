namespace PureVsImpureFunctions
{
    // Pure function : the function is pure if:
    // - always produces the same output for the same input 
    // - has no side effects ( does not change external state)

    internal class Program
    {
        static List<int> Numbers = new List<int> {1,2,3,4,5,6,7,8,9};// global variable
        static void Main(string[] args)
        {
            Console.WriteLine("Before mutation");
            Print(Numbers);
            Console.WriteLine("After mutation");
            AddInteger1(3);
            Print(Numbers);
            Console.WriteLine("the new list returned from the pure function");
            var newNumbers = GetNumbers(Numbers, 10);
            Print(newNumbers);
        }
        static void Print<T>(IEnumerable<T> values) // pure function
        {
            foreach (T value in values)
            {
                Console.Write(value);
            }
            Console.WriteLine();
        }
        // examples of impure functions :
        static void AddInteger1(int number)
        {
            Numbers.Add(number); // this is impure because it mutate(change) global variable it add number to it
        }
        static void AddInteger2(ref int number)
        {
            number++;
            Numbers.Add(number); // this is impure because it mutate(change) global variable it add number to it
                                 // and it mutate parameter it change its value , the number increased by 1
        }
        static void AddInteger3()
        {
            Numbers.Add(new Random().Next());
            // this is impure becuase it interact with outside world 
            // and it mutate the global variable 
        }
        static List<int> GetNumbers(List<int> numbers , int num)
        {
            var list = new List<int>(numbers);
            list.Add(num);
            return list;
            // this is pure because it doesn't has side effects it create a new list and add a number to it so it has same output for same input and doesn't mutate anything
        }
    }
}
