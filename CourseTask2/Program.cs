// See https://aka.ms/new-console-template for more information
using CourseTask;

bool exit = false;

Course course = new("Codeedu");
do
{
    Console.WriteLine("------ MENU ------");
    Console.WriteLine("1.Add Group\n2.See Groups\n3.Edit Group\n4.Remove Group\n5.Add student to group\n6.See students\n7.Show All Students\n8.Find Student\n9.Remove Student from group\n10.Edit Student\n11.Add Grade\n12.Quit");
    Console.WriteLine("------ MAKE A CHOISE ------");
    string? choise = Console.ReadLine()?.Trim();
    Group? group;
    string? name;
    string? surname;
    int age;
    int id;

    switch (choise)
    {
        case "1":
            Console.Write("Write group name: ");
            name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                if (!course.Groups.Any(g => g.Name == name))
                {
                    group = new(name);
                    course.AddGroup(group);
                    Console.WriteLine("Group created successfully");
                }
                else Console.WriteLine("This group already exist");
            }
            else Console.WriteLine(ErrorMessages.InvalidInput);

            break;
        case "2":
            course.ShowGroups();
            break;
        case "3":
            course.ShowGroups();
            Console.Write("Write grup name: ");
            name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                group = course.FindGroup(name);
                if (group != null)
                {
                NewGroupNameLabel: Console.Write("Write new group name: ");
                    string? newGroupName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(newGroupName))
                    {
                        Console.WriteLine(ErrorMessages.InvalidInput);
                        goto NewGroupNameLabel;
                    }

                    if (!course.Groups.Any(g => g.Name == newGroupName))
                    {
                        group.Name = newGroupName;
                        Console.WriteLine("Group edited Successfully");
                    }

                }
                else Console.WriteLine(ErrorMessages.NotFoundGroup);
            }
            else Console.WriteLine(ErrorMessages.InvalidInput);
            break;
        case "4":
            course.ShowGroups();
            Console.Write("Write grup name: ");
            name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                group = course.FindGroup(name);
                if (group != null)
                {
                    course.RemoveGroup(group.Id);
                    Console.WriteLine("Group removed successfully");
                }
                else Console.WriteLine(ErrorMessages.NotFoundGroup);
            }
            else Console.WriteLine(ErrorMessages.InvalidInput);

            break;
        case "5":
            course.ShowGroups();
            Console.Write("Write grup name: ");
            name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                group = course.FindGroup(name);
                if (group != null)
                {
                WriteStudentNameLabel: Console.Write("Write name: ");
                    name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine(ErrorMessages.InvalidInput);
                        goto WriteStudentNameLabel;
                    }

                WriteStudentSurnameLabel: Console.Write("Write surname: ");
                    surname = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(surname))
                    {
                        Console.WriteLine(ErrorMessages.InvalidInput);
                        goto WriteStudentSurnameLabel;
                    }

                WriteStudentAgeLabel: Console.Write("Write age: ");
                    bool ageCheck = int.TryParse(Console.ReadLine(), out age);

                    if (!ageCheck)
                    {
                        Console.WriteLine(ErrorMessages.InvalidInput);
                        goto WriteStudentAgeLabel;
                    }


                    Student student = new(name, surname, age);

                    group.AddStudent(student);
                    Console.WriteLine("Student added successfully");
                }
                else Console.WriteLine(ErrorMessages.NotFoundGroup);
            }
            else Console.WriteLine(ErrorMessages.InvalidInput);

            break;
        case "6":
            course.ShowGroups();
            Console.Write("Write grup name: ");
            name = Console.ReadLine();


            if (!string.IsNullOrWhiteSpace(name))
            {
                group = course.FindGroup(name);
                if (group != null)
                {
                    group.ShowAllStudents();
                }
                else Console.WriteLine(ErrorMessages.NotFoundGroup);
            }
            else Console.WriteLine(ErrorMessages.InvalidInput);


            break;
        case "7":
            foreach (Group item in course.Groups) item.ShowAllStudents();
            break;
        case "8":
            course.ShowGroups();
            Console.Write("Write grup name: ");
            name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                group = course.FindGroup(name);
                if (group != null)
                {
                    if (group.Students.Count == 0)
                    {
                        Console.WriteLine("This group is empty");
                        continue;
                    }
                WriteSearchInputLabel: Console.Write("Write input: ");
                    string? input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine(ErrorMessages.InvalidInput);
                        goto WriteSearchInputLabel;
                    }

                    group.FindStudent(input);
                }
                else Console.WriteLine(ErrorMessages.NotFoundGroup);
            }
            else Console.WriteLine(ErrorMessages.InvalidInput);


            break;
        case "9":
            course.ShowGroups();
            Console.Write("Write grup name: ");
            name = Console.ReadLine();


            if (!string.IsNullOrWhiteSpace(name))
            {
                group = course.FindGroup(name);
                if (group != null)
                {
                    if (group.Students.Count == 0)
                    {
                        Console.WriteLine("This group is empty");
                        continue;
                    }
                    group.ShowAllStudents();
                WriteStudentId: Console.Write("Write student id: ");
                    int id1;
                    bool isValidId = int.TryParse(Console.ReadLine(), out id1);

                    if (!isValidId)
                    {
                        Console.WriteLine(ErrorMessages.InvalidInput);
                        goto WriteStudentId;
                    }

                    group.RemoveStudent(id1);
                    Console.WriteLine("Student removed successfully");
                }
                else Console.WriteLine(ErrorMessages.NotFoundGroup);
            }
            else Console.WriteLine(ErrorMessages.InvalidInput);

            break;
        case "10":
            course.ShowGroups();
            Console.Write("Write grup name: ");
            name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                group = course.FindGroup(name);
                if (group != null)
                {
                    if (group.Students.Count == 0)
                    {
                        Console.WriteLine("This group is empty");
                        continue;
                    }
                    group.ShowAllStudents();
                WriteStudentId2: Console.Write("Write id: ");
                    bool isValidId = int.TryParse(Console.ReadLine(), out id);

                    if (!isValidId)
                    {
                        Console.WriteLine(ErrorMessages.InvalidInput);
                        goto WriteStudentId2;
                    }

                WriteEditedStudentNameLabel: Console.Write("Write name: ");
                    name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine(ErrorMessages.InvalidInput);
                        goto WriteEditedStudentNameLabel;
                    }


                WriteEditedStudentSurnameLabel: Console.Write("Write surname: ");
                    surname = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(surname))
                    {
                        Console.WriteLine(ErrorMessages.InvalidInput);
                        goto WriteEditedStudentSurnameLabel;
                    }

                WriteEditedStudentAgeLabel: Console.Write("Write age: ");
                    bool ageCheck = int.TryParse(Console.ReadLine(), out age);

                    if (!ageCheck)
                    {
                        Console.WriteLine(ErrorMessages.InvalidInput);
                        goto WriteEditedStudentAgeLabel;
                    }

                    group.EditStudent(id, name, surname, age);
                    Console.WriteLine("Student edited successfully");
                }
                else Console.WriteLine(ErrorMessages.NotFoundGroup);
            }
            else Console.WriteLine(ErrorMessages.InvalidInput);

            break;
        case "11":
            course.ShowGroups();
            Console.Write("Write grup name: ");
            name = Console.ReadLine();


            if (!string.IsNullOrWhiteSpace(name))
            {
                group = course.FindGroup(name);
                if (group != null)
                {
                    if (group.Students.Count == 0)
                    {
                        Console.WriteLine("This group is empty");
                        continue;
                    }

                    group.ShowAllStudents();
                WriteStudentId: Console.Write("Write student id: ");
                    int id1;
                    bool isValidId = int.TryParse(Console.ReadLine(), out id1);

                    if (!isValidId)
                    {
                        Console.WriteLine(ErrorMessages.InvalidInput);
                        goto WriteStudentId;
                    }

                    Student? student = group.Students.FirstOrDefault(x => x.Id == id1);

                    if (student is not null)
                    {
                    WriteGradeInputLabel: Console.Write("Please enter grades ex: (1, 5, 6): ");
                        string? gradeInput = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(gradeInput))
                        {
                            Console.WriteLine(ErrorMessages.InvalidInput);
                            goto WriteGradeInputLabel;
                        }

                        try
                        {
                            string[] parts = gradeInput.Split(',');

                            int[] numbers = parts.Select(part => int.Parse(part.Trim())).ToArray();

                            student.AddGrade(numbers);
                            Console.WriteLine("Student grade added successfully");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: please enter valid numbers");
                            goto WriteGradeInputLabel;
                        }
                    }
                    else Console.WriteLine("There is not such a student");
                }
                else Console.WriteLine(ErrorMessages.NotFoundGroup);
            }
            else Console.WriteLine(ErrorMessages.InvalidInput);
            break;

        case "12":
            exit = true;
            break;
        default:
            Console.WriteLine("Please choise valid operation");
            break;
    }
} while (!exit);