using System.ComponentModel.DataAnnotations;

namespace getbiz_work_project_management.Models
{
    public class userapp_audit_trail
    {
        [Key]
        public int id { set; get; }
        public int project_id { set; get; }

        public string project_name { set; get; }
        public string entry_type { set; get; }
        public int entry_by_user_id { set; get; }
        public string user_name { set; get; }
        public string entry_local_timestamp { set; get; }
    }
}
