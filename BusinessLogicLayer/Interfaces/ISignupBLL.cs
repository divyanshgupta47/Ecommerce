using EcommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.BusinessLogicLayer.Interfaces
{
    public interface ISignupBLL
    {
        bool VerifyUserIdForSignup(string userid);

        bool CreateNewUser(Users users);
    }
}
