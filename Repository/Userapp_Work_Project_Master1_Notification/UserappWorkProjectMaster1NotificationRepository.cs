using getbiz_work_project_management.Getbiz_DbContext;
using getbiz_work_project_management.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Repository.Userapp_Work_Project_Master1_Notification
{
    public class UserappWorkProjectMaster1NotificationRepository : IUserappWorkProjectMaster1NotificationRepository
    {
        public Response UpdateUserappWorkProjectMaster1Notification(
             string Id,
             bool NotificationMuteUnmute,
             int UserId
            )
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.UpdateUserappWorkProjectMaster1Notification(Id, NotificationMuteUnmute, UserId);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



        public Response GetALLUserAppWorkProjectMaster1Notification(string Id, int UserId)
        {

            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetALLUserAppWorkProjectMaster1Notification(Id, UserId);


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
    }
}
