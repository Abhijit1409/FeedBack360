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
            _objblusermanagement = new BLUserManagement();
            ViewBag.RoleDetails = _objblusermanagement.GetAllRoles();
            ViewBag.DesignationDetails = _objblusermanagement.GetAllDesignations();
            
            _objblusermanagement.saveUserDetails(_userDetailsVM);
            return View();
        }
    }
}
