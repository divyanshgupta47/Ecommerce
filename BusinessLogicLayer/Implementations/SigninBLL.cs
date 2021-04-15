using EcommerceAPI.BusinessLogicLayer.Interfaces;
using EcommerceAPI.DataAccessLayer.Interfaces;
using EcommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.BusinessLogicLayer.Implementations
{
    public class SigninBLL : ISigninBLL
    {
        private IUsersDAL _usersDAL;
        public SigninBLL(IUsersDAL usersDAL)
        {
            _usersDAL = usersDAL;
        }
        public UserInfo GetUserInfo(Users users)
        {

            UserInfo result = _usersDAL.GetUserInfo(users);

            return result;
        }

        public bool UpdateUserInfo(UserInfo userInfo)
        {
            return _usersDAL.UpdateUserInfo(userInfo);
        }

        public bool UserExists(string userid)
        {
            return _usersDAL.UserExists(userid);
        }

        public bool VerifyUser(Users users)
        {
            return _usersDAL.VerifyUsers(users);
        }
    }
}
