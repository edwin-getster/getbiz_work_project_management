using getbiz_work_project_management.Models;
using System;

namespace getbiz_work_project_management.Repository.Userapp_User_Permissions
{
    public interface IUserappUserPermissionsRepository
    {


        Response AddUserappUserPermissions(userapp_user_permissions obj_userapp_user_permissions);
        Response GetUserappUserPermissions(bool Is_Parent, string Parent_Id);
       // Response UpdateUserappUserPermissions(userapp_user_permissions obj_userapp_user_permissions);
    }
}
