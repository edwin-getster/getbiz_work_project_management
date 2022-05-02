using getbiz_work_project_management.Models;
using getbiz_work_project_management.V_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Repository.Userapp_Work_Project_Master1_Check_List
{
    public interface IUserappWorkProjectMaster1CheckListRepository
    {
       Response AddUserappWorkProjectMaster1CheckList(userapp_work_project_master1_check_list obj_userapp_work_project_master1_check_list);
       Response ReArrangCheckList(rearang_check_list obj_rearang_check_list);
       Response UpdateUserappWorkProjectMaster1CheckList(userapp_work_project_master1_check_list obj_userapp_work_project_master1_check_list);
       Response GetALLUserappWorkProjectMaster1CheckList(string Id);
        Response DeleteUserappWorkProjectMaster1CheckList(
            string check_list_s_no,
            string id,
            string project_name,
            int check_list_user_id,
            string check_list_user_name);
    }
}
