namespace getbiz_work_project_management.Models
{
    public class userapp_project_id_tasks
    {
        public int task_id { get; set; }
        public string task_title { get; set; }
        public string task_description { get; set; }
        public string task_start_utc_timestamp { get; set; }
        public string task_end_utc_timestamp { get; set; }
        public string task_attachments { get; set; }
        public int task_status { get; set; }
        public string task_completion_utc_timestamp { get; set; }
        public string task_reason_for_suspension { get; set; }
        public string user_ids_requesting_app_notification_on_changes_made { get; set; }
        public string user_ids_requesting_app_notification_on_completion { get; set; }
        public string user_ids_requesting_app_notification_on_delay { get; set; }
        public string user_ids_requesting_app_notification_on_suspension { get; set; }
        public int project_id { get; set; }
        public int user_id { get; set; }

    }
}
