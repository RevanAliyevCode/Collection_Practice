using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTask
{
    public class Group
    {
        private static int id = 0;
        public string Name { get; set; }
        public List<Student> Students { get; } = [];
        public int Id { get; }
        

        public Group(string name)
        {
            Name = name;
            id++;
            Id = id;
        }

        public void AddStudent(Student student) => Students.Add(student);

        public void RemoveStudent(int id)
        {
            Student? student = Students.FirstOrDefault(s => s.Id == id);

            if (student is not null) Students.Remove(student);
            else Console.WriteLine("There is no such a student");
        }

        public void EditStudent(int id, string name, string surname, int age)
        {
            Student? student = Students.FirstOrDefault(s => s.Id == id);

            if (student is not null)
            {
                student.Name = name;
                student.Surname = surname;
                student.Age = age;
            }
            else Console.WriteLine("There is no such a student");
        }

        public void ShowAllStudents()
        {
            Console.WriteLine($"Group {Name}: ");
            foreach (Student student in Students)
            {
                Console.Write("\t");
                student.GetDetails();
            }
        }

        public void FindStudent(string input)
        {
            foreach (Student student in Students)
            {
                if (student.Name.ToLower().Contains(input.ToLower())) student.GetDetails();
            }
        }
    }
}
