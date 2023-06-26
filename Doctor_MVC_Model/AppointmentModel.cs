using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorMVCModel
{
    public class AppointmentModel
    {
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string Reason { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedID { get; set; }
        public DateTime UpdatedID { get; set; }
        public bool Trash { get; set; }

    }
}
