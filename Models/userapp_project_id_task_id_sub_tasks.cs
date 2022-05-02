using System;

namespace getbiz_work_project_management.Models
{
    public class userapp_project_id_task_id_sub_tasks
    {

        public int sub_task_id { get; set; }
        public string sub_task_title { get; set; }
        public string sub_task_description { get; set; }



        public string sub_start_utc_timestamp { get; set; }
        public string sub_end_utc_timestamp { get; set; }

        public string sub_task_attachments { get; set; }
        public int sub_task_status { get; set; }

        public string sub_task_completion_utc_timestamp { get; set; }
        public string sub_task_reason_for_suspension { get; set; }


        public string user_ids_requesting_app_notification_on_changes_made { get; set; }
        public string user_ids_requesting_app_notification_on_completion { get; set; }
        public string user_ids_requesting_app_notification_on_delay { get; set; }
        public string user_ids_requesting_app_notification_on_suspension { get; set; }
        public Int64 project_id { get; set; }
        public Int64 task_id { get; set; }
        public Int64 user_id { get; set; }

    }
}

