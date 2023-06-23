using DoctorMVCBusiness.Interface;
using DoctorMVCModel;
using DoctorMVCRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorMVCBusiness.Business
{
    public class DoctorBusiness:IDoctorBusiness
    {
        private readonly IDoctorRepository idocRep;
        public DoctorBusiness(IDoctorRepository idocRep)
        {
            this.idocRep = idocRep;
        }
        public DoctorModel DoctorDetails(DoctorModel docmodel)
        {
            try
            {
                return idocRep.DoctorDetails(docmodel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<DoctorModel> GetAllDoctorDetails()
        {
            try
            {
                return idocRep.GetAllDoctorDetails();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DoctorModel GetAllDoctorDetails_UserID(int userID)
        {
            try
            {
                return idocRep.GetAllDoctorDetails_UserID(userID);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DoctorModel GetAllDoctorDetails_DoctorID(int DoctorID)
        {
            try
            {
                return idocRep.GetAllDoctorDetails_DoctorID(DoctorID);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
