using Test_Shared;

namespace Test
{
    // ***** Answers Only *****
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = Repository.LoadStudents();
            var courses = Repository.LoadCourses();
            var enrollments = Repository.LoadEnrollments();
            // Q1 :
            var studentsNames = students.Select(x => x.Name);
            studentsNames.Print("Names of students ");
            // Q2 :
            students.SelectMany(x => x.Grades).Print("All grades from all students in one sequence");// here without variable printing directly not like question 1 
            // Q3 :
            string[] letters = ["A", "B", "C"];
            int[] numbers = [1, 2, 3];
            var cominedResult = letters.Zip(numbers, (letter, num) => $"{letter}-{num}");
            cominedResult.Print("Letters with numbers");
            // Q4 :
            var sortedStudents = students.OrderBy(x => x.Department).ThenByDescending(x => x.Age);
            sortedStudents.Print("Students sorted by Department ascending then by Age descending");
            // Q5 :
            // OrderBy() : orders the elements of the collection based in specified selector and thenBy uses to specify if the selector that specified in OrderBy be the same for two elements then order them based on the selector that specified in ThenBy()
            // Q6 :
            var firstTwoStudents = students.Take(2);
            // Q7 :
            var studentsWithoutFirstThree = students.Skip(3);
            // Q8 : 
            var studentsWhileAgeLessThan23 = students.OrderBy(x => x.Age).TakeWhile(x => x.Age < 23);
            studentsWhileAgeLessThan23.Print("Students While Age Less Than 23");
            // Q9 : here i will not make your request i will create a flexable paginate method 
            //students.ShowPaginate();
            // Q10 :
            var groups = students.Chunk(2);
            // Q11 :
            var thereAreStudentsBiggerThan23 = students.Any(x => x.Age > 23);
            var allStudentsBelongsToCsDepartment = students.All(x => x.Department == "CS");
            // Q12 :
            var isAliExists = students.Select(x => x.Name).Contains("Ali");
            // Q13 : 
            var StudentsGroupByDepartment = students.GroupBy(x => x.Department);
            foreach (var item in StudentsGroupByDepartment)
            {
                Console.WriteLine($"----{item.Key}----");
                foreach (var i in item)
                {
                    Console.WriteLine(i);
                }
            }
            // Q14 :
            // Both of them group the elements based on specific key but the difference between them that groupBy return IEnuemerable<IGrouping<TKey,Tsource>> and it uses deferred execution and ToLookup return ILookup<Tkey,Tsource> and it uses immediate execution 
            // Q15 : 
            var StudentsWithCourses =
                students.Join(enrollments, s => s.Id, e => e.StudentId, (s, e) => new { StudentName = s.Name, CourseId = e.CourseId })
                .Join(courses, sc => sc.CourseId, c => c.Id, (sc, c) => new { StudentName = sc.StudentName, CourseTitle = c.Title });
            foreach (var item in StudentsWithCourses)
            {
                Console.WriteLine($"{item.StudentName} study :{item.CourseTitle}");
            }
            // Q16 :
            var result =
            students.GroupJoin(
                enrollments,
                s => s.Id,
                e => e.StudentId,
                (student, enrollments) => new
                {
                    StudentName = student.Name,
                    Courses = enrollments
                });
            foreach (var item in result)
            {
                Console.WriteLine($"{item.StudentName} study : ");
                foreach (var i in item.Courses.Select(x => x.CourseId))
                {
                    Console.WriteLine(i);
                }
            }
            // Q17 :
            var numberss = Enumerable.Range(1, 10);
            foreach (var item in numberss)
            {
                Console.WriteLine(item);
            }
            // Q18 :
            var hello = "Hello";
            var hellos = Enumerable.Repeat(hello, 5);
            foreach (var item in hellos)
            {
                Console.WriteLine(item);
            }
            // Q19 :
            // First() => first element in the sequence and exception if there are no elements on the collection 
            // First(predicate ) => first element in the sequence that match the predicate and exception if there are no elements on the collection match the predicate
            // FirstOrDefault() => first element in the sequence and (default) there is no exception if there are no elements on the collection 
            // FirstOrDefault(predicate ) => first element in the sequence that match the predicate and (default) there is no exception if there are no elements on the collection match the predicate
            // Single() => the only element in the sequence and exception if there are no elements or there are more elements in the sequence
            // SingleOrDefault() => the only element in the sequence and default if there are no elements and exception if there are more elements 

            // Q20 :
            // Single() throws:
            // InvalidOperationException if no elements
            // InvalidOperationException if more than one element
            // Q21 :
            var maxAge = students.Max(x => x.Age);
            var studentWithMaxAge = students.MaxBy(x => x.Age);
            // Q22 : 
            var avgAge = students.Average(x => x.Age);
            // Q23 :
            var totalGradesCount =
            students.SelectMany(x => x.Grades)
            .Aggregate(0, (count, _) => count + 1);
            // or 
            students.SelectMany(x => x.Grades).Count();
            Console.WriteLine(totalGradesCount);
            // Q24 :
            // unioun combines unique elements
            // concat appends sequences preserving duplicates
            // Q25 :
            // distinct() return distinct elements from the sequence it remove duplication based on default comparer
            // Except() the difference between first and second set , the items that exist in the first and don't exist in the second 
            // intersect() the common between two sets 
            // Q26 :
            // deferred execution : the query is defined but NOT executed until you actually iterate over it.
            // immediate execution : the query defined and executed immediately
            // Q27 :
            /*
             IEnumerable
             LINQ to Objects
             execution happens in application memory
             operators executed by CLR
             IQueryable
             builds expression tree
             translated by provider (EF Core → SQL)
             query executed remotely (usually database)
             🔥 Critical interview distinction
             
             IQueryable supports:
             
             SQL translation
             server-side execution
             deferred query composition
             
             IEnumerable:
             
             already materialized or local enumeration
             */
        }
    }
    public static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> source, string title)
        {
            if (source == null)
                return;
            Console.WriteLine();
            Console.WriteLine("┌───────────────────────────────────────────────────────┐");
            Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
            Console.WriteLine("└───────────────────────────────────────────────────────┘");
            Console.WriteLine();
            foreach (var item in source)
            {
                if (typeof(T).IsValueType)
                    Console.Write($" {item} "); // 1, 2, 3
                else
                    Console.WriteLine(item);
            }
        }
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int page = 1, int size = 10)
        {
            if (page <= 0)
                page = 1;
            if (size <= 0)
                size = 10;

            return source.Skip((page - 1) * size).Take(size);
        }
        public static void ShowPaginate<T>(this IEnumerable<T> source)
        {
            var size = 10;
            Console.WriteLine("Enter page size: ");
            if (int.TryParse(Console.ReadLine(), out int sizeResult))
            {
                size = sizeResult;
            }
            var NoPages = (int)Math.Ceiling((decimal)source.Count() / size);
            var page = 1;
            Console.WriteLine($"Enter page number: (from 1 to {NoPages})");
            if (int.TryParse(Console.ReadLine(), out int pageResult))
            {
                page = pageResult;
            }
            if (page > NoPages)
            {
                page = NoPages;
            }
            var result = source.Paginate(page, size);

            var resultCount = result.Count();

            var starttRecord = ((page - 1) * size + 1);
            var endRecord = starttRecord + resultCount - 1;

            result.Print($"items from {starttRecord} to {endRecord}");
        }
    }
}
