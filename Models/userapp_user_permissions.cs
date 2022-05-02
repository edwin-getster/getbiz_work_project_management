    using System;
using System.ComponentModel.DataAnnotations;

namespace getbiz_work_project_management.Models
{
    public class userapp_user_permissions
    {

        [Key]

        public int id { set; get; }

        public string project_id { set; get; }
        public int user_id { set; get; }
        public string parent_id { set; get; }
        public bool is_parent { set; get; }
        public bool can_edit_project { set; get; }
        public bool is_project_leader { set; get; }
        public string task_id { set; get; }
        public bool can_edit_task { set; get; }
        public bool is_task_leader { set; get; }
        public string sub_task_id { set; get; }
        public bool can_edit_sub_task { set; get; }
        public bool is_sub_task_leader { set; get; }
        public Int64 can_access_team_members_projects { set; get; }
      


    }
}
