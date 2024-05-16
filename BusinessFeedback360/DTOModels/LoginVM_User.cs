using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFeedback360.DTOModels
{
    public  class LoginVM_User
    {
        [Required(ErrorMessage ="Please Provide User Id .This Field can't be blank.")]
        public string? User_ID { get; set; }
        [Required(ErrorMessage = "Please Provide Password .This Field can't be blank.")]
        public string? Password  { get; set; }
        public DateTime? isFirstLogin { get; set; }

        public bool isSuccesslOGIN { get; set; }
    }
}
