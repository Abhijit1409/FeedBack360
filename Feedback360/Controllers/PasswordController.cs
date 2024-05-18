using Microsoft.AspNetCore.Mvc;
using BusinessFeedback360.DTOModels.Password;
using BusinessFeedback360.DTOModels;
using BusinessFeedback360;

namespace Feedback360.Controllers
{
    public class PasswordController : Controller
    {
        private LogIn_BL _logInBl ;
        public PasswordController() 
        {
            this._logInBl = new LogIn_BL();
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            ChangePasswordVM objCPVM = new ChangePasswordVM();
            objCPVM.User_Id = HttpContext.Session.GetString("_sessionUserid");
            return View(objCPVM);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordVM objCPVM)
        { 
            objCPVM.User_Id = HttpContext.Session.GetString("_sessionUserid");
            bool changepasswordStatus=_logInBl.ResetPassword_Bl(objCPVM);
            if (changepasswordStatus)
            {
                ViewData["ChangepasswordStatus"] = "Password chaged successfully";
            }
            else 
            {
                ViewData["ChangepasswordStatusfailed"] = "Error While Reset the password";
            }

            return View(objCPVM);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}
    }
}
