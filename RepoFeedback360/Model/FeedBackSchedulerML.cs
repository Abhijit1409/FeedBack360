using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Model
{
    [Table("tbl_FeedBackScheduleDetails")]
    public class FeedBackSchedulerML
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedSchedulerID { get; set; }
        [Required]
        public string To_EmployeeId { get; set; }
        [Required]
        public string By_EmployeeId { get; set; }
        [Required]
        public int FeebBack_CatagoryID { get; set; }
        [Required]
        public DateTime LastDate { get; set; }
        public bool IsActive { get; set; }
    }
}
