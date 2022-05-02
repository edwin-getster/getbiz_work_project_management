using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.V_Models
{
   
        public class rearang_check_list
        {
          public List<rearang_check_list_array> Data { set; get; }
      
        }
        public class rearang_check_list_array
        {
            public string check_list_s_no { set; get; }
            public string id { set; get; }
            public string check_list_desc { set; get; }
            public bool check_list_completed_verified { set; get; }
            public string check_list_user_name { set; get; }
            public string check_list_user_id { set; get; }
            public string check_list_timestamp { set; get; }
        }

}
