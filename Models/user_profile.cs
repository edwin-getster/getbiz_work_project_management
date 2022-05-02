using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Models
{
    public class user_profile
    {
        [Key]

        public int id { set; get; }
      
        public string task_id { set; get; }
        public string photo_id { set; get; }
    }
}
