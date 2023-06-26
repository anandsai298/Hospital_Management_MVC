using DoctorMVCBusiness.Interface;
using DoctorMVCModel;
using DoctorMVCRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorMVCBusiness.Business
{
    public class PatientBusiness:IPatientBusiness
    {
        private readonly IPatientRepository ipatRep;
        public PatientBusiness(IPatientRepository ipatRep)
        {
            this.ipatRep = ipatRep;
        }
        public PatientModel PatientDetails(PatientModel patmodel)
        {
            try
            {
                return ipatRep.PatientDetails(patmodel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<PatientModel> GetAllPatientDetails()
        {
            try
            {
                return ipatRep.GetAllPatientDetails();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }   
        public PatientModel GetAllPatientDetails_UserID(int userID)
        {
            try
            {
                return ipatRep.GetAllPatientDetails_UserID(userID);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public PatientModel GetAllDoctorDetails_PatientID(int PatientID)
        {
            try
            {
                return ipatRep.GetAllDoctorDetails_PatientID(PatientID);
            }
            catch(Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
    }
}
