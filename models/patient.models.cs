using System; 

namespace Homework_2
{
    class PatientsModel 
    {
        public int PatientsModelID {get; set;}
        public string fName {get; set;}
        public string lName {get; set;}
        public int age {get; set;}
        public char Gender {get; set;}
        public DateTime AdmitDate {get; set;}
        public bool HadExam {get; set;}

    }
}