using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Models
{
    public class userapp_work_project_master1_check_list
    {

        public string check_list_s_no { set; get; }
        public string id { set; get; }
    
        public string check_list_desc { set; get; }
        public bool check_list_completed_verified { set; get; }
        public string project_name { set; get; }
        public int   check_list_user_id { set; get; }
        public string check_list_user_name { set; get; }
        public string check_list_timestamp { set; get; }
    }
}
