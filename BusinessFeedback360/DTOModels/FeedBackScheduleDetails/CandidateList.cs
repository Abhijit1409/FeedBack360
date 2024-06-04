using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFeedback360.DTOModels.FeedBackScheduleDetails
{
    public class CandidateList
    {
        [Column("Candidate User Id")]
        public string Candidate_UserName { get; set; }
        public string Employee_Name { get; set; }
        public string EmployeeId_To { get; set; }
        public string EmployeeId_By { get; set; }
        public int Designation_Id { get; set; }


    }
}
