using getbiz_work_project_management.Models;
using System;

namespace getbiz_work_project_management.Repository.Userapp_Project_Id_Tasks
{
    public interface IUserappProjectIdTasksRepository
    {

        Response AddUserappProjectIdTasks(userapp_project_id_tasks obj_userapp_project_id_tasks);
        Response UpdateUserappProjectIdTasks(userapp_project_id_tasks obj_userapp_project_id_tasks);
        Response DeleteUserappProjectIdTasks(Int64 Project_Id, Int64 Task_Id);
        Response GetUserappProjectIdTasks(Int64 Project_Id, Int64 Task_Id);

    }
}
