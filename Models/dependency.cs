using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Models
{
    public class dependency
    {
        public string id { set; get; }
        public string  predecessorId { set; get; }
        public string  successorId { set; get; }

        public string  project_name { set; get; }
        public string entry_by_user_id { set; get; }
        public string entry_by_user_name { set; get; }

        public int  type { set; get; }
    }
}
