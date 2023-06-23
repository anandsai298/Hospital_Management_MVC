using DoctorMVCModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorMVCBusiness.Interface
{
    public interface IPatientBusiness
    {
        public PatientModel PatientDetails(PatientModel patmodel);
        public List<PatientModel> GetAllPatientDetails();
        public PatientModel GetAllPatientDetails_UserID(int userID);
    }
}
