using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessFeedback360.DTOModels.Password
{
    public class ForgotPasswordVMDTO 
    {
        
        public string UserId { get; set; }
        
        public string NewPassword { get; set; }
       
        public int OTP { get; set; }
    }
}
