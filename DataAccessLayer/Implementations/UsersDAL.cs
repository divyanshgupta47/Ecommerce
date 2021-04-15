using EcommerceAPI.DataAccessLayer.Interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Models.Common;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace EcommerceAPI.DataAccessLayer.Implementations
{
    public class UsersDAL : IUsersDAL
    {
        private IDatabaseContext _dbContext;
        private Appsettings _appsettings;
        private string _connectionString = "";
        public UsersDAL(IDatabaseContext dbContext, IOptions<Appsettings> appSettings)
        {
            _appsettings = appSettings.Value;
            _dbContext = dbContext;
            _connectionString = _dbContext.DbConnection.ConnectionString;
        }

        public bool CreateNewUser(Users users)
        {
            // check connection
            if (!_dbContext.IsConnected)
            {
                return false;
            }
            EncryptionService encryptionService = new EncryptionService(_appsettings.EncryptionKey, _appsettings.EncrptionIV);
            string encryptedPass = encryptionService.Encrypt(users.Password);
            string script = $"INSERT INTO USERS VALUES('{users.UserId}','{encryptedPass}'); INSERT INTO USERINFO VALUES('{users.UserId}',null,null);";
            SqlConnection conn = null;
            try
            {
                using (conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(script, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return false;
            }
        }

        public UserInfo GetUserInfo(Users users)
        {
            string script = $"select * from UserInfo where UserId = '{users.UserId}';";
            try
            {
                return _dbContext.userInfo.FromSqlRaw(script).ToList().FirstOrDefault();
            }
            catch (Exception)
            {

                return new UserInfo();
            }
            
        }

        public bool UpdateUserInfo(UserInfo userInfo)
        {
            // check connection
            if (!_dbContext.IsConnected)
            {
                return false;
            }
            string script = $"UPDATE USERINFO SET UserName = '{userInfo.UserName}' , EmailId = '{userInfo.EmailId}' WHERE UserId = '{userInfo.UserId}'";
            SqlConnection conn = null;
            try
            {
                using (conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(script, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                conn.Close();
                return false;
            }
        }

        public bool UserExists(string userid)
        {
            // check connection
            if (!_dbContext.IsConnected)
            {
                return false;
            }
            string script = $"select * from users where userid = '{userid}';";

            if (_dbContext.users.FromSqlRaw(script).ToList().Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool VerifyUserIdForSignup(string userid)
        {
            // check connection
            if (!_dbContext.IsConnected)
            {
                return false;
            }
            string script = $"select * from users where userid = '{userid}'";
            if (_dbContext.users.FromSqlRaw(script).ToList().Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool VerifyUsers(Users users)
        {
            // check connection
            if (!_dbContext.IsConnected)
            {
                return false;
            }
            string script = $"select * from Users where UserId = '{users.UserId}';";
            Users user = _dbContext.users.FromSqlRaw(script).ToList().FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            else
            {
                EncryptionService encryptionService = new EncryptionService(_appsettings.EncryptionKey, _appsettings.EncrptionIV);
                string decryptedData = encryptionService.Decrypt(user.Password);


                if (decryptedData != users.Password)
                {
                    return false;
                }
                else
                    return true;
            }
        }
    }
}
