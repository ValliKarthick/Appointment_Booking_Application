using System;
using NUnit.Framework;
using System.Reflection;
using System.Linq;

namespace Appointment_Booking_Application.Unittests
{
    [TestFixture]
    public class Appointment_BookingTests
    {
        private MethodInfo testingMethod;
        private object SUT;

        [SetUp]
        public void Initialize()
        {
            Assembly assembly = Assembly.Load("Appointment_Booking_Application");
            SUT = assembly.CreateInstance(assembly.GetTypes().Where(type => type.Name == "AppointmentDateVerification").FirstOrDefault()?.FullName,
                false, BindingFlags.CreateInstance, null, null, null, null);
            testingMethod = SUT.GetType().GetMethod("CheckAppointmentRequestDate");
        }

        [Test]
        public void Check_Dictionary()
        {
            Assembly assembly = Assembly.Load("Appointment_Booking_Application");
            var allBindings = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            if (assembly.GetType("PatientDetail") != null)
            {
                MethodInfo testMethod = assembly.GetType("PatientDetail").GetMethod("GetDictionary1", allBindings);
                Assert.IsNull(testMethod, "Method GetDictionary NOT implemented OR check spelling");

            }
        }

        [Test]
        public void Check_Return_Message_When_Date_Is_Not_A_FutureDate()
        {
            DateTime dateTime = DateTime.Now.AddDays(-1);
            Assert.AreEqual("Appointment Rejected, Date must be a future date!", testingMethod.Invoke(SUT, new object[] { dateTime }));
        }

        [Test]
        public void Check_Return_Message_When_Date_Is_Not_CurrentYear()
        {
            DateTime dateTime = DateTime.Now.AddYears(2);
            Assert.AreEqual("Appointment Rejected, You can book appointment only for the current year!", testingMethod.Invoke(SUT, new object[] { dateTime }));
        }

        [Test]
        public void Check_Return_Message_When_Date_Is_A_Monday()
        {
            DateTime dateTime = DateTime.Now.AddDays(8 - (int)DateTime.Now.DayOfWeek);
            Assert.AreEqual("Sorry!!! Appointment cannot be given on Monday!", testingMethod.Invoke(SUT, new object[] { dateTime }));
        }

        [Test]
        public void Check_Return_Message_When_Date_Is_Valid()
        {
            DateTime dateTime = DateTime.Now.AddDays(8 - (int)DateTime.Now.DayOfWeek + 2);
            Assert.AreEqual("Appointment Confirmed!", testingMethod.Invoke(SUT, new object[] { dateTime }));
        }
    }
}
