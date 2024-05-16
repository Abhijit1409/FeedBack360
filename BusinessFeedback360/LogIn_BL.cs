using BusinessFeedback360.DTOModels;
using RepoFeedback360.Abstract;
using RepoFeedback360.Model;
using RepoFeedback360.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFeedback360
{
    public class LogIn_BL : IUserDetails
    {
        private IUserDetails _userDetails;
        public LogIn_BL()
        {
           this. _userDetails = new DLUserManagement();    
        }
        public List<UserDetail> GetAllUser()
        {
            var lst = new List<UserDetail>();
             return lst=_userDetails.GetAllUser();
        }

        public LoginVM_User IsLoggedIn(LoginVM_User objLoginUser) 
        {
            LoginVM_User loginVM_User = new LoginVM_User();
            var lstAllUsers= GetAllUser();
            var userDetails = lstAllUsers.Where(X => X.UserID.Equals(objLoginUser.User_ID) && X.Password.Equals(objLoginUser.Password)).FirstOrDefault();
            if (userDetails != null)
            {
                loginVM_User.isSuccesslOGIN = true;
                loginVM_User.isFirstLogin = (userDetails.LastLoginDate == null ? null : userDetails.LastLoginDate);
            }
            return loginVM_User;
        }
        public bool PersistUserDetails(UserDetail userDetail)
        {
            throw new NotImplementedException();
        }
    }
}
