using DoctorMVCBusiness.Interface;
using DoctorMVCModel;
using DoctorMVCRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorMVCBusiness.Business
{
    public class AdminBusiness:IAdminBusiness
    {
        private readonly IAdminRepository iadmin;
        public AdminBusiness(IAdminRepository iadmin)
        {
            this.iadmin = iadmin;
        }
        public List<UserRegistrationModel> GetAllUserData()
        {
            try
            {
                return iadmin.GetAllUserData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
