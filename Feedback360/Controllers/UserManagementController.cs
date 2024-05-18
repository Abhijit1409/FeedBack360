using Microsoft.AspNetCore.Mvc;
using BusinessFeedback360;
using RepoFeedback360.Model;
using BusinessFeedback360.DTOModels;

namespace Feedback360.Controllers
{
    public class UserManagementController : Controller
    {
        BLUserManagement? _objblusermanagement = null;
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserRegistration() 
        {
            try 
            {
              _objblusermanagement = new BLUserManagement();
              ViewBag.RoleDetails = _objblusermanagement.GetAllRoles();
              ViewBag.DesignationDetails = _objblusermanagement.GetAllDesignations();
            }
            catch(Exception ex)
            {

            }
            return View();
        }
        [HttpPost]
        public IActionResult UserRegistration(UserDetailsVM _userDetailsVM)
        {
            bool Save_result = false;
            try 
            { 
            _objblusermanagement = new BLUserManagement();
            ViewBag.RoleDetails = _objblusermanagement.GetAllRoles();
            ViewBag.DesignationDetails = _objblusermanagement.GetAllDesignations();
            
             Save_result =_objblusermanagement.saveUserDetails(_userDetailsVM);
            if (Save_result) ViewData["SaveStatus"] = "User Saved Successfully.";
            else ViewData["FailedStatus"] = "Save User Failed";
            }
            catch (Exception ex) 
            {
                ViewData["FailedStatus"] = ex.Message; 
            }
            return View();
        }
    }
}
