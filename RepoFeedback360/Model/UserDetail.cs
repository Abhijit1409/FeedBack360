using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using RepoFeedback360.CustomValidator;

namespace RepoFeedback360.Model
{
    [Table("UserDetails")]
    [Index(nameof(EmployeeId), IsUnique = true)]
    [Index(nameof(UserID),IsUnique =true)]
    public class UserDetail
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Unique]
        public string UserID { get; set; }
        public string? Password { get; set; }

        [Required(ErrorMessage ="Please Provide EmployeeId . This Field can't be null")]
        public string? EmployeeId  { get; set; }

        public string? EmployeeName { get; set; }

        [Required(ErrorMessage = "Please Provide EmailId . This Field can't be null")]
        [EmailAddress]
        public string? EmailID { get; set; }

        public string? MobileNumber { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public int DesignationId { get; set; }

        public DateTime? LastLoginDate { get; set; }


    }
}
