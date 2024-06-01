using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoFeedback360.Abstract;
using RepoFeedback360.Model;

namespace RepoFeedback360.Repository.FeedBackScheduler
{
    public class FeedBackSchedulerDL : IFeedbackScheduler,IDisposable
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
            catch(Exception ex) 
            { 
            
            }

            return lstFeedBackCatagories;
        }

        public bool SetFeedbackSchedulers(FeedBackSchedulerML objFeedBackScheduler)
        {
            bool resultBit= false;
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
            catch(Exception ex) 
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
    }
}
