using BusinessFeedback360.DTOModels;
using RepoFeedback360;
using RepoFeedback360.Model;
using RepoFeedback360.Repository;

namespace BusinessFeedback360
{
    public class BLUserManagement
    {
       private DLUserManagement _dlUserManagement;
       private DLDesignationDetails _designationDetails;
       private DLRoleDetails _roleDetails;
        public BLUserManagement()
        {
            this._dlUserManagement = new DLUserManagement();
            this._roleDetails = new DLRoleDetails();
            this._designationDetails = new DLDesignationDetails();
        }
        public List<RoleVMDTO> GetAllRoles()
        {
            List<RoleVMDTO> lstRoles = new List<RoleVMDTO>();
            var roles = _roleDetails.getAllRoles();
            if (roles != null)
            {
                foreach (var dtoRoleModel in roles)
                {
                    lstRoles.Add(new RoleVMDTO()
                    {
                        RoleId = dtoRoleModel.Role_Id,
                        RoleName = dtoRoleModel.Role_Name
                    });
                }

            }
            return lstRoles;
        }

        public List<DesignationVMDTO> GetAllDesignations()
        {
            List<DesignationVMDTO> lstDesignations = new List<DesignationVMDTO>();
            var designations = _designationDetails.getAllDesignation();
            if (designations != null)
            {
                foreach (var dtoDesignationModel in designations)
                {
                    lstDesignations.Add(new DesignationVMDTO()
                    {
                        DesignationId = dtoDesignationModel.DesignationId,
                        DesignationName = dtoDesignationModel.Designation_Name
                    });
                }

            }
            return lstDesignations;

        }

        public bool saveUserDetails(UserDetailsVM userdetails)
        {
            if (userdetails != null)
            { 
              UserDetail userDetail = new UserDetail() { 
                 UserID= userdetails.UserID,
                 Password= userdetails.Password,
                 EmployeeId= userdetails.EmployeeId,
                 EmployeeName= userdetails.EmployeeName,
                 EmailID= userdetails.EmailID,
                 MobileNumber= userdetails.MobileNumber,
                 DesignationId= userdetails.DesignationId,
                 RoleId= userdetails.RoleId,
              };
               return _dlUserManagement.PersistUserDetails(userDetail);
            }
            return false;
        }

    }
}
