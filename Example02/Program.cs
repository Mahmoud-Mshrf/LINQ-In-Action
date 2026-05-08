namespace Example02
{
    // The Objects that apply linq on it should be IEnumerable<T>
    /* Why Linq is Popular:
     * fimiliar language (self descriptive)
     * Less Coding 
     * Standard way to query any data source
     * Type safety at compile time
     * 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> Numbers = new List<int> { 1, 2, 3,4, 5, 6,7,8,9,10};
            //var EvenNumbers = Numbers.Where(x => x % 2 == 0);
            //foreach (var number in EvenNumbers)
            //{
            //    Console.WriteLine(number);
            //}

            ////
            //var EvenNumbers2 = Numbers.Where(x=>x % 2 == 0); Deferred Excution == Construction (Lazy Loading) it will have a reference to the original list,
            //                                                 // so what will happened to the original list before the iteration it will be in concern

            //Numbers.Add(12);
            //Numbers.Add(14);
            //Numbers.Remove(4);
            //// here will print 12 and 14 although they were added after the Construction
            //foreach(var number in EvenNumbers2)// enumeration (immediate Execution)

            //{
            //    Console.WriteLine(number);
            //}
        }
    }
}
