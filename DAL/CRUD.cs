using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Homework_2
{
    class crud
    {

        // CONNECTION: 
        //single database object to work with: 
        AppDBContext DB = new AppDBContext();
        public crud()
        {
            //ensures database is created when class is instantiated
            DB.Database.EnsureCreated();
        }

        // CREATE: 
        ///<summary>
        /// Takes whole PatientsModel object and adds it to the database.
        ///</summary>
        public void CreatePatient(PatientsModel patient)
        {
            DB.Add(patient);
            DB.SaveChanges();

        }
        // READ: Find by PKID; Returns whole PatientModel;
        ///<summary>
        /// Takes patient id as int to find patient object
        ///</summary> 
        ///<returns>
        /// Returns Patient object if patient is found, else returns null
        ///</returns>
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

        ///<summary>
        /// Lists all patients in database
        ///</summary>
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
        ///<summary>
        /// finds patient using ReadPatient(); then updates first name, last name, age and exam status
        ///</summary>
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
        ///<summary>
        /// Finds patient using ReadPatient(). then deletes that patient.
        ///</summary>
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