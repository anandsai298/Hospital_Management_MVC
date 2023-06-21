using Doctor_MVC_Model;
using DoctorMVCModel;
using DoctorMVCRepository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DoctorMVCRepository.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly IConfiguration configuration;
        private readonly  string connectionString;
        public UserRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("UserDBConnection");//Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DoctorList; Integrated Security=true
            this.configuration = configuration;
        }
        public UserRegistrationModel RegisterUser(UserRegistrationModel registration)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("UserTableSP", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", registration.UserName);
                    command.Parameters.AddWithValue("@EmailID", registration.EmailID);
                    command.Parameters.AddWithValue("@Password", registration.Password);
                    command.Parameters.AddWithValue("@PhoneNumber", registration.PhoneNumber);
                    command.Parameters.AddWithValue("@CreatedAt", registration.CreatedAt);
                    command.Parameters.AddWithValue("@UpdatedAt", registration.UpdatedAt);
                    command.Parameters.AddWithValue("RoleID", registration.RoleID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return registration;
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
        public UserLoginModel UserLogin(UserLoginModel logmodel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("UserLoginSP", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmailID", logmodel.EmailID);
                    command.Parameters.AddWithValue("@Password", logmodel.Password);
                    connection.Open();
                    var res=command.ExecuteNonQuery();
                    
                    return logmodel;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close ();
            }
        }
    }
}
