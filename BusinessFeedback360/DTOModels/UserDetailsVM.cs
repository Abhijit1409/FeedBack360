using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFeedback360.DTOModels
{
    public class UserDetailsVM
    {
        //public int ID { get; set; }
        public string UserID { get; set; }
        public string? Password { get; set; }

        public string? EmployeeId { get; set; }

        public string? EmployeeName { get; set; }

        [Required(ErrorMessage ="EmailId field can't be Empty")]
        public string? EmailID { get; set; }

        public string? MobileNumber { get; set; }

        public int RoleId { get; set; }

        public int DesignationId { get; set; }

       // public DateTime? LastLoginDate { get; set; }
    }
}
