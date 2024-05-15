using RepoFeedback360.Abstract;
using RepoFeedback360.Model;
using UtilityFeedback360;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
