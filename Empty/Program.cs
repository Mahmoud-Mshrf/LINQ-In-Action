namespace Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var range = Enumerable.Range(1, 10);
            // the above code equal to the following code but the above is deferred execution
            int[] range2 = new int[10];
            for (int i = 0, j = 1; i < range2.Length; i++, j++)
            {
                range2[i] = j;
            }
            foreach (var item in range2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
