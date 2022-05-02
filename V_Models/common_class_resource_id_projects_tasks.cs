using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.V_Models
{
    public class common_class_resource_id_projects_tasks
    {
         public int resourceId { get; set; } 
         public string taskId { get; set; } 
         public bool is_project_leader { get; set; }
         public string id { get; set; }
         public string title { get; set; }
         public string start { get; set; }
         public string end { get; set; }
         public string progress { get; set; }
         public string color { get; set; }
        
    }
}
