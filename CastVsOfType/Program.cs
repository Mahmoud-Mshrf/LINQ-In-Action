using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CastVsOfType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<object> data = new object[]
            {
                1,
                "hello",
                2,
                "world",
                3
            };
            Cast(data);// Runtime error immediately: because "hello" cannot become int
            OfType(data);
        }

        private static void OfType<T>(IEnumerable<T> data)
        {
            var numbers = data.OfType<int>();// means : filters only valid types , ignores invalid ones , never throws
        }

        private static void Cast<T>(IEnumerable<T> data)
        {
            var numbers = data.Cast<int>();// means : “I assume everything is this type” (unsafe)
        }
    }
}
