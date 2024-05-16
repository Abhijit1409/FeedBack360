using Microsoft.AspNetCore.Mvc;

namespace Feedback360.Controllers
{
    public class PasswordController : Controller
    {
        public IActionResult ChangePassword()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult ChangePassword()
        //{
        //    return View();
        //}

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
