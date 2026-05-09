namespace ProjectUsingZip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunExample01();
        }

        private static void RunExample01()
        {
            string[] colorName = { "Red", "Green", "Blue" };
            string[] colorHex = { "FF0000", "00FF00", "0000FF" };

            var result = colorName.Zip(colorHex, (name, hex) => $"{name}: ({hex})");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
