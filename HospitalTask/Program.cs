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
            AddDoctor(hospital);
            break;
        case "2":
            ViewAllDoctors(hospital);
            break;
        case "3":
            ScheduleAppointment(hospital);
            break;
        case "4":
            ViewAppointmentsOfDoctor(hospital);
            break;
        case "5":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}


static void AddDoctor(Hospital hospital)
{
    Console.Write("Enter doctor's name: ");
    string name = Console.ReadLine();
    hospital.AddDoctor(new Doctor(name));
    Console.WriteLine("Doctor added successfully.");
}

static void ViewAllDoctors(Hospital hospital)
{
    List<Doctor> doctors = hospital.GetDoctors();
    if (doctors.Count == 0)
    {
        Console.WriteLine("No doctors available.");
    }
    else
    {
        Console.WriteLine("Doctors:");
        foreach (Doctor doctor in doctors)
        {
            Console.WriteLine(doctor.Name);
        }
    }
}

static void ScheduleAppointment(Hospital hospital)
{
    Console.Write("Enter doctor's name: ");
    string doctorName = Console.ReadLine();
    Doctor doctor = hospital.GetDoctor(doctorName);

    if (doctor == null)
    {
        Console.WriteLine("Doctor not found.");
        return;
    }

    Console.Write("Enter patient name: ");
    string patientName = Console.ReadLine();

    Console.Write("Enter appointment date and time (yyyy-MM-dd HH:mm): ");
    if (DateTime.TryParse(Console.ReadLine(), out DateTime appointmentDate))
    {
        if (doctor.ScheduleAppointment(new Appointment(patientName, appointmentDate)))
        {
            Console.WriteLine("Appointment scheduled successfully.");
        }
        else
        {
            Console.WriteLine("Failed to schedule appointment. The doctor already has an appointment at that time.");
        }
    }
    else
    {
        Console.WriteLine("Invalid date and time format.");
    }
}

static void ViewAppointmentsOfDoctor(Hospital hospital)
{
    Console.Write("Enter doctor's name: ");
    string doctorName = Console.ReadLine();
    Doctor doctor = hospital.GetDoctor(doctorName);

    if (doctor == null)
    {
        Console.WriteLine("Doctor not found.");
        return;
    }

    List<Appointment> appointments = doctor.GetAppointments();
    if (appointments.Count == 0)
    {
        Console.WriteLine("No appointments scheduled.");
    }
    else
    {
        Console.WriteLine("Appointments:");
        foreach (Appointment appointment in appointments)
        {
            Console.WriteLine($"Patient: {appointment.PatientName}, Date: {appointment.Date}");
        }
    }
}