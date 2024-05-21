using RepoFeedback360.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Abstract
{
    public interface IOtpDetails
    {
        void Add_OtpDetails(DL_OTPModel otpDetails);
        List<DL_OTPModel> Get_OtpDetails();
    }
}
