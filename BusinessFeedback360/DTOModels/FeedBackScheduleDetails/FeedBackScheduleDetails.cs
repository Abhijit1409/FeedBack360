using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFeedback360.DTOModels.FeedBackScheduleDetails
{
    public class FeedBackScheduleDetails
    {
        [Required(ErrorMessage ="Please Select Employee")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Please Select Feedback Catagory")]
        public int FeedbackCatagory { get; set; }

        [Required(ErrorMessage = "Please Select FeedbackProvider")]
        public string FeedBackProvider { get; set; }


        public DateTime Lastdate { get; set; }
        

    }
}
