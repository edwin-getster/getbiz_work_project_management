using getbiz_work_project_management.Models;
using System;

namespace getbiz_work_project_management.Repository.Userapp_Project_Id_Task_Id_Sub_Tasks
{
    public interface IUserappProjectIdTaskIdSubTasksRepository
    {

        Response AddUserappProjectIdTaskIdSubTasks(userapp_project_id_task_id_sub_tasks obj_userapp_project_id_task_id_sub_tasks);
        Response UpdateUserappProjectIdTaskIdSubTasks(userapp_project_id_task_id_sub_tasks obj_userapp_project_id_task_id_sub_tasks);
        Response DeleteUserappProjectIdTaskIdSubTasks(Int64 Project_Id, Int64 Task_Id, Int64 Sub_Task_Id);
        Response GetUserappProjectIdTaskIdSubTasks(Int64 Project_Id, Int64 Task_Id, Int64 Sub_Task_Id);
    }
}
