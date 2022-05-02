using System;
using System.ComponentModel.DataAnnotations;

namespace getbiz_work_project_management.Models
{
    public class userapp_work_project_master
    {

        [Key]
        public int project_id { get; set; }
        public string project_title { get; set; }
        public string project_description { get; set; }
        public string project_start_utc_timestamp { get; set; }
        public string project_end_utc_timestamp { get; set; }
        public string project_attachments { get; set; }
        public int project_status { get; set; }
        public string project_completion_utc_timestamp { get; set; }
        public string project_reason_for_suspension { get; set; }
        public string user_ids_requesting_app_notification_on_changes_made { get; set; }
        public string user_ids_requesting_app_notification_on_completion { get; set; }
        public string user_ids_requesting_app_notification_on_delay { get; set; }
        public string user_ids_requesting_app_notification_on_suspension { get; set; }
        public string user_ids_requesting_app_notification_on_hiding_deletion { get; set; }
        public UInt64 user_id { get; set; }
    }

}
