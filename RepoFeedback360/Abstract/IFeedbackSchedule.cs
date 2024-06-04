using RepoFeedback360.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Abstract
{
    public interface IFeedbackSchedule
    {
        List<FeedBackSchedulerML> GetAllScheduledFeedBacks();
        List<FeedBackQuestions> GetAllQuestionsForFeedBacks();

    }
}
