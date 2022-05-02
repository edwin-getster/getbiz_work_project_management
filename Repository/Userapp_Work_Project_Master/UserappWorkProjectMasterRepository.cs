using getbiz_work_project_management.Getbiz_DbContext;
using getbiz_work_project_management.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace getbiz_work_project_management.Repository.Userapp_Work_Project_Master
{
    public class UserappWorkProjectMasterRepository : IUserappWorkProjectMasterRepository
    {
        public readonly WorkProjectManagementAppDB_DbContext _DbContext;
        public UserappWorkProjectMasterRepository(WorkProjectManagementAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserappWorkProjectMaster(userapp_work_project_master obj_userapp_work_project_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.AddUserappWorkProjectMaster(obj_userapp_work_project_master);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response UpdateUserappWorkProjectMaster(userapp_work_project_master obj_userapp_work_project_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.UpdateUserappWorkProjectMaster(obj_userapp_work_project_master);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response DeleteUserappWorkProjectMaster(Int64 Project_Id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.DeleteUserappWorkProjectMaster(Project_Id);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }






        public Response GetUserappWorkProjectMaster(Int64 Project_Id)
        {

            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetUserappWorkProjectMaster(Project_Id);

                userapp_work_project_master objuserapp_work_project_master = new userapp_work_project_master();

                List<userapp_work_project_master> userapp_work_project_master_details = new List<userapp_work_project_master>();
                userapp_work_project_master_details = ConvertDataTable<userapp_work_project_master>(dset);

                //string JSONresult;
                //JSONresult = JsonConvert.SerializeObject(dset);
                //response.Data = JSONresult;

                response.Data = (userapp_work_project_master_details).ToList();
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
