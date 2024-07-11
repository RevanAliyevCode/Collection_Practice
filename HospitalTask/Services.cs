using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTask
{
    public static class Services
    {
        public static void AddDoctor(Hospital hospital)
        {
            Console.Write("Enter doctor's name: ");
            string name = Console.ReadLine();
            hospital.AddDoctor(new Doctor(name));
            Console.WriteLine("Doctor added successfully.");
        }

        public static void ViewAllDoctors(Hospital hospital)
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

        public static void ScheduleAppointment(Hospital hospital)
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
                if (appointmentDate < DateTime.Now)
                {
                    Console.WriteLine("Date can not be earlier than now");
                    return;
                }
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

        public static void ViewAppointmentsOfDoctor(Hospital hospital)
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
    }
}
