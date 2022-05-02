using getbiz_work_project_management.Getbiz_DbContext;
using getbiz_work_project_management.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace getbiz_work_project_management.Repository.Userapp_User_Permissions
{
    public class UserappUserPermissionsRepository : IUserappUserPermissionsRepository
    {


        public readonly WorkProjectManagementAppDB_DbContext _DbContext;
        public UserappUserPermissionsRepository(WorkProjectManagementAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }


        public Response AddUserappUserPermissions(userapp_user_permissions obj_userapp_user_permissions)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.AddUserappUserPermissions(obj_userapp_user_permissions);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }




        //public Response AddUserappUserPermissions(userapp_user_permissions obj_userapp_user_permissions)
        //{
        //    Response response = new Response();
        //    try
        //    {
        //        userapp_user_permissions _obj_userapp_user_permissions = new userapp_user_permissions();
        //        
        //        _obj_userapp_user_permissions.user_id = obj_userapp_user_permissions.user_id;
        //        _obj_userapp_user_permissions.parent_id = obj_userapp_user_permissions.parent_id;
        //        _obj_userapp_user_permissions.is_parent = obj_userapp_user_permissions.is_parent;
        //        _obj_userapp_user_permissions.can_edit_project = obj_userapp_user_permissions.can_edit_project;
        //        _obj_userapp_user_permissions.is_project_leader = obj_userapp_user_permissions.is_project_leader;
        //        _obj_userapp_user_permissions.task_id = obj_userapp_user_permissions.task_id;
        //        _obj_userapp_user_permissions.can_edit_task = obj_userapp_user_permissions.can_edit_task;
        //        _obj_userapp_user_permissions.is_task_leader = obj_userapp_user_permissions.is_task_leader;
        //        _obj_userapp_user_permissions.sub_task_id = obj_userapp_user_permissions.sub_task_id;
        //        _obj_userapp_user_permissions.can_edit_sub_task = obj_userapp_user_permissions.can_edit_sub_task;
        //        _obj_userapp_user_permissions.is_sub_task_leader = obj_userapp_user_permissions.is_sub_task_leader;
        //        _obj_userapp_user_permissions.can_access_team_members_projects = obj_userapp_user_permissions.can_access_team_members_projects;
        //        _obj_userapp_user_permissions.project_id = obj_userapp_user_permissions.project_id;


        //        _DbContext.Attach(_obj_userapp_user_permissions);
        //        _DbContext.Entry(_obj_userapp_user_permissions).Property(p => p.user_id).IsModified = true;
        //        _DbContext.Entry(_obj_userapp_user_permissions).Property(p => p.parent_id).IsModified = true;
        //        _DbContext.Entry(_obj_userapp_user_permissions).Property(p => p.is_parent).IsModified = true;
        //        _DbContext.Entry(_obj_userapp_user_permissions).Property(p => p.can_edit_project).IsModified = true;
        //        _DbContext.Entry(_obj_userapp_user_permissions).Property(p => p.is_project_leader).IsModified = true;
        //        _DbContext.Entry(_obj_userapp_user_permissions).Property(p => p.task_id).IsModified = true;
        //        _DbContext.Entry(_obj_userapp_user_permissions).Property(p => p.can_edit_task).IsModified = true;
        //        _DbContext.Entry(_obj_userapp_user_permissions).Property(p => p.is_task_leader).IsModified = true;
        //        _DbContext.Entry(_obj_userapp_user_permissions).Property(p => p.can_edit_sub_task).IsModified = true;
        //        _DbContext.Entry(_obj_userapp_user_permissions).Property(p => p.is_sub_task_leader).IsModified = true;
        //        _DbContext.Entry(_obj_userapp_user_permissions).Property(p => p.can_access_team_members_projects).IsModified = true;
        //        _DbContext.Entry(_obj_userapp_user_permissions).Property(p => p.project_id).IsModified = true;
        //        _DbContext.SaveChanges();

        //        response.Message = "Data updated successfully !!";
        //        response.Status = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = "Data updation failed !!";
        //        response.Status = false;
        //    }
        //    return response;


        //}




















        //public Response UpdateUserappUserPermissions(userapp_user_permissions obj_userapp_user_permissions)
        //{
        //    Response response = new Response();
        //    try
        //    {
        //        GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
        //        var result = Obj_GetSetDatabase.UpdateUserappUserPermissions(obj_userapp_user_permissions);
        //        response = result;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.Message = ex.Message;
        //    }
        //    return response;
        //}



        public Response GetUserappUserPermissions(bool Is_Parent, string Parent_Id)
        {

            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetUserappUserPermissions(Is_Parent,  Parent_Id);

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
