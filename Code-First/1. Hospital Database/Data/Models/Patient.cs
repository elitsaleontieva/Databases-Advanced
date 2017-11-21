using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            Prescriptions = new List<PatientMedicament>();

            Diagnoses = new List<Diagnose>();

            Visitations = new List<Visitation>();
        }

        public int PatientId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int MyProperty { get; set; }

        public string Adress { get; set; }

        public string Email { get; set; }

        public bool HasInsurance { get; set; }


        public ICollection<Visitation> Visitations { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
