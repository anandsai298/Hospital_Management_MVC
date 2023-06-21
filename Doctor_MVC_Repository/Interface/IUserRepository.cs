using Doctor_MVC_Model;
using DoctorMVCModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorMVCRepository.Interface
{
    public interface IUserRepository
    {
        public UserRegistrationModel RegisterUser(UserRegistrationModel registration);
        public UserLoginModel UserLogin(UserLoginModel logmodel);
    }
}
