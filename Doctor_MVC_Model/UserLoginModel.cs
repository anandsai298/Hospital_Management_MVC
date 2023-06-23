using System;
using System.ComponentModel.DataAnnotations;

namespace Doctor_MVC_Model
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="{0} Should not be Empty")]
        public string EmailID { get; set; }
        [Required(ErrorMessage = "{0} Should not be Empty")]
        public string Password { get; set; }
    }
}
