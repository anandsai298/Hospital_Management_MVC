using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorMVCModel
{
    public class DoctorModel
    {
        public int DoctorID { get; set; }
        public int UserID { get; set; }
        public string ProfilePic { get; set; }
        public string Qualification { get; set; }
        public string Specialisation { get; set; }
        public int YearsOfExperience { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsTrash { get; set;}
    }
}
