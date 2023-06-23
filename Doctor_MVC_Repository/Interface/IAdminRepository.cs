using DoctorMVCModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorMVCRepository.Interface
{
    public interface IAdminRepository
    {
        public List<UserRegistrationModel> GetAllUserData();
    }
}
