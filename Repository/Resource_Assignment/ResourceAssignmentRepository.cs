using getbiz_work_project_management.Getbiz_DbContext;
using getbiz_work_project_management.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace getbiz_work_project_management.Repository.Resource_Assignment
{
    public class ResourceAssignmentRepository : IResourceAssignmentReposiotry
    {

        public readonly WorkProjectManagementAppDB_DbContext _DbContext;
        public ResourceAssignmentRepository(WorkProjectManagementAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public Response AddResourceAssignment(resource_assignment obj_resource_assignment)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.AddResourceAssignment(obj_resource_assignment);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public Response GetTasksByResourceId(string Resource_Id)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetTasksByResourceId(Resource_Id);

                //List<resource_assignment> resource_assignment_details = new List<resource_assignment>();
                //resource_assignment_details = ConvertDataTable<resource_assignment>(dset);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dset);
                response.Data = JSONresult;

               // response.Data = (resource_assignment_details).ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }
        public Response GetResourceAssignmentWithOutId( )
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetResourceAssignmentWithOutId();

                //List<resource_assignment> resource_assignment_details = new List<resource_assignment>();
                //resource_assignment_details = ConvertDataTable<resource_assignment>(dset);
                // response.Data = (resource_assignment_details).ToList();


                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dset);
                response.Data = JSONresult;

                response.Message = "Data Fetch successfully !!";
                response.Status = true;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        public Response UpdateResourceAssignment(resource_assignment obj_resource_assignment)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.UpdateResourceAssignment(obj_resource_assignment);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;

        }
        public Response DeleteResourceAssignmentById(string Resource_Id, string Task_Id, string Projct_Name, string User_Name)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.DeleteResourceAssignmentById( Resource_Id,  Task_Id,  Projct_Name,  User_Name);
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
