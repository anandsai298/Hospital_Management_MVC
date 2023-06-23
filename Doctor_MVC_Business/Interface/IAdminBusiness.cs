using DoctorMVCModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorMVCBusiness.Interface
{
    public interface IAdminBusiness
    {
        public List<UserRegistrationModel> GetAllUserData();
    }
}
