using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Model
{
    [Table("tbl_FeedbackCatagory")]
    //[Index(typeof())]
    public class FeedBackCatagoryML
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Catagory_ID { get; set; }

        [Column("CatagryDescription")]
        [Required]
        public string Catagory_Description { get; set;}
        public DateTime CreatedDate { get; set; }
    }
}
