using DoctorMVCModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorMVCBusiness.Interface
{
    public interface IDoctorBusiness
    {
        public DoctorModel DoctorDetails(DoctorModel docmodel);
        public List<DoctorModel> GetAllDoctorDetails();
        public DoctorModel GetAllDoctorDetails_UserID(int userID);
        public DoctorModel GetAllDoctorDetails_DoctorID(int DoctorID);
    }
}
