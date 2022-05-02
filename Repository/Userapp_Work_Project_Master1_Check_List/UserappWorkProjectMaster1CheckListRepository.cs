using getbiz_work_project_management.Getbiz_DbContext;
using getbiz_work_project_management.Models;
using getbiz_work_project_management.V_Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Repository.Userapp_Work_Project_Master1_Check_List
{
    public class UserappWorkProjectMaster1CheckListRepository : IUserappWorkProjectMaster1CheckListRepository
    {

        public readonly WorkProjectManagementAppDB_DbContext _DbContext;

        public UserappWorkProjectMaster1CheckListRepository(WorkProjectManagementAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }



        public Response AddUserappWorkProjectMaster1CheckList(userapp_work_project_master1_check_list obj_userapp_work_project_master1_check_list)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.AddUserappWorkProjectMaster1CheckList(obj_userapp_work_project_master1_check_list);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response UpdateUserappWorkProjectMaster1CheckList(userapp_work_project_master1_check_list obj_userapp_work_project_master1_check_list)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.UpdateUserappWorkProjectMaster1CheckList(obj_userapp_work_project_master1_check_list);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }





        public Response GetALLUserappWorkProjectMaster1CheckList(string Id)
        {

            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetALLUserappWorkProjectMaster1CheckList(Id);


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




        public Response ReArrangCheckList(rearang_check_list obj_rearang_check_list)
        {

            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.ReArrangCheckList(obj_rearang_check_list);
                 response.Data = result;
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

        public Response DeleteUserappWorkProjectMaster1CheckList(
            string check_list_s_no,
            string id,
            string project_name,
            int check_list_user_id,
            string check_list_user_name
            )
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.DeleteUserappWorkProjectMaster1CheckList(
                 check_list_s_no,
                 id,
                 project_name,
                 check_list_user_id,
                 check_list_user_name
                 );
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
