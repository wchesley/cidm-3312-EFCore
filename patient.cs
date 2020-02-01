using System;

namespace Homework_2
{
    class patient
    {
        //General crud layer object to work with
        crud crudObj = new crud();

        ///<summary>
        /// Takes user input to create new patient object.
        ///</summary>
        public void createPatient() 
        {
            PatientsModel patientToBe = new PatientsModel();
            Console.WriteLine("Enter Patient First name: ");
            patientToBe.fName = Console.ReadLine();
            Console.WriteLine("Enter Patient Last Name: ");
            patientToBe.lName = Console.ReadLine();
            Console.WriteLine("Enter Patient Age: ");
            int.TryParse(Console.ReadLine(), out int Age);
            patientToBe.age = Age;
            Console.WriteLine("Enter M or F for Gender: ");
            string gender = Console.ReadLine();
            patientToBe.Gender = gender[0];
            Console.WriteLine("Enter Admit Date: (MM/DD/YYYY)");
            patientToBe.AdmitDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Has Patient had an Exam with the doctor? y/n");
            string exam = Console.ReadLine();
            exam = exam.ToUpper();
            if (exam[0] == 'Y')
            {
                patientToBe.HadExam = true;
            }
            else
            {
                patientToBe.HadExam = false;
            }
            //thought it'd be good practice to see the newly create patient object before saving it
            //although there's no functionality to go back and edit it
            Console.WriteLine($"Here is the patient you've created: \n{patientToBe.fName} {patientToBe.lName} \nAge: {patientToBe.age} \nGender: {patientToBe.Gender} \nAdmitted:{patientToBe.AdmitDate.ToString()}\n Seen Doctor? {patientToBe.HadExam}");
            Console.WriteLine("Would you like to save it?");
            string resp = Console.ReadLine();
            resp = resp.ToUpper();
            if (resp[0] == 'Y')
            {
                crud db = new crud();
                db.CreatePatient(patientToBe);
            }
        }
        ///<summary>
        /// Wrapper method to list all patients.
        ///</summary>
        public void getAllPatients()
        {
            crudObj.ReadAllPatients();
        }

        ///<summary>
        /// Takes user input for patient id, uses that id to find and return patient object
        ///</summary>
        public PatientsModel findPatient()
        {
            Console.WriteLine("Enter Patient ID: ");
            string input = Console.ReadLine();
            int.TryParse(input, out int iD);
            var foundPatient = crudObj.ReadPatient(iD);
            if(foundPatient == null)
            {
                Console.WriteLine("No patient by that ID exists");
                return null; 
            }
            else
            {
                Console.WriteLine($"Found Patient:\nID: {foundPatient.PatientsModelID}\nName: {foundPatient.fName} {foundPatient.lName}\nAge: {foundPatient.age}\nAdmitDate: {foundPatient.AdmitDate.ToString()}\nHad Exam: {foundPatient.HadExam}");
                return foundPatient; 
            }
        }

        ///<summary>
        /// Finds a patient using findPatient()
        /// Then takes user input to update name, age and exam status
        ///</summary>
        public void updatePatient()
        {
            var patient = findPatient();
            Console.WriteLine("Update First Name? Y/N");
            string input = Console.ReadLine();
            input.ToUpper();
            if (input == "Y")
            {
                Console.Write(patient.fName);
                patient.fName = Console.ReadLine();
            }
            Console.WriteLine("Update Last Name? Y/N");
            input = Console.ReadLine();
            input.ToUpper();
            if (input == "Y")
            {
                Console.Write(patient.lName);
                patient.lName = Console.ReadLine();
            }
            Console.WriteLine("Update Age? Y/N");
            input = Console.ReadLine();
            input.ToUpper();
            if (input == "Y")
            {
                Console.Write(patient.age);
                int.TryParse(Console.ReadLine(), out int Age);
                patient.age = Age;
            }
            Console.WriteLine("Has Patient had an Exam with the doctor? y/n");
            string exam = Console.ReadLine();
            exam = exam.ToUpper();
            if (exam[0] == 'T')
            {
                patient.HadExam = true;
            }
            else
            {
                patient.HadExam = false;
            }
            Console.WriteLine($"Here is the updated patient: \n{patient.fName} {patient.lName} \nAge: {patient.age} \nGender: {patient.Gender} \nAdmitted:{patient.AdmitDate.ToString()}\n Seen Doctor? {patient.HadExam}");
            Console.WriteLine("Would you like to save it? Y/N");
            string resp = Console.ReadLine();
            resp = resp.ToUpper();
            if (resp[0] == 'Y')
            {
                crudObj.UpdatePatient(patient.PatientsModelID, patient.fName, patient.lName, patient.age, patient.HadExam);
            }
            else
            {
                Console.WriteLine("Patient was not saved");
            }
        }
        
        ///<summary>
        /// Finds a patient using findPatient()
        /// then deletes that patient. 
        ///</summary>
        public void deletePatient()
        {
            var patient = findPatient();
            crudObj.DeletePatient(patient.PatientsModelID);
        }
    }
}