using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoFeedback360.Model;

namespace RepoFeedback360.Abstract
{
    public interface IUserDetails
    {
        List<UserDetail> GetAllUser();
        
        bool PersistUserDetails(UserDetail userDetail);
    }
}
