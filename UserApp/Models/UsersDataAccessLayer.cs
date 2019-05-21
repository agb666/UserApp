using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;


namespace UserApp.Models
{
    public class UserDataAccessLayer : IUserDataAccessLayer
    {


        public IConfiguration _configuration;
       
        public UserDataAccessLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public IDbConnection connection
        //{
        //    get
        //    {
        //        return new SqlConnection(_configuration.GetConnectionString("UserConnection"));
        //    }
        //}



        public bool AddUser(string email, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("UserConnection")))
                {

                    using (SqlCommand command = new SqlCommand(UserSQLInsert(), conn))
                    {
                        command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                        command.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;

                        conn.Open();
                        //Async
                        command.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                return true;
                }
            catch(Exception ex)
            {
                return false;
            }
        }


        public string UserExist(string email, string password)
        {

            throw new NotImplementedException();

            string retEmail = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("UserConnection")))
                {

                    using (SqlCommand command = new SqlCommand(UserExistsSQL(), conn))
                    {
                        command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;

                        conn.Open();
                        retEmail = (string)command.ExecuteScalar();
                        conn.Close();
                    }
                }
                return retEmail;
            }
            catch (Exception ex)
            {
                return retEmail;
            }
        }

        private string UserSQLInsert()
        {
            return "INSERT [dbo].[User] ([Email], [Password]) Values(@email, @password)";
        }


        private string UserExistsSQL()
        {
            return "SELECT Email FROM [dbo].[User] WHERE Email = @email";
        }

        private string InsertUserSpoc()
        {
            return "sp_ins_New_User";
        }



    }
}

