using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTask
{
    public class Hospital
    {
        private List<Doctor> doctors;

        public Hospital()
        {
            doctors = new List<Doctor>();
        }

        public void AddDoctor(Doctor doctor)
        {
            doctors.Add(doctor);
        }

        public List<Doctor> GetDoctors()
        {
            return doctors;
        }

        public Doctor GetDoctor(string name)
        {
            return doctors.FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
