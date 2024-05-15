using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Model
{
    [Table("UserDesignationDetails")]
    public class UserDesignationDetails
    {
        [Key]
        public int DesignationId { get; set; }
        public string Designation_Name { get; set; }
    }
}
