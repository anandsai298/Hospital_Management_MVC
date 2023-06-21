using Doctor_MVC_Model;
using DoctorMVCModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorMVCBusiness.Interface
{
    public interface IUserBusiness
    {
        public UserRegistrationModel RegisterUser(UserRegistrationModel registration);
        public UserRegistrationModel UserLogin(UserLoginModel logmodel);
        public List<UserRegistrationModel> GetAllUserData();
    }
}

