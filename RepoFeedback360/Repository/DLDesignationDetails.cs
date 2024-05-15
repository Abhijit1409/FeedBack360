using RepoFeedback360.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Repository
{
    public class DLDesignationDetails
    {
        public List<UserDesignationDetails> getAllDesignation()
        {
            List<UserDesignationDetails> lstDesignation;
            using (UserDetailContext _dbcontextUser = new UserDetailContext())
            {
                lstDesignation = _dbcontextUser._dbDesignationDetails.ToList();
            }
            return lstDesignation;
        }
    }
}
