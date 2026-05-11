using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Shared
{
    public static class Repository
    {
        // Cached in-memory data (prevents re-creating lists every call)
        private static readonly List<Student> _students = new()
    {
        new Student { Id = 1, Name = "Mahmoud", Department = "CS", Age = 22, Grades = new() { 90, 95, 85 } },
        new Student { Id = 2, Name = "Ali", Department = "IT", Age = 20, Grades = new() { 70, 75 } },
        new Student { Id = 3, Name = "Sara", Department = "CS", Age = 23, Grades = new() { 88, 91 } },
        new Student { Id = 4, Name = "Mona", Department = "IS", Age = 21, Grades = new() { 60, 65 } },
        new Student { Id = 5, Name = "Omar", Department = "CS", Age = 24, Grades = new() { 100, 98 } }
    };

        private static readonly List<Course> _courses = new()
    {
        new Course { Id = 1, Title = "Algorithms" },
        new Course { Id = 2, Title = "Databases" },
        new Course { Id = 3, Title = "Networks" }
    };

        private static readonly List<Enrollment> _enrollments = new()
    {
        new Enrollment { StudentId = 1, CourseId = 1 },
        new Enrollment { StudentId = 1, CourseId = 2 },
        new Enrollment { StudentId = 2, CourseId = 3 },
        new Enrollment { StudentId = 3, CourseId = 1 },
        new Enrollment { StudentId = 5, CourseId = 2 }
    };

        // Exposed as IEnumerable to keep abstraction (no modification from outside)

        public static IEnumerable<Student> LoadStudents()
            => _students;

        public static IEnumerable<Course> LoadCourses()
            => _courses;

        public static IEnumerable<Enrollment> LoadEnrollments()
            => _enrollments;
    }
}
