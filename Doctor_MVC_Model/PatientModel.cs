using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorMVCModel
{
    public class PatientModel
    {
        public int PatientID { get; set; }
        public int UserID { get; set; }
        public string ProfilePic {  get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set;}
        public string MedicalHistory { get; set; }
        public DateTime CreatedID { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsTrash { get; set; }
    }
}
