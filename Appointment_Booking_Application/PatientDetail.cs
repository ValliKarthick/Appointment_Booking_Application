using System.Collections.Generic;

namespace Appointment_Booking_Application
{
    public class PatientDetail
    {
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public int PatientComplaint { get; set; }
        public static Dictionary<Specialist, string> GetDictionary()
        {
            Dictionary<Specialist, string> doctors = new Dictionary<Specialist, string>();
            doctors.Add(Specialist.ENT, "Dr. Murugadoss MD DLO");
            doctors.Add(Specialist.Gyanocologist, "Dr. Bala Abirami MD DGO");
            doctors.Add(Specialist.Pediatrician, "Dr. Amudhan MD DCH");
            doctors.Add(Specialist.GeneralPhysician, "Dr. Natarajan MD");
            doctors.Add(Specialist.Cardiologist, "");
            return doctors;
        }
    }
}
