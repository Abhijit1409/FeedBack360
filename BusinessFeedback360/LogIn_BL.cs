using BusinessFeedback360.DTOModels;
using BusinessFeedback360.DTOModels.Password;
using RepoFeedback360.Abstract;
using RepoFeedback360.Model;
using RepoFeedback360.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFeedback360
{
    public class LogIn_BL : IUserDetails
    {
        private IUserDetails _userDetails;
        public LogIn_BL()
        {
            this._userDetails = new DLUserManagement();
        }
        public List<UserDetail> GetAllUser()
        {
            var lst = new List<UserDetail>();
            return lst = _userDetails.GetAllUser();
        }

        public LoginVM_User IsLoggedIn(LoginVM_User objLoginUser)
        {
            //LoginVM_User loginVM_User = new LoginVM_User();
            var lstAllUsers = GetAllUser();
            var userDetails = lstAllUsers.Where(X => X.UserID.Equals(objLoginUser.User_ID) && X.Password.Equals(objLoginUser.Password)).FirstOrDefault();
            if (userDetails != null || userDetails?.UserID != null)
            {
                objLoginUser.isSuccesslOGIN = true;
                objLoginUser.isFirstLogin = (userDetails.LastLoginDate == null ? null : userDetails.LastLoginDate);

            }
            if (objLoginUser.isSuccesslOGIN)
            {
                UpdateLastLogIn_Timestamp(new UpdateLogInTimestamp() { User_ID = userDetails?.UserID, Employee_Name = userDetails?.EmployeeName });
            }
            return objLoginUser;
        }
        public bool PersistUserDetails(UserDetail userDetail)
        {
            throw new NotImplementedException();
        }

        public bool ResetPassword_Bl(ChangePasswordVM objChangePassword)
        {
            ResetPasswordModel resetPassword ;
            if (objChangePassword != null) { resetPassword = new ResetPasswordModel() { User_Id = objChangePassword.User_Id, NewPassword = objChangePassword.NewPassword }; }
            else resetPassword = new ResetPasswordModel();
            return ResetPassword(resetPassword);
        }

        public bool ResetPassword(ResetPasswordModel resetPasswordModel)
        {
           return _userDetails.ResetPassword(resetPasswordModel);
        }

        public bool UpdateLastLogIn_Timestamp(UpdateLogInTimestamp objUpdateLoginTimestamp)
        {
            return _userDetails.UpdateLastLogIn_Timestamp(objUpdateLoginTimestamp);
        }
    }
}
