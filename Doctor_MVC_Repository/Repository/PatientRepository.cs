using DoctorMVCModel;
using DoctorMVCRepository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace DoctorMVCRepository.Repository
{
    public class PatientRepository:IPatientRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        public PatientRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("UserDBConnection");//Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DoctorList; Integrated Security=true
            this.configuration = configuration;
        }
        public PatientModel PatientDetails(PatientModel patmodel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("PatientSP", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", patmodel.UserID);
                    command.Parameters.AddWithValue("@ProfilePic", patmodel.ProfilePic);
                    command.Parameters.AddWithValue("@Gender", patmodel.Gender);
                    command.Parameters.AddWithValue("@Age", patmodel.Age);
                    command.Parameters.AddWithValue("@BloodGroup", patmodel.BloodGroup);
                    command.Parameters.AddWithValue("@MedicalHistory", patmodel.MedicalHistory);
                    command.Parameters.AddWithValue("@CreatedAt", patmodel.CreatedID);
                    command.Parameters.AddWithValue("@UpdatedAt", patmodel.UpdatedAt);
                    command.Parameters.AddWithValue("@IsTrash", patmodel.IsTrash);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return patmodel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public List<PatientModel> GetAllPatientDetails()
        {
            List<PatientModel> patmod=new List<PatientModel> ();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using(connection)
                {
                    SqlCommand command = new SqlCommand("GetAllPatientRecords", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            PatientModel patientModel = new PatientModel();
                            patientModel.PatientID = reader.GetInt32(0);
                            patientModel.UserID = reader.GetInt32(1);
                            patientModel.ProfilePic = reader.GetString(2);
                            patientModel.Gender = reader.GetString(3);
                            patientModel.Age = reader.GetInt32(4);
                            patientModel.BloodGroup = reader.GetString(5);
                            patientModel.MedicalHistory = reader.GetString(6);
                            patientModel.CreatedID = reader.GetDateTime(7);
                            patientModel.UpdatedAt = reader.GetDateTime(8);
                            patientModel.IsTrash = reader["IsTrash"] == DBNull.Value ? default : reader.GetBoolean("IsTrash");
                            patmod.Add(patientModel);
                        }
                    }
                }
                return patmod;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public PatientModel GetAllPatientDetails_UserID(int userID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("GetPatientDetailsSP", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("UserID", userID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            PatientModel patientModel = new PatientModel();
                            patientModel.PatientID = reader.GetInt32(0);
                            patientModel.UserID = reader.GetInt32(1);
                            patientModel.ProfilePic = reader.GetString(2);
                            patientModel.Gender = reader.GetString(3);
                            patientModel.Age = reader.GetInt32(4);
                            patientModel.BloodGroup = reader.GetString(5);
                            patientModel.MedicalHistory = reader.GetString(6);
                            patientModel.CreatedID = reader.GetDateTime(7);
                            patientModel.UpdatedAt = reader.GetDateTime(8);
                            patientModel.IsTrash = reader["IsTrash"] == DBNull.Value ? default : reader.GetBoolean("IsTrash");
                            return patientModel;
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
