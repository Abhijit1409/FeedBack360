using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Model
{
    public class ResetPasswordModel
    {
        public string? User_Id { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "Please Provide Your New Password")]
        public string NewPassword { get; set; }
    }
}
