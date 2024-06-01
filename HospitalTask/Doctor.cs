using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTask
{
    public class Doctor
    {
        public string Name { get; set; }
        private List<Appointment> appointments;

        public Doctor(string name)
        {
            Name = name;
            appointments = new List<Appointment>();
        }

        public bool ScheduleAppointment(Appointment appointment)
        {
            if (appointments.Any(a => a.Date == appointment.Date))
            {
                return false; // Appointment slot is already taken
            }

            appointments.Add(appointment);
            return true;
        }

        public List<Appointment> GetAppointments()
        {
            return appointments;
        }
    }
}
