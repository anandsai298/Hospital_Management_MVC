using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DoctorMVCModel
{
    public class UserRegistrationModel
    {
        public int UserID{ get; set; }
        public string UserName { get; set; }
        public string EmailID { get; set; } 
        public string Password { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
        public int RoleID { get; set; }
        public bool Trash { get; set; }
    }
}
