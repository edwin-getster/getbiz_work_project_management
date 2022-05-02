using getbiz_work_project_management.Getbiz_DbContext;
using getbiz_work_project_management.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace getbiz_work_project_management.Repository.Userapp_Work_Project_Master1
{
    public class UserappWorkProjectMaster1Repository : IUserappWorkProjectMaster1Repository
    {
        public readonly WorkProjectManagementAppDB_DbContext _DbContext;
        public UserappWorkProjectMaster1Repository(WorkProjectManagementAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }



        public Response AddUserappWorkProjectMaster1(userapp_work_project_master1 obj_userapp_work_project_master1)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.AddUserappWorkProjectMaster1(obj_userapp_work_project_master1);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



        public Response UpdateUserappWorkProjectMaster1(userapp_work_project_master1 obj_userapp_work_project_master1)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.UpdateUserappWorkProjectMaster1(obj_userapp_work_project_master1);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response GetAllUserappWorkProjectMaster1( )
        {

            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetAllUserappWorkProjectMaster1();

                //List<userapp_work_project_master1> userapp_work_project_master1_details = new List<userapp_work_project_master1>();
                //userapp_work_project_master1_details = ConvertDataTable<userapp_work_project_master1>(dset);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dset);
                response.Data = JSONresult;
                //response.Data = (userapp_work_project_master1_details).ToList();
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


        public Response GetALLRevisionInEndDates(string Id)
        {

            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetALLRevisionInEndDates(Id);
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

        public Response DeleteUserappWorkProjectMaster1(string Id, string User_Name, Int64 User_Id ,string Project_Name)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.DeleteUserappWorkProjectMaster1( Id,  User_Name,  User_Id, Project_Name);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response GetCompletedProjects()
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.GetCompletedProjects();
               // response = result;
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
