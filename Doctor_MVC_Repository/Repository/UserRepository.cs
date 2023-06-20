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
        public UserRegistrationModel UserLogin(UserLoginModel logmodel,string emailID,string password)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("UserLoginSP", connection);
                    CommandType commandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmailID", emailID);
                    command.Parameters.AddWithValue("@Password", password);
                    connection.Open();
                    command.ExecuteNonQuery();
                    SqlDataReader reader= command.ExecuteReader();
                    if (reader.Read())
                    {
                        UserRegistrationModel registration = new UserRegistrationModel();
                        registration.UserID=reader.GetInt32(0);
                        registration.UserName=reader.GetString(1);
                        registration.EmailID = reader.GetString(2);
                        registration.Password = reader.GetString(3);
                        registration.PhoneNumber = reader.GetInt64(4);
                        registration.CreatedAt = reader.GetDateTime(5);
                        registration.UpdatedAt = reader.GetDateTime(6);
                        registration.Trash = reader.GetBoolean(7);
                        registration.RoleID = reader.GetInt32(8);
                        return registration;
                    }
                }
                return null ;
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
