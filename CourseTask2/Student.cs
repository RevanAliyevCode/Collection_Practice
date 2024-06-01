using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTask
{
    public class Student
    {
        private static int id = 0;
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public List<int> Grades { get; } = [];

        public Student(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
            id++;
            Id = id;
        }


        public void GetDetails()
        {
            Console.WriteLine($"Name: {Name}, Surname: {Surname}, Age: {Age}, Id: {Id}");
            Console.WriteLine("\t\tGrades: ");
            foreach (int grade in Grades) Console.WriteLine($"\t\t\t{grade}");
        }

        public void AddGrade(int[] grades)
        {
            Grades.AddRange(grades);
        }
    }
}
