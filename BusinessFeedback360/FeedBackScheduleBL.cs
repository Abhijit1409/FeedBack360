using BusinessFeedback360.DTOModels.FeedBackScheduleDetails;
using RepoFeedback360.Abstract;
using RepoFeedback360.Model;
using RepoFeedback360.Repository;
using RepoFeedback360.Repository.FeedBackScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessFeedback360
{
    public class FeedBackScheduleBL : IFeedbackScheduler
    {
        private FeedBackSchedulerDL _dlFeedBackScheduler = null;
        public FeedBackScheduleBL()
        {

        }

        public List<FeedBackCatagoryML> GetFeedbackCatagories()
        {
            List<FeedBackCatagoryML> lstFeedBackcatagories = null;
            using (_dlFeedBackScheduler = new FeedBackSchedulerDL())
            {
                lstFeedBackcatagories = _dlFeedBackScheduler.GetFeedbackCatagories();
            }

            return lstFeedBackcatagories;
        }

        public bool SetFeedbackSchedulersBL(FeedBackScheduleDetails objFeedBackScheduler)
        {
            FeedBackSchedulerML feedbackScheduler = null;
            if (objFeedBackScheduler != null)
            {
                feedbackScheduler = new FeedBackSchedulerML()
                {
                    IsActive = true,
                    To_EmployeeId=objFeedBackScheduler.EmployeeId,
                    By_EmployeeId=objFeedBackScheduler.FeedBackProvider,
                    LastDate=objFeedBackScheduler.Lastdate,
                    FeebBack_CatagoryID=objFeedBackScheduler.FeedbackCatagory
                };
            }

            return SetFeedbackSchedulers(feedbackScheduler);
        }

        public bool SetFeedbackSchedulers(FeedBackSchedulerML objFeedBackScheduler)
        {
            bool result = false;
            using (_dlFeedBackScheduler = new FeedBackSchedulerDL())
            {
                result= _dlFeedBackScheduler.SetFeedbackSchedulers(objFeedBackScheduler);
            }
            return result;
        }
        public List<UserDetail> Users()
        { 
         DLUserManagement objDLM = new DLUserManagement();
         List<UserDetail> lst = null;
         lst = objDLM.GetAllUser();
         return lst;
         
        }
    }
}


