using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseTask
{
    public class Course
    {
        public string Name { get; set; }
        public List<Group> Groups { get; } = [];

        public Course(string name)
        {
            Name = name;
        }

        public void AddGroup(Group group)
        {
            bool finded = Groups.Any(g => g.Name.ToLower() == group.Name.ToLower());

            if (!finded) Groups.Add(group);
            else Console.WriteLine("We have a group with this name");
        }

        public void RemoveGroup(int id)
        {
            Group? group = Groups.Find(g => g.Id == id);

            Groups.Remove(group);
        }


        public void ShowGroups()
        {
            foreach (Group group in Groups) Console.WriteLine($"Group {group.Name}");
        }

        public Group? FindGroup(string name) => Groups.FirstOrDefault(g => g.Name.ToLower() == name.ToLower());
    }
}
