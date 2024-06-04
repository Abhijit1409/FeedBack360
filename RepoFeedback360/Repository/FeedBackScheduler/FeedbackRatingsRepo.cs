using RepoFeedback360.Abstract;
using RepoFeedback360.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Repository.FeedBackScheduler
{
    public class FeedbackRatingsRepo : IFeedbackSchedule
    {
        public List<FeedBackQuestions> GetAllQuestionsForFeedBacks()
        {
            throw new NotImplementedException();
        }

        public List<FeedBackSchedulerML> GetAllScheduledFeedBacks()
        {
            List<FeedBackSchedulerML> lstEmployeeScheduled = null;
            try
            {
                using(UserDetailContext _dbcontext = new UserDetailContext())
                {
                    lstEmployeeScheduled = new List<FeedBackSchedulerML>();
                    lstEmployeeScheduled =_dbcontext._dtfeedBackScheduler.ToList();
                    return lstEmployeeScheduled;
                }
            }
            catch
            { 
              
            }
            return lstEmployeeScheduled;
        }
    }
}
