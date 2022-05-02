using getbiz_work_project_management.Models;
using System;

namespace getbiz_work_project_management.Repository.Userapp_Work_Project_Master
{
    public interface IUserappWorkProjectMasterRepository
    {

        Response AddUserappWorkProjectMaster(userapp_work_project_master obj_userapp_work_project_master);
        Response UpdateUserappWorkProjectMaster(userapp_work_project_master obj_userapp_work_project_master);
        Response DeleteUserappWorkProjectMaster(Int64 Project_Id);
        Response GetUserappWorkProjectMaster(Int64 Project_Id);
    }
}
