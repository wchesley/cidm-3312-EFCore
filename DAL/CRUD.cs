using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Homework_2
{
    class crud
    {

        // CONNECTION: 
        AppDBContext DB = new AppDBContext();
        public crud()
        {
            DB.Database.EnsureCreated();
        }

        // CREATE: 
        public void CreatePatient(PatientsModel patient)
        {


            DB.Add(patient);
            DB.SaveChanges();

        }
        // READ: Find by PKID; Returns whole PatientModel; 
        public PatientsModel ReadPatient(int iD)
        {

            try
            {
                var patient = DB.patient.Find(iD);
                return patient;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }


        }
        public void ReadAllPatients()
        {

            var AllPatients = DB.patient.ToList();
            Console.WriteLine("Found the Following Patients: ");
            foreach (var patient in AllPatients)
            {
                Console.WriteLine($"ID: {patient.PatientsModelID} Name: {patient.fName } {patient.lName} Age: {patient.age} Admitted: {patient.AdmitDate.ToString()} Seen Doctor: {patient.HadExam}");
            }

        }
        // UPDATE: 
        public void UpdatePatient(int iD, string newFName, string newLName, int newAge, bool newExam)
        {
            var foundPatient = ReadPatient(iD);

            try
            {
                DB.patient.Update(foundPatient);
                foundPatient.fName = newFName;
                foundPatient.lName = newLName;
                foundPatient.age = newAge;
                foundPatient.HadExam = newExam;
                DB.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        // DELETE: 

        public void DeletePatient(int iD)
        {
            var foundPatient = ReadPatient(iD);

            try
            {
                DB.Remove(foundPatient);
                DB.SaveChanges();
                Console.WriteLine($"Patient {foundPatient.fName} {foundPatient.lName} was deleted.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}