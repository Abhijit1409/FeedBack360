using Microsoft.AspNetCore.Mvc;
using BusinessFeedback360.DTOModels.Password;
using BusinessFeedback360.DTOModels;
using BusinessFeedback360;

namespace Feedback360.Controllers
{
    public class PasswordController : Controller
    {
        private LogIn_BL _logInBl;
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
            bool changepasswordStatus = _logInBl.ResetPassword_Bl(objCPVM);
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
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordVMDTO forgotPasswordVMDTO)
        {
            if (_logInBl.checkOtp(forgotPasswordVMDTO))
            {
                bool reset_Status = _logInBl.ResetPassword_Bl(new ChangePasswordVM
                {
                    NewPassword = forgotPasswordVMDTO.NewPassword,
                    User_Id = forgotPasswordVMDTO.UserId,
                    OldPassword = null
                });
                if (reset_Status) { TempData["SucessStatus"] = "Password Reset Successfully."; }
            }
            else
            {
                TempData["FailedStatus"] = "Otp Is InValid! or Otp session timeOut.";
            }
            return View();
        }
        [HttpPost]
        public IActionResult sendOTP(ForgotPasswordVMDTO forgotPasswordVMDTO)
        {
            bool status = false;
           
            int otpstatus =_logInBl.sendOtp(forgotPasswordVMDTO.UserId);
            //HttpContext.Session.SetString("OTP_Value",otpstatus.ToString());

            if ( otpstatus != 0 ? status = true : false)
            {
                TempData["SucessStatus"] = "Sucessfully sent otp on resistered Email";
            }
            else
            {
                TempData["FailedStatus"] = "Couldn't Send Otp Try again .";
            }
            return View("ForgotPassword");
        }
    }
}
