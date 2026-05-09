namespace OrderBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] fruits = ["apple", "watermellon", "banana", "orange", "guava", "mango"];
            // Extension method syntax
            orderByAlphabiticallyAscending(fruits);
            orderByAlphabiticallyDescending(fruits);
            orderByLengthAscending(fruits);

            // Query syntax
            QueryOrderByAlphabiticallyAscending(fruits);
            QueryOrderByAlphabiticallyDescending(fruits);
            QueryOrderByLengthAscending(fruits);
        }

        private static void QueryOrderByLengthAscending(string[] fruits)
        {
            var orderedFruits06 = from f in fruits
                                  orderby f.Length
                                  select f; // ascending by string length
            foreach (var item in orderedFruits06)
            {
                Console.WriteLine(item);
            }
        }

        private static void QueryOrderByAlphabiticallyDescending(string[] fruits)
        {
            var orderedFruits05 = from f in fruits
                                  orderby f descending
                                  select f; // descending alphabitically
            foreach (var item in orderedFruits05)
            {
                Console.WriteLine(item);
            }
        }

        private static void QueryOrderByAlphabiticallyAscending(string[] fruits)
        {
            var orderedFruits04 = from f in fruits
                                  orderby f
                                  select f; //ascending by default , this goes to the default order factor (alphabitically)
            foreach (var item in orderedFruits04)
            {
                Console.WriteLine(item);
            }
        }

        private static void orderByLengthAscending(string[] fruits)
        {
            var orderedFruits03 = fruits.OrderBy(x => x.Length);// ascending by string length
            foreach (var item in orderedFruits03)
            {
                Console.WriteLine(item);
            }
        }

        private static void orderByAlphabiticallyDescending(string[] fruits)
        {
            var orderedFruits02 = fruits.OrderByDescending(x => x);// descending alphabitically
            foreach (var item in orderedFruits02)
            {
                Console.WriteLine(item);
            }
        }

        private static void orderByAlphabiticallyAscending(string[] fruits)
        {
            var orderedFruits01 = fruits.OrderBy(x => x);//ascending by default , this goes to the default order factor (alphabitically)
            foreach (var item in orderedFruits01)
            {
                Console.WriteLine(item);
            }
        }
    }
}
