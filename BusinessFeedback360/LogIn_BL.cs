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
using UtilityFeedback360;
using RepoFeedback360;

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

        public int sendOtp(string UserId)
        {
            OtpGenerator otpGenerator ;
            int otp = 0;
            var users = _userDetails.GetAllUser().ToList();
            var user = users.Where(x => x.UserID == UserId).FirstOrDefault();
            try
            {
                if (user != null)
                {
                    Random random = new Random();
                    otp = random.Next(100000, 999999);
                    string subject_Line = "System generated Mail For Otp";
                    StringBuilder emailBodygenerator = new StringBuilder(string.Format("Hi {0} ,<Br>", user.EmployeeName));
                    emailBodygenerator.Append(string.Format("This is the Otp from your Resistered UserId {0},Followed by the OTP <b>{1}</b>", user.UserID, otp));
                    otpGenerator = new OtpGenerator();
                    otpGenerator.Add_OtpDetails(
                         new DL_OTPModel()
                         {
                             OTP = otp,
                             User_ID_ForOTP = UserId,
                             OTP_SEND_TIMESTAMP = DateTime.Now
                         }
                        ) ;
                     SendMails.SendEmail(user.EmailID, subject_Line, emailBodygenerator.ToString());
                }
            } catch (Exception EX) { throw new Exception(EX.Message); } 
            return otp;
        }

        public bool checkOtp(ForgotPasswordVMDTO forgotPasswordVMDTO) 
        {
            bool checkStatus=false;
            OtpGenerator otpGenerator = new OtpGenerator();
            var otpdetails = otpGenerator.Get_OtpDetails();
            var otpByUserId = otpdetails.Where(x=>x.User_ID_ForOTP == forgotPasswordVMDTO.UserId && x.OTP_SEND_TIMESTAMP.Date == DateTime.Today).FirstOrDefault();
            if (DateTime.Now.Minute - otpByUserId?.OTP_SEND_TIMESTAMP.Minute <= 6)
            {
                if (forgotPasswordVMDTO.OTP == otpByUserId?.OTP)
                {
                    checkStatus = true;
                }
            }



            return checkStatus;
        }
    }
}
