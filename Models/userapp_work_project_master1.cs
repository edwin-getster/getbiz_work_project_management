using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace getbiz_work_project_management.Models
{
    public class userapp_work_project_master1
    {

        [Key]

        [MaxLength(50)]
        public string id { set; get; }
        [MaxLength(50)]
        public string parentId { set; get; }
        [MaxLength(200)]
        public string title { set; get; }
        [MaxLength(50)]
        public string start { set; get; }
        [MaxLength(50)]
        public string end { set; get; }
        public string progress { set; get; }
        [MaxLength(50)]
        public string color { set; get; }
        public int user_id { set; get; }
        public string user_name { set; get; }
        public string entry_local_timestamp { set; get; }

        



    }
}
