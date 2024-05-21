using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepoFeedback360.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Model
{
    [Table("tbl_OTP_Details")]
    public class DL_OTPModel
    {
        [Column("User_Id_OTP")]
        [Required]
        [Key]
        public string User_ID_ForOTP { get; set; }
        [Required]
        public int OTP { get; set; }
        public DateTime OTP_SEND_TIMESTAMP { get; set; }
    }
}
