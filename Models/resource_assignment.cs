using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace getbiz_work_project_management.Models
{
    public class resource_assignment
    {
        [Key]

        public string id { set; get; }
        public string resourceId { set; get; }
        public string taskId { set; get; }
        public string user_name { set; get; }
        public string project_name { set; get; }

        [DefaultValue(false)]
        public bool is_project_leader { set; get; } = false;
    }
}
