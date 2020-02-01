using System;

namespace Homework_2
{
    class Program
    {
        static void Main(string[] args)
        {
                // PatientsModel patient = new PatientsModel { fName = "Roxie", lName = "Hart", age = 34, Gender = 'F', AdmitDate = DateTime.Parse("5/28/1924"), HadExam = true };
                // PatientsModel patient = new PatientsModel { fName = "Grace", lName = "Bertrand", age = 24, Gender = 'F', AdmitDate = DateTime.Parse("1/15/1939"), HadExam = true };
                // PatientsModel patient2 = new PatientsModel { fName = "Harold", lName = "Hill", age = 52, Gender = 'M', AdmitDate = DateTime.Parse("7/1/1943"), HadExam = false };
                // PatientsModel patient3 = new PatientsModel { fName = "Herman", lName = "Dietrich", age = 47, Gender = 'M', AdmitDate = DateTime.Parse("9/12/1936"), HadExam = true };
                // crud crudObj = new crud();
                // crudObj.CreatePatient(patient);
                // crudObj.CreatePatient(patient2);
                // crudObj.CreatePatient(patient3);
                patient patientObj = new patient();

            do
            {
                Console.WriteLine("Make a Selection:\n1. Create Patient\n2. List All Patients\n3. Find Patient\n4. Update Patient Info \n5. Delete Patient\n6. Exit");
                string selection = Console.ReadLine();
                switch(selection)
                {
                    case "1":
                    patientObj.createPatient(); 
                    break;
                    case "2":
                    patientObj.getAllPatients();
                    break;
                    case "3":
                    patientObj.findPatient();
                    break;
                    case "4":
                    patientObj.updatePatient();
                    break;
                    case "5":
                    patientObj.deletePatient();
                    break;
                    default:
                    return; 
                }
            }
            while(Console.ReadLine() != "6");
        }
    }
}
