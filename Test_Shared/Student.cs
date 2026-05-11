using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Shared
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public List<int> Grades { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name ?? "N/A"}, Age: {Age}, Department: {Department ?? "N/A"}";
        }

    }
}
