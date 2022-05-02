using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace getbiz_work_project_management.Models
{
    public class user_registeration
    {

        [Key]


        public int id { set; get; }
        public int user_id { set; get; }
        public string text { set; get; }
        public string password { set; get; }
        public string mobile_number { set; get; }
        public string photo_id { set; get; }

        [DefaultValue(true)]
        public bool user_type { set; get; } = true;
        public string authkey { set; get; }
    }
}
