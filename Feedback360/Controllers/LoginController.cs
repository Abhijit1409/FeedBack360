using Microsoft.AspNetCore.Mvc;
using BusinessFeedback360.DTOModels;
using BusinessFeedback360;
namespace Feedback360.Controllers
{
    public class LoginController : Controller
    {
        LogIn_BL _blLogIn = null;
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVM_User objlogin)
        {
            if (ModelState.IsValid)
            {
                _blLogIn = new LogIn_BL();
                var result_Bl = _blLogIn.IsLoggedIn(objlogin);
                if (result_Bl != null)
                {
                    if (result_Bl?.isFirstLogin == null && result_Bl.isSuccesslOGIN)
                    {
                        HttpContext.Session.SetString("_sessionUserid", result_Bl.User_ID);
                        return RedirectToAction("ChangePassword", "Password");
                    }
                    else if(result_Bl?.isFirstLogin != null && result_Bl.isSuccesslOGIN)
                    {
                        HttpContext.Session.SetString("_sessionUserid", result_Bl.User_ID);
                        return RedirectToAction("Index", "Home");
                    }
                }
                if(!result_Bl.isSuccesslOGIN && result_Bl.isFirstLogin == null)
                { 
                    ViewData["Error_Message"] = "Invalid UserId or Password"; 
                }

            }
            
            return View(objlogin);
            
        }
    }
}
