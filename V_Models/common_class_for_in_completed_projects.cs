﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.V_Models
{
    public class common_class_for_in_completed_projects
    {

        public string id { set; get; }
        public string parentId { set; get; }
        public string title { set; get; }
        public string start { set; get; }
        public string end { set; get; }
        public string progress { set; get; }
        public string color { set; get; }
    }
}
