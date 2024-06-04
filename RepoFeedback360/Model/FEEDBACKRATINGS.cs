using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Model
{
    [Table("TBL_FEEDBACKRATINGS")]
    public class FEEDBACKRATINGS
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int FeedbackRatings_ID { get; set; }
        [Column("To_ID")]
        [Required]
        public string TOID_EmplyeeId { get; set; }
        [Column("BY_ID")]
        [Required]
        public string BYID_EmplyeeId { get; set; }

        public int Q_ID { get; set; }
        public int Ratings { get; set; }

        public DateTime CreatedDate { get; set; }



    }
}
