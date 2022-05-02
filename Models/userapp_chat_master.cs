using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Models
{
    public class userapp_chat_master
    {
     
        public string id { get; set; }
        public string group_chat_name { get; set; }
        public int chat_type { get; set; }
        public int created_by_user_id { get; set; }
        public string created_timestamp { get; set; }
        public int auto_delete_old_messages_no_of_days { get; set; }
        public bool auto_delete_old_messages { get; set; }
        public string about_the_chat { get; set; }
        public string businesses_associated_with_this_group { get; set; }
        public string pin_chat_to_the_top_of_chat_list { get; set; }
        public string pin_message_timestamp { get; set; }
        public string user_profile { get; set; }
        public string cust_id { get; set; }
        public string UserList_Ids { get; set; }
        public string Message { get; set; }

    }
}
