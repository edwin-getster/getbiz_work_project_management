using getbiz_work_project_management.Models;

namespace getbiz_work_project_management.Repository.Userapp_Work_Project_Master1_Notification
{
    public interface IUserappWorkProjectMaster1NotificationRepository
    {
        Response UpdateUserappWorkProjectMaster1Notification(string Id, bool NotificationMuteUnmute, int UserId);
        Response GetALLUserAppWorkProjectMaster1Notification(string Id, int UserId);
    }
}