using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFeedback360.DTOModels.Password
{
    public class ChangePasswordVM
    {
        public string User_Id { get; set; }
        [DisplayName("Old Password")]
        [Required(ErrorMessage ="Please Provide Your Old Password")]
        public string OldPassword { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "Please Provide Your New Password")]
        public string NewPassword { get; set; }

    }
}
