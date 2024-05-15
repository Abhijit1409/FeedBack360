using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Model
{
    [Table("UserRoleDetails")]
    public class UserRoleDetails
    {
        [Key]
        public int Role_Id { get; set; }
        public string Role_Name { get; set; }
    }
}
