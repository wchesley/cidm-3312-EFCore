using System;

namespace Homework_2
{
    class patient
    {
        crud crudObj = new crud();
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

        public void getAllPatients()
        {
            crudObj.ReadAllPatients();
        }

        public PatientsModel findPatient()
        {
            Console.WriteLine("Enter Patient ID: ");
            string input = Console.ReadLine();
            int.TryParse(input, out int iD);
            var foundPatient = crudObj.ReadPatient(iD);
            Console.WriteLine($"Found Patient:\nID: {foundPatient.PatientsModelID}\nName: {foundPatient.fName} {foundPatient.lName}\nAge: {foundPatient.age}\nAdmitDate: {foundPatient.AdmitDate.ToString()}\nHad Exam: {foundPatient.HadExam}");
            return foundPatient;
        }

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
        
        public void deletePatient()
        {
            var patient = findPatient();
            crudObj.DeletePatient(patient.PatientsModelID);
        }
    }
}