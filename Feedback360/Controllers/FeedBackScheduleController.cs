using Microsoft.AspNetCore.Mvc;
using BusinessFeedback360.DTOModels.FeedBackScheduleDetails;
using BusinessFeedback360;
using BusinessFeedback360.DTOModels.FeedBackScheduleDetails;
using System.Linq;
using RepoFeedback360.Model;
using BusinessFeedback360.DTOModels;

namespace Feedback360.Controllers
{
    public class FeedBackScheduleController : Controller
    {
        private FeedBackScheduleBL feedBackScheduleBL = null;

        [HttpGet]
        public IActionResult FeedBackSchedule()
        {
            feedBackScheduleBL= new FeedBackScheduleBL();
            ViewBag.FeedBackCatagories= feedBackScheduleBL.GetFeedbackCatagories();
            ViewBag.GetALLUser=feedBackScheduleBL.Users();
            return View();
        }
        [HttpPost]
        public IActionResult FeedBackSchedule(FeedBackScheduleDetails objScheduleDetails)
        {
            feedBackScheduleBL = new FeedBackScheduleBL();
            ViewBag.FeedBackCatagories = feedBackScheduleBL.GetFeedbackCatagories();
            ViewBag.GetALLUser = feedBackScheduleBL.Users();
            var result=feedBackScheduleBL.SetFeedbackSchedulersBL(objScheduleDetails);
            if (result) ViewData["Success"] = "FeedBackSchedule Successfully done .";
            else ViewData["Failed"] = "Some Error occures while Scheduling.";
            return View(objScheduleDetails);
        }
        [HttpGet]
        public IActionResult Candidate_List()
        {
            List<ScheduledCandidatesDL> lstCandidates = null;
            feedBackScheduleBL = new FeedBackScheduleBL();
            lstCandidates = feedBackScheduleBL.Candidate_List();
         return View(lstCandidates);
        }

        public IActionResult ProvideFeedBack(InputData objdata)
        {
            //get all record by the departmentId
            //bind it for question page
            //Add a view 
            return View();
        }
    }
}
