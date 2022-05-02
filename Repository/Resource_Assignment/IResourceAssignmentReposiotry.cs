using getbiz_work_project_management.Models;

namespace getbiz_work_project_management.Repository.Resource_Assignment
{
    public interface IResourceAssignmentReposiotry
    {


        Response AddResourceAssignment(resource_assignment obj_resource_assignment);
        Response UpdateResourceAssignment(resource_assignment obj_resource_assignment);
        Response GetTasksByResourceId(string Resource_Id);
        Response GetResourceAssignmentWithOutId();
        Response DeleteResourceAssignmentById(string Resource_Id, string Task_Id, string Projct_Name, string User_Name);
    }
}
