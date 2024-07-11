using System.Numerics;
using HospitalTask;

Hospital hospital = new Hospital();
bool exit = false;

while (!exit)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Add doctor");
    Console.WriteLine("2. View all doctors");
    Console.WriteLine("3. Schedule appointment");
    Console.WriteLine("4. View appointments of doctor");
    Console.WriteLine("5. Exit");
    Console.Write("Select an option: ");

    switch (Console.ReadLine())
    {
        case "1":
           Services.AddDoctor(hospital);
            break;
        case "2":
            Services.ViewAllDoctors(hospital);
            break;
        case "3":
            Services.ScheduleAppointment(hospital);
            break;
        case "4":
            Services.ViewAppointmentsOfDoctor(hospital);
            break;
        case "5":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}