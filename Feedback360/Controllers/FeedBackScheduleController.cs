using Microsoft.AspNetCore.Mvc;
using BusinessFeedback360.DTOModels.FeedBackScheduleDetails;
using BusinessFeedback360;

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
    }
}
