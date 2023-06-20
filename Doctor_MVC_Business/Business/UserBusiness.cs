using Doctor_MVC_Model;
using DoctorMVCBusiness.Interface;
using DoctorMVCModel;
using DoctorMVCRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorMVCBusiness.Business
{
    public class UserBusiness:IUserBusiness
    {
        private readonly IUserRepository iUserRep;
        public UserBusiness(IUserRepository iUserRep)
        {
            this.iUserRep = iUserRep;
        }
        public UserRegistrationModel RegisterUser(UserRegistrationModel registration)
        {
            try
            {
                return iUserRep.RegisterUser(registration);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public UserRegistrationModel UserLogin(UserLoginModel logmodel, string emailID, string password)
        {
            try
            {
                return iUserRep.UserLogin(logmodel,  emailID,  password);
            }
            catch(Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
