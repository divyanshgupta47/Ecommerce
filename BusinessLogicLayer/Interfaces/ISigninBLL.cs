using EcommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.BusinessLogicLayer.Interfaces
{
    public interface ISigninBLL
    {
        UserInfo GetUserInfo(Users users);

        bool VerifyUser(Users users);

        bool UserExists(string userid);

        bool UpdateUserInfo(UserInfo userInfo);
    }
}
