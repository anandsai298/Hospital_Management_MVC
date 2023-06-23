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
    public class AdminRepository:IAdminRepository
    {
        private readonly IConfiguration configuration;
        private readonly string? connectionString;
        public AdminRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.connectionString = configuration.GetConnectionString("UserDBConnection");
        }
        public List<UserRegistrationModel> GetAllUserData()
        {
            List<UserRegistrationModel> regmodel = new List<UserRegistrationModel>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("GetAllRecords", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserRegistrationModel registration = new UserRegistrationModel();
                            registration.UserID = reader.GetInt32(0);
                            registration.UserName = reader.GetString(1);
                            registration.EmailID = reader.GetString(2);
                            registration.Password = reader.GetString(3);
                            registration.PhoneNumber = reader.GetInt64(4);
                            registration.CreatedAt = reader.GetDateTime(5);
                            registration.UpdatedAt = reader.GetDateTime(6);
                            registration.Trash = reader["Trash"] == DBNull.Value ? default : reader.GetBoolean("Trash");
                            registration.RoleID = reader.GetInt32(8);
                            regmodel.Add(registration);
                        }
                    }
                }
                return regmodel;
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
