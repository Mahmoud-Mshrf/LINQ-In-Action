namespace Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] fruits = { "Apple", "Panana", "Mango", "Orange", "Watermellon" };
            var reversedFruits = fruits.Reverse();// must be assigned to a variable to be applied
            // fruits.Reverse();// this do nothing because it is not assigned to variable 
            foreach (var fruit in reversedFruits)
            {
                Console.WriteLine(fruit);
            }

        }
    }
}
