using EcommerceAPI.BusinessLogicLayer.Interfaces;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [Route("/api/ecommerce/[controller]")]
    public class SignUPController : Controller
    {
        private ISignupBLL _signupBLL;
        public SignUPController(ISignupBLL signupBLL)
        {
            _signupBLL = signupBLL;
        }


        [HttpPost]
        [Route("VerifyUserIdForSignup")]
        public ActionResult VerifyUserIdForSignup(string userid)
        {
            if (_signupBLL.VerifyUserIdForSignup(userid))
            {
                return Ok("UserId verified");
            }
            else
            {
                return Ok("UserId is not verified. Please another userid.");
            }
        }

        [HttpPost]
        [Route("CreateNewUser")]
        public ActionResult CreateNewUser(Users users)
        {
            if(_signupBLL.CreateNewUser(users))
            {
                return Ok("User has been created successfully");
            }
            else
            {
                return Ok("User creation failed");
            }
        }
    }
}
