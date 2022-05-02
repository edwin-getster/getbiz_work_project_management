using getbiz_work_project_management.Models;

namespace getbiz_work_project_management.Repository.User_Registeration
{
    public interface IUserRegisterationRepository
    {


        Response AddUserRegisteration(user_registeration obj_user_registeration);
        Response GetUserRegisteration();
    }
}
