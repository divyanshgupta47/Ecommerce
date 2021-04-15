using EcommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.DataAccessLayer.Interfaces
{
    public interface IUsersDAL
    {
        bool VerifyUsers(Users users);

        UserInfo GetUserInfo(Users users);

        bool UserExists(string userid);

        bool UpdateUserInfo(UserInfo userInfo);

        bool VerifyUserIdForSignup(string userid);

        bool CreateNewUser(Users users);
    }
}
