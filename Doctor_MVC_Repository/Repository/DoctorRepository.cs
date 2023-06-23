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
    public class DoctorRepository:IDoctorRepository
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        public DoctorRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("UserDBConnection");//Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DoctorList; Integrated Security=true
            this.configuration = configuration;
        }
        public DoctorModel DoctorDetails(DoctorModel docmodel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("DoctorSP", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", docmodel.UserID);
                    command.Parameters.AddWithValue("@ProfilePic", docmodel.ProfilePic);
                    command.Parameters.AddWithValue("@Qualification", docmodel.Qualification);
                    command.Parameters.AddWithValue("@Specialisation", docmodel.Specialisation);
                    command.Parameters.AddWithValue("@YearsOfExperience", docmodel.YearsOfExperience);
                    command.Parameters.AddWithValue("@CreatedAt", docmodel.CreatedAt);
                    command.Parameters.AddWithValue("@UpdatedAt", docmodel.UpdatedAt);
                    command.Parameters.AddWithValue("@IsTrash", docmodel.IsTrash);
                    connection.Open();
                    command.ExecuteNonQuery();                    
                }
                return docmodel;
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
        public List<DoctorModel> GetAllDoctorDetails()
        {
            List<DoctorModel> docmod=new List<DoctorModel>();
            SqlConnection connection=new SqlConnection(connectionString);
            try
            {
                using(connection)
                {
                    SqlCommand command = new SqlCommand("GetAllDoctorRecords", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            DoctorModel doctorModel = new DoctorModel();
                            doctorModel.DoctorID = reader.GetInt32(0);
                            doctorModel.UserID = reader.GetInt32(1);
                            doctorModel.ProfilePic = reader.GetString(2);
                            doctorModel.Qualification = reader.GetString(3);
                            doctorModel.Specialisation = reader.GetString(4);
                            doctorModel.YearsOfExperience = reader.GetInt32(5);
                            doctorModel.CreatedAt = reader.GetDateTime(6);
                            doctorModel.UpdatedAt = reader.GetDateTime(7);
                            doctorModel.IsTrash = reader["IsTrash"] == DBNull.Value ? default : reader.GetBoolean("IsTrash");
                            docmod.Add(doctorModel);
                        }
                    }
                }
                return docmod;
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
        public DoctorModel GetAllDoctorDetails_UserID(int userID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("GetDoctorDetailsSP", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("UserID", userID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DoctorModel doctorModel = new DoctorModel();
                            doctorModel.DoctorID = reader.GetInt32(0);
                            doctorModel.UserID = reader.GetInt32(1);
                            doctorModel.ProfilePic = reader.GetString(2);
                            doctorModel.Qualification = reader.GetString(3);
                            doctorModel.Specialisation = reader.GetString(4);
                            doctorModel.YearsOfExperience = reader.GetInt32(5);
                            doctorModel.CreatedAt = reader.GetDateTime(6);
                            doctorModel.UpdatedAt = reader.GetDateTime(7);
                            doctorModel.IsTrash = reader["IsTrash"] == DBNull.Value ? default : reader.GetBoolean("IsTrash");
                            return doctorModel;
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
        public DoctorModel GetAllDoctorDetails_DoctorID(int DoctorID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("GetDoctorDetailsDocIDSP", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("DoctorID", DoctorID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DoctorModel doctorModel = new DoctorModel();
                            doctorModel.DoctorID = reader.GetInt32(0);
                            doctorModel.UserID = reader.GetInt32(1);
                            doctorModel.ProfilePic = reader.GetString(2);
                            doctorModel.Qualification = reader.GetString(3);
                            doctorModel.Specialisation = reader.GetString(4);
                            doctorModel.YearsOfExperience = reader.GetInt32(5);
                            doctorModel.CreatedAt = reader.GetDateTime(6);
                            doctorModel.UpdatedAt = reader.GetDateTime(7);
                            doctorModel.IsTrash = reader["IsTrash"] == DBNull.Value ? default : reader.GetBoolean("IsTrash");
                            return doctorModel;
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
