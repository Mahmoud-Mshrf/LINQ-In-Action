namespace Example03
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] ints = numbers.ToArray();
            var EvenNumbersWithExtensionMethodd = ints.Where(x => x % 2 == 0);
            var EvenNumbersWithExtensionMethod =
                numbers.Where(x => x % 2 == 0);

            Console.WriteLine("with extension method");
            foreach (var number in EvenNumbersWithExtensionMethodd)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("with extension method");
            foreach (var number in EvenNumbersWithExtensionMethod)
            {
                Console.WriteLine(number);
            }

            var EvenNumbersWithEnumerableWhereMethod =
                Enumerable.Where(numbers, x => x % 2 == 0);
            Console.WriteLine();
            Console.WriteLine("Enumerable Where");
            foreach (var number in EvenNumbersWithEnumerableWhereMethod)
            {
                Console.WriteLine(number);
            }

            var EvenNumbersWithQuery =
                from n in numbers
                where n % 2 == 0
                select n;

            Console.WriteLine();
            Console.WriteLine("With Query");
            foreach (var n in EvenNumbersWithQuery)
            {
                Console.WriteLine(n);
            }
        }
    }
}
