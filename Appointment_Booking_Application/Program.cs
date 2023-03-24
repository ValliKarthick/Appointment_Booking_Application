using System;
using System.Collections.Generic;

namespace Appointment_Booking_Application
{
    public enum Specialist
    {
        ENT = 1,
        Gyanocologist = 2,
        Pediatrician = 3,
        GeneralPhysician = 4,
        Cardiologist = 5
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<Specialist, string> doctors = new Dictionary<Specialist, string>();
            doctors.Add(Specialist.ENT, "Dr. Murugadoss MD DLO");
            doctors.Add(Specialist.Gyanocologist , "Dr. Bala Abirami MD DGO");
            doctors.Add(Specialist.Pediatrician, "Dr. Amudhan MD DCH");
            doctors.Add(Specialist.GeneralPhysician , "Dr. Natarajan MD");
            doctors.Add(Specialist.Cardiologist, "Dr. Ashirvatham MD DM");

            PatientDetail patientDetail = new PatientDetail();

            Console.WriteLine("Enter patient Name: ");
            patientDetail.PatientName = Console.ReadLine();
            Console.WriteLine("Enter patient Age: ");
            patientDetail.PatientAge = Convert.ToInt32(Console.ReadLine());
            bool doctorChosen = false;
            do
            {
                Console.WriteLine("Choose a doctor whom to meet ");
                foreach (Specialist specialist in doctors.Keys)
                {
                    Console.WriteLine($"{(int)specialist}. {specialist.ToString()}");
                }
                patientDetail.PatientComplaint = int.Parse(Console.ReadLine());
                doctorChosen = Enum.TryParse(patientDetail.PatientComplaint.ToString(), out Specialist value);
                if (!doctorChosen)
                {
                    Console.WriteLine("Enter Valid Option");
                }
            } while (!doctorChosen);


            Console.WriteLine("Enter Appointment Request Date: ");
            DateTime appointmentRequestDate = Convert.ToDateTime(Console.ReadLine());
           
            AppointmentDateVerification appointmentDateVerification = new AppointmentDateVerification();
            string appointmentMessage = appointmentDateVerification.CheckAppointmentRequestDate(appointmentRequestDate);

            Console.WriteLine("----------");
            Console.WriteLine(appointmentMessage);
            if(appointmentMessage == "Appointment Confirmed!")
            {
                System.Random random = new Random();
                Console.WriteLine("Patient Id - " + random.Next());
                Console.WriteLine($"Please Contact {doctors[(Specialist)patientDetail.PatientComplaint]} on {appointmentRequestDate.Date.ToShortDateString()}");
            }            
            Console.WriteLine("----------");
            Console.ReadLine();
        }
    }
}
