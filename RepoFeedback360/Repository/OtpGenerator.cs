using Microsoft.EntityFrameworkCore;
using RepoFeedback360.Abstract;
using RepoFeedback360.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Repository
{
    public class OtpGenerator : IOtpDetails
    {
        public void Add_OtpDetails(DL_OTPModel otpDetails)
        {
            using (UserDetailContext context = new UserDetailContext())
            {
                var data = context._otpData.Where(o => o.User_ID_ForOTP == otpDetails.User_ID_ForOTP).FirstOrDefault();
                if (data != null)
                {
                    data.User_ID_ForOTP= otpDetails.User_ID_ForOTP;
                    data.OTP = otpDetails.OTP;
                    data.OTP_SEND_TIMESTAMP = otpDetails.OTP_SEND_TIMESTAMP;
                    //context.Entry(data).State = EntityState.Detached;
                    context._otpData.Update(data);
                    context.SaveChanges();
                }
                else
                {
                    
                    context._otpData.Add(otpDetails);
                    context.SaveChanges();
                }
                
            
            }
        }

        public List<DL_OTPModel> Get_OtpDetails()
        {
            List<DL_OTPModel> allOtps = null;
            using (UserDetailContext context = new UserDetailContext())
            {
                allOtps = context._otpData.ToList();
            }
            return allOtps;
        }
    }
}
