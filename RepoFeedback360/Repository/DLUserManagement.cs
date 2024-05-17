using RepoFeedback360.Abstract;
using RepoFeedback360.Model;
using UtilityFeedback360;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace RepoFeedback360.Repository
{
    public class DLUserManagement : IUserDetails
    {
        public List<UserDetail> GetAllUser()
        {
            List<UserDetail> lstUserDetails;
            using (UserDetailContext _dbcontext = new UserDetailContext())
            {
               return lstUserDetails = _dbcontext._dbUserDetails.ToList();
            }
            
        }

        public bool PersistUserDetails(UserDetail userDetail)
        {
            bool status = false;
            try
            {
                using (UserDetailContext _dbUserContext = new UserDetailContext())
                {
                    _dbUserContext._dbUserDetails.Add(userDetail);
                    int bitReturn = _dbUserContext.SaveChanges();
                    status = bitReturn == 1 ?  true :  false;
                }
                if (status)
                {
                    string subject_Line = "Employeement Information With XYZ TeCH.";
                    StringBuilder emailBodygenerator = new StringBuilder(string.Format("Hi {0} ,<Br>",userDetail.EmployeeName));
                    emailBodygenerator.Append("We are pleased to inform you that your employeeId has been successfully generated.\n <br>");
                    emailBodygenerator.Append("Please collect your EmployeeId , UserId , Password Followed by ");
                    emailBodygenerator.Append(string.Format("<b>{0}</b>, <b>{1}</b>, <b>{2}</b>",userDetail?.EmployeeId?.ToString(),userDetail?.UserID.ToString(),userDetail?.Password));
                    emailBodygenerator.Append("\n\n<br><br><br> Thank You & Regards <br> \n Team HR.");

                    SendMails.SendEmail(userDetail?.EmailID, subject_Line, emailBodygenerator.ToString());
                }
            }
            catch(Exception ex) 
            {
               
            }
            return status;
        }

        public bool UpdateLastLogIn_Timestamp(UpdateLogInTimestamp objUpdateLoginTimestamp)
        {
            bool updateStatus= false;
            int bitReturn=0;
            try
            {
                if (objUpdateLoginTimestamp != null)
                {
                    using (UserDetailContext _dbUserContext = new UserDetailContext())
                    {
                        var db_userDetails = _dbUserContext._dbUserDetails.Where(x => x.UserID == objUpdateLoginTimestamp.User_ID && x.EmployeeName == objUpdateLoginTimestamp.Employee_Name).FirstOrDefault();
                        db_userDetails.LastLoginDate = DateTime.Now;
                        //Updating record here
                        _dbUserContext._dbUserDetails.Update(db_userDetails);
                       bitReturn = _dbUserContext.SaveChanges();
                       if(bitReturn == 1)  updateStatus = true;
                    }


                }
            } catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            return updateStatus;
        }
    }
}
