using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Model
{
    public class FeedBackQuestions
    {
        [Column("Q_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Question_Id { get; set; }
        [Required]
        public string Question_LongName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int DESIGNATION_ID { get; set; }
        
    }
}
