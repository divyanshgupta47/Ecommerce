using EcommerceAPI.BusinessLogicLayer.Interfaces;
using EcommerceAPI.DataAccessLayer.Interfaces;
using EcommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.BusinessLogicLayer.Implementations
{
    public class SignupBLL : ISignupBLL
    {

        private IUsersDAL _usersDAL;
        public SignupBLL(IUsersDAL usersDAL)
        {
            _usersDAL = usersDAL;
        }

        public bool CreateNewUser(Users users)
        {
            return _usersDAL.CreateNewUser(users);
        }

        public bool VerifyUserIdForSignup(string userid)
        {
            return _usersDAL.VerifyUserIdForSignup(userid);
        }
    }
}
