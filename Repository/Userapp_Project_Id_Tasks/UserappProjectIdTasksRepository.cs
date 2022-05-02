using getbiz_work_project_management.Getbiz_DbContext;
using getbiz_work_project_management.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace getbiz_work_project_management.Repository.Userapp_Project_Id_Tasks
{
    public class UserappProjectIdTasksRepository : IUserappProjectIdTasksRepository
    {

        public readonly WorkProjectManagementAppDB_DbContext _DbContext;
        public UserappProjectIdTasksRepository(WorkProjectManagementAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }


        public Response AddUserappProjectIdTasks(userapp_project_id_tasks obj_userapp_project_id_tasks)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.AddUserappProjectIdTasks(obj_userapp_project_id_tasks);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



        public Response UpdateUserappProjectIdTasks(userapp_project_id_tasks obj_userapp_project_id_tasks)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.UpdateUserappProjectIdTasks(obj_userapp_project_id_tasks);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }




        public Response DeleteUserappProjectIdTasks(Int64 Project_Id, Int64 Task_Id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.DeleteUserappProjectIdTasks(Project_Id, Task_Id);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }




        public Response GetUserappProjectIdTasks(long Project_Id, long Task_Id)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetUserappProjectIdTasks(Project_Id, Task_Id);

                //userapp_project_id_tasks objuserapp_project_id_tasks = new userapp_project_id_tasks();

                List<userapp_project_id_tasks> userapp_project_id_tasks_details = new List<userapp_project_id_tasks>();
                userapp_project_id_tasks_details = ConvertDataTable<userapp_project_id_tasks>(dset);

                //string JSONresult;
                //JSONresult = JsonConvert.SerializeObject(dset);
                //response.Data = JSONresult;

                response.Data = (userapp_project_id_tasks_details).ToList();
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
    }
}
