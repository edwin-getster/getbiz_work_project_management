using getbiz_work_project_management.Getbiz_DbContext;
using getbiz_work_project_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Repository.Dependency
{
    public class DependencyRepository : IDependencyRepository
    {

        public readonly WorkProjectManagementAppDB_DbContext _DbContext;

        public DependencyRepository(WorkProjectManagementAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }



        public Response AddDependency(dependency obj_dependency)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.AddDependency(obj_dependency);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        

        public Response UpdateDependency(dependency obj_dependency)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.UpdateDependency(obj_dependency);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;

        }

        public Response GetDependency()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.dependency
                                 select new
                                 {
                                     id = master.id,
                                     predecessorId = master.predecessorId,
                                     successorId = master.successorId,
                                     type = master.type,

                                 }).ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }

            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }


        public Response DeleteDependency(string Id, string Project_Name, string Entry_By_User_Id, string Entry_By_User_Name)
        {

            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.DeleteDependency( Id,  Project_Name,  Entry_By_User_Id,  Entry_By_User_Name);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;

        }







    }
}
