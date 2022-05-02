using getbiz_work_project_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Repository.User_Profile
{
    public interface IUserProfileRepository
    {

        Response AddUserProfile(user_profile obj_user_profile);
        Response GetUserProfile(string Task_Id);
        Response DeleteUserProfile(string Task_Id);
  
    }
}
