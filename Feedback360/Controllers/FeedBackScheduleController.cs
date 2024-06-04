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

        [HttpGet]
        public IActionResult ProvideFeedBack(InputData objdata)
        {
            
            TempData["EmployeeId_To"] = objdata.EmployeeId_To;
            TempData["EmployeeId_By"] = objdata.EmployeeId_By;
            TempData["DesignationId"] = objdata.DesignationId;
            feedBackScheduleBL = new FeedBackScheduleBL();
             ViewBag.AllQuestions= feedBackScheduleBL.GetAllQuestions(objdata);
             
            return View(new FEEDBACKRATINGS());
        }
        [HttpPost]
        public IActionResult ProvideFeedBack(FEEDBACKRATINGS objFeedBAckRatings,string Q_ID_1, int Rating_1,
            string Q_ID_2, int Rating_2, string Q_ID_3, int Rating_3, string Q_ID_4, int Rating_4, string Q_ID_5,int Rating_5)
        {
            List<FEEDBACKRATINGS> lstFeedbackRatings = new List<FEEDBACKRATINGS>()
            {
              new FEEDBACKRATINGS() { TOID_EmplyeeId= TempData.ContainsKey("EmployeeId_To")?TempData["EmployeeId_To"].ToString():null, BYID_EmplyeeId = TempData.ContainsKey("EmployeeId_By")?TempData["EmployeeId_By"].ToString():null,
                CreatedDate = DateTime.Now, Q_ID= Convert.ToInt16(Q_ID_1),Ratings=Rating_1
              },
              new FEEDBACKRATINGS() { TOID_EmplyeeId= TempData.ContainsKey("EmployeeId_To")?TempData["EmployeeId_To"].ToString():null, BYID_EmplyeeId = TempData.ContainsKey("EmployeeId_By")?TempData["EmployeeId_By"].ToString():null,
                CreatedDate = DateTime.Now, Q_ID= Convert.ToInt16(Q_ID_2),Ratings=Rating_2
              },
              new FEEDBACKRATINGS() { TOID_EmplyeeId= TempData.ContainsKey("EmployeeId_To")?TempData["EmployeeId_To"].ToString():null, BYID_EmplyeeId = TempData.ContainsKey("EmployeeId_By")?TempData["EmployeeId_By"].ToString():null,
                CreatedDate = DateTime.Now, Q_ID= Convert.ToInt16(Q_ID_3),Ratings=Rating_3
              },
              new FEEDBACKRATINGS() { TOID_EmplyeeId= TempData.ContainsKey("EmployeeId_To")?TempData["EmployeeId_To"].ToString():null, BYID_EmplyeeId = TempData.ContainsKey("EmployeeId_By")?TempData["EmployeeId_By"].ToString():null,
                CreatedDate = DateTime.Now, Q_ID= Convert.ToInt16(Q_ID_4),Ratings=Rating_4
              },
              new FEEDBACKRATINGS() { TOID_EmplyeeId= TempData.ContainsKey("EmployeeId_To")?TempData["EmployeeId_To"].ToString():null, BYID_EmplyeeId = TempData.ContainsKey("EmployeeId_By")?TempData["EmployeeId_By"].ToString():null,
                CreatedDate = DateTime.Now, Q_ID= Convert.ToInt16(Q_ID_5),Ratings=Rating_5
              },
            };
            feedBackScheduleBL = new FeedBackScheduleBL();
            bool status = feedBackScheduleBL.SaveFeedBAck(lstFeedbackRatings);
            if (status) return RedirectToAction("Candidate_List");
            else
            {
                ViewData["Error"] = "Save Failed";
                return View(new FEEDBACKRATINGS());
            }


        }
    }
}
