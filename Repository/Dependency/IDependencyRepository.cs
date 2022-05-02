using getbiz_work_project_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Repository.Dependency
{
    public interface IDependencyRepository
    {


        Response AddDependency(dependency obj_dependency);
        Response UpdateDependency(dependency obj_dependency);
        Response GetDependency();
        Response DeleteDependency(string Id, string Project_Name, string Entry_By_User_Id, string Entry_By_User_Name);

    }
}
