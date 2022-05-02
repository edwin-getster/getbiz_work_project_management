using getbiz_work_project_management.Models;
using System;

namespace getbiz_work_project_management.Repository.Userapp_Work_Project_Master1
{
    public interface IUserappWorkProjectMaster1Repository
    {



        Response AddUserappWorkProjectMaster1(userapp_work_project_master1 obj_userapp_work_project_master1);
        Response UpdateUserappWorkProjectMaster1(userapp_work_project_master1 obj_userapp_work_project_master1);
        Response GetAllUserappWorkProjectMaster1();
        ////Response GetCompletedProjects();
        Response DeleteUserappWorkProjectMaster1(string Id, string User_Name, Int64 User_Id, string Project_Name);
        Response GetALLRevisionInEndDates(string Id);
    }
}
