using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoFeedback360.Abstract;
using RepoFeedback360.Model;

namespace RepoFeedback360.Repository.FeedBackScheduler
{
    public class FeedBackSchedulerDL : IFeedbackScheduler, IDisposable
    {
        private UserDetailContext _userDetailContext = null;
        private bool disposedValue;

        public List<FeedBackCatagoryML> GetFeedbackCatagories()
        {
            List<FeedBackCatagoryML> lstFeedBackCatagories = null;
            try
            {
                using (_userDetailContext = new UserDetailContext())
                {
                    lstFeedBackCatagories = _userDetailContext._FeedBackCatagoryML.ToList();
                }
            }
            catch (Exception ex)
            {

            }

            return lstFeedBackCatagories;
        }

        public bool SetFeedbackSchedulers(FeedBackSchedulerML objFeedBackScheduler)
        {
            bool resultBit = false;
            try
            {
                using (_userDetailContext = new UserDetailContext())
                {
                    if (objFeedBackScheduler != null)
                    {
                        _userDetailContext._dtfeedBackScheduler.Add(objFeedBackScheduler);
                        int resultInt = _userDetailContext.SaveChanges();
                        resultBit = resultInt == 1 ? true : false;
                    }


                }
            }
            catch (Exception ex)
            {

            }
            return resultBit;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~FeedBackSchedulerDL()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public List<ScheduledCandidatesDL> GetScheduledCandidateList()
        {
            List<ScheduledCandidatesDL> lstScheduledCandidates = null;
            try
            {
                using (_userDetailContext = new UserDetailContext())
                {
                    var alluser = _userDetailContext._dbUserDetails.ToList();
                    var feedbackScheduleDetails = _userDetailContext._dtfeedBackScheduler.ToList();
                    var allDesignations = _userDetailContext._dbDesignationDetails.ToList();
                    var lstScheduledCandidate = (from userData in alluser
                                                 join scheduleddata in feedbackScheduleDetails on userData.EmployeeId equals scheduleddata.To_EmployeeId
                                                 join Designations in allDesignations on userData.DesignationId equals Designations.DesignationId
                                                 where scheduleddata.IsActive == true
                                                 select new
                                                 {
                                                     userData.UserID,
                                                     userData.EmployeeName,
                                                     userData.EmployeeId,
                                                     scheduleddata.By_EmployeeId,
                                                     Designations.DesignationId
                                                 }).ToList();

                    lstScheduledCandidates = new List<ScheduledCandidatesDL>();
                    foreach (var data in lstScheduledCandidate)
                    {
                        lstScheduledCandidates.Add(new ScheduledCandidatesDL
                        {
                            Candidate_UserName = data.UserID,
                            EmployeeId_By = data.By_EmployeeId.ToString(),
                            EmployeeId_To = data.EmployeeId.ToString(),
                            Employee_Name = data.EmployeeName,
                            Designation_Id = data.DesignationId,

                        });

                    }

                    return lstScheduledCandidates;
                }
            }
            catch (Exception ex)
            {

            }
            return lstScheduledCandidates;
        }

        public List<FeedBackQuestions> GetAllQuestions_ByDesignation(string inputData_Designation)
        {
            List<FeedBackQuestions> lstQuestions = null;
            using (_userDetailContext = new UserDetailContext())
            {
                lstQuestions = _userDetailContext._dbFeedbackQuestions.Where(x => x.DESIGNATION_ID == Convert.ToInt16(inputData_Designation)).Distinct().ToList();
            }
            return lstQuestions;
        }

        public bool PersistFeedback(List<FEEDBACKRATINGS> lstFeedbackRatings)
        {
            bool result = false;
            try
            {
                var empid = lstFeedbackRatings != null && lstFeedbackRatings.Any(x => x.TOID_EmplyeeId != null) ? lstFeedbackRatings?.Where(x => x.TOID_EmplyeeId != null).FirstOrDefault(): null ;
                string Empto_Id = empid?.TOID_EmplyeeId;
                using (_userDetailContext = new UserDetailContext())
                {
                    if (lstFeedbackRatings != null && lstFeedbackRatings.Count != 0)
                    {
                        foreach (FEEDBACKRATINGS lstFeedbackRating in lstFeedbackRatings)
                        {
                            _userDetailContext._dbFEEDBACKRATINGS.Add(lstFeedbackRating);
                        }
                        int bitResult = _userDetailContext.SaveChanges();
                        result = bitResult >= 1 ? true : false;
                    }
                    if (result)
                    {
                        var data = _userDetailContext._dtfeedBackScheduler.Where(x => x.To_EmployeeId.Equals(Empto_Id)).FirstOrDefault();
                        if (data != null) { data.IsActive = false; }
                        _userDetailContext._dtfeedBackScheduler.Update(data);
                        _userDetailContext.SaveChanges();
                    }
                }
            }
            catch (Exception Ex) { }
            return result;
        }
    }
}
