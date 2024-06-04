using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Model
{
    public class ScheduledCandidatesDL
    {
        public string Candidate_UserName { get; set; }
        public string Employee_Name { get; set; }
        public string EmployeeId_To { get; set; }
        public string EmployeeId_By { get; set; }
        public int Designation_Id { get; set; }
    }
}
