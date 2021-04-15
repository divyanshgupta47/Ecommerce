using EcommerceAPI.BusinessLogicLayer.Interfaces;
using EcommerceAPI.DataAccessLayer.Interfaces;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [Route("/api/ecommerce/[controller]")]
    public class SigninController : Controller
    {
        private ISigninBLL _signinBLL;
        private IDatabaseContext _databaseContext;
        public SigninController(ISigninBLL signinBLL,IDatabaseContext databaseContext)
        {
            _signinBLL = signinBLL;
            _databaseContext = databaseContext;
        }
        [HttpPost]
        [Route("GetUserInfo")]
        public ActionResult GetUserInfo(Users users)
        {
            //Verify Users first
            if(_signinBLL.VerifyUser(users))
            {
                JsonResult jsonResult = new JsonResult(_signinBLL.GetUserInfo(users));
                return Ok(jsonResult);
            }
            else
            {
                return Ok("UserId or Password is incorrect");
            }
        }

        [HttpPost]
        [Route("UpdateUserInfo")]
        public ActionResult UpdateUserInfo(UserInfo userInfo)
        {
            if(_signinBLL.UserExists(userInfo.UserId))
            {
                if(_signinBLL.UpdateUserInfo(userInfo))
                {
                    return Ok("User info saved successfully.");
                }
                else
                {
                    return Ok("User info is not saved.");
                }
            }
            else
            {
                return Ok("User does not exists.");
            }
        }
    }
}
