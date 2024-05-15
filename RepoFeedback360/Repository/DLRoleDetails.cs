using RepoFeedback360.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Repository
{
    public class DLRoleDetails
    {
        public List<UserRoleDetails> getAllRoles()
        {
            List<UserRoleDetails> lstRoles;
            using (UserDetailContext _dbcontextUser = new UserDetailContext())
            {
                lstRoles = _dbcontextUser._dbRoleDetails.ToList();
            }
            return lstRoles;
        }
    }
}
