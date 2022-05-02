

using getbiz_work_project_management.Models;
using getbiz_work_project_management.V_Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace getbiz_work_project_management.Getbiz_DbContext
{
    public class GetSetDatabase
    {

     //  string connection = "Server=185.252.235.20;User ID=root;Password=GetBizMysqlDatabasePwd2021@;Database=workprojectmanagementdb; Allow User Variables=true";
  

       string connection = "Server=localhost;User ID=root;Password=mysql;Database=workprojectmanagementdb; Allow User Variables=true";


        public Response AddUserappWorkProjectMaster(userapp_work_project_master obj_userapp_work_project_master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            MySqlParameter[] param = new MySqlParameter[15];

            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_project_id", MySqlDbType.VarChar);
                param[0].Value = obj_userapp_work_project_master.project_id;

                param[1] = new MySqlParameter("p_project_title", MySqlDbType.VarChar);
                param[1].Value = obj_userapp_work_project_master.project_title;

                param[2] = new MySqlParameter("p_project_description", MySqlDbType.VarChar);
                param[2].Value = obj_userapp_work_project_master.project_description;

                param[3] = new MySqlParameter("p_project_start_utc_timestamp", MySqlDbType.VarChar);
                param[3].Value = obj_userapp_work_project_master.project_start_utc_timestamp;

                param[4] = new MySqlParameter("p_project_end_utc_timestamp", MySqlDbType.VarChar);
                param[4].Value = obj_userapp_work_project_master.project_end_utc_timestamp;

                param[5] = new MySqlParameter("p_project_attachments", MySqlDbType.VarChar);
                param[5].Value = obj_userapp_work_project_master.project_attachments;

                param[6] = new MySqlParameter("p_project_status", MySqlDbType.Int64);
                param[6].Value = obj_userapp_work_project_master.project_status;

                param[7] = new MySqlParameter("p_project_completion_utc_timestamp", MySqlDbType.VarChar);
                param[7].Value = obj_userapp_work_project_master.project_completion_utc_timestamp;

                param[8] = new MySqlParameter("p_project_reason_for_suspension", MySqlDbType.VarChar);
                param[8].Value = obj_userapp_work_project_master.project_reason_for_suspension;

                param[9] = new MySqlParameter("p_user_ids_requesting_app_notification_on_changes_made", MySqlDbType.VarChar);
                param[9].Value = obj_userapp_work_project_master.user_ids_requesting_app_notification_on_changes_made;

                param[10] = new MySqlParameter("p_user_ids_requesting_app_notification_on_completion", MySqlDbType.VarChar);
                param[10].Value = obj_userapp_work_project_master.user_ids_requesting_app_notification_on_completion;

                param[11] = new MySqlParameter("p_user_ids_requesting_app_notification_on_delay", MySqlDbType.VarChar);
                param[11].Value = obj_userapp_work_project_master.user_ids_requesting_app_notification_on_delay;

                param[12] = new MySqlParameter("p_user_ids_requesting_app_notification_on_suspension", MySqlDbType.VarChar);
                param[12].Value = obj_userapp_work_project_master.user_ids_requesting_app_notification_on_suspension;

                param[13] = new MySqlParameter("p_user_ids_requesting_app_notification_on_hiding_deletion", MySqlDbType.VarChar);
                param[13].Value = obj_userapp_work_project_master.user_ids_requesting_app_notification_on_hiding_deletion;

                param[14] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                param[14].Value = obj_userapp_work_project_master.user_id;


                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AddUserappWorkProjectMaster", param);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MySqlParameter[] param1 = new MySqlParameter[2];

                        string GetProject_MaxId = ds.Tables[0].Rows[0]["Project_MaxId"].ToString();
                        using MySqlConnection con1 = new MySqlConnection(connection);
                        {
                            param1[0] = new MySqlParameter("P_Project_MaxId", MySqlDbType.Int64);
                            param1[0].Value = GetProject_MaxId;


                            param1[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                            param1[1].Value = obj_userapp_work_project_master.user_id;

                            ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_CreateDynamicallyUserappProjectIdTasks", param1);
                        }
                        if (Convert.ToString(ds1.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "Data Inserted successfully";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds1.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds1.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public Response AddUserappProjectIdTasks(userapp_project_id_tasks obj_userapp_project_id_tasks)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            MySqlParameter[] param = new MySqlParameter[14];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_task_id", MySqlDbType.Int64);
                    param[0].Value = obj_userapp_project_id_tasks.task_id;

                    param[1] = new MySqlParameter("p_task_title", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_project_id_tasks.task_title;

                    param[2] = new MySqlParameter("p_task_description", MySqlDbType.VarChar);
                    param[2].Value = obj_userapp_project_id_tasks.task_description;

                    param[3] = new MySqlParameter("p_task_start_utc_timestamp", MySqlDbType.VarChar);
                    param[3].Value = obj_userapp_project_id_tasks.task_start_utc_timestamp;

                    param[4] = new MySqlParameter("p_task_end_utc_timestamp", MySqlDbType.VarChar);
                    param[4].Value = obj_userapp_project_id_tasks.task_end_utc_timestamp;

                    param[5] = new MySqlParameter("p_task_attachments", MySqlDbType.VarChar);
                    param[5].Value = obj_userapp_project_id_tasks.task_attachments;

                    param[6] = new MySqlParameter("p_task_status", MySqlDbType.Int64);
                    param[6].Value = obj_userapp_project_id_tasks.task_status;

                    param[7] = new MySqlParameter("p_task_completion_utc_timestamp", MySqlDbType.VarChar);
                    param[7].Value = obj_userapp_project_id_tasks.task_completion_utc_timestamp;

                    param[8] = new MySqlParameter("p_task_reason_for_suspension", MySqlDbType.VarChar);
                    param[8].Value = obj_userapp_project_id_tasks.task_reason_for_suspension;

                    param[9] = new MySqlParameter("p_user_ids_requesting_app_notification_on_changes_made", MySqlDbType.VarChar);
                    param[9].Value = obj_userapp_project_id_tasks.user_ids_requesting_app_notification_on_changes_made;

                    param[10] = new MySqlParameter("p_user_ids_requesting_app_notification_on_completion", MySqlDbType.VarChar);
                    param[10].Value = obj_userapp_project_id_tasks.user_ids_requesting_app_notification_on_completion;

                    param[11] = new MySqlParameter("p_user_ids_requesting_app_notification_on_delay", MySqlDbType.VarChar);
                    param[11].Value = obj_userapp_project_id_tasks.user_ids_requesting_app_notification_on_delay;

                    param[12] = new MySqlParameter("p_user_ids_requesting_app_notification_on_suspension", MySqlDbType.VarChar);
                    param[12].Value = obj_userapp_project_id_tasks.user_ids_requesting_app_notification_on_suspension;

                    param[13] = new MySqlParameter("p_project_id", MySqlDbType.Int64);
                    param[13].Value = obj_userapp_project_id_tasks.project_id;

                    //SP_AddUserappProjectIdTasks

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AddUserappProjectIdTasks", param);
                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MySqlParameter[] param1 = new MySqlParameter[3];

                        string GetTask_MaxId = ds.Tables[0].Rows[0]["Task_MaxId"].ToString();
                        using MySqlConnection con1 = new MySqlConnection(connection);
                        {
                            param1[0] = new MySqlParameter("P_Task_MaxId", MySqlDbType.Int64);
                            param1[0].Value = GetTask_MaxId;

                            param1[1] = new MySqlParameter("p_project_id", MySqlDbType.Int64);
                            param1[1].Value = obj_userapp_project_id_tasks.project_id;

                            param1[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                            param1[2].Value = obj_userapp_project_id_tasks.user_id;

                            ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_CreateDynamicallyUserappProjectIdTaskIdSubTasks", param1);
                        }
                        if (Convert.ToString(ds1.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "Data Inserted successfully";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds1.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds1.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {
                            response.Data = "";
                            response.Message = "Data Added successfully !!";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }

        public Response AddUserappProjectIdTaskIdSubTasks(userapp_project_id_task_id_sub_tasks obj_userapp_project_id_task_id_sub_tasks)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            MySqlParameter[] param = new MySqlParameter[16];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_sub_task_id", MySqlDbType.Int64);
                    param[0].Value = obj_userapp_project_id_task_id_sub_tasks.sub_task_id;

                    param[1] = new MySqlParameter("p_sub_task_title", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_project_id_task_id_sub_tasks.sub_task_title;

                    param[2] = new MySqlParameter("p_sub_task_description", MySqlDbType.VarChar);
                    param[2].Value = obj_userapp_project_id_task_id_sub_tasks.sub_task_description;

                    param[3] = new MySqlParameter("p_sub_start_utc_timestamp", MySqlDbType.VarChar);
                    param[3].Value = obj_userapp_project_id_task_id_sub_tasks.sub_start_utc_timestamp;

                    param[4] = new MySqlParameter("p_sub_end_utc_timestamp", MySqlDbType.VarChar);
                    param[4].Value = obj_userapp_project_id_task_id_sub_tasks.sub_end_utc_timestamp;

                    param[5] = new MySqlParameter("p_sub_task_attachments", MySqlDbType.VarChar);
                    param[5].Value = obj_userapp_project_id_task_id_sub_tasks.sub_task_attachments;

                    param[6] = new MySqlParameter("p_sub_task_status", MySqlDbType.Int64);
                    param[6].Value = obj_userapp_project_id_task_id_sub_tasks.sub_task_status;

                    param[7] = new MySqlParameter("p_sub_task_completion_utc_timestamp", MySqlDbType.VarChar);
                    param[7].Value = obj_userapp_project_id_task_id_sub_tasks.sub_task_completion_utc_timestamp;

                    param[8] = new MySqlParameter("p_sub_task_reason_for_suspension", MySqlDbType.VarChar);
                    param[8].Value = obj_userapp_project_id_task_id_sub_tasks.sub_task_reason_for_suspension;

                    param[9] = new MySqlParameter("p_user_ids_requesting_app_notification_on_changes_made", MySqlDbType.VarChar);
                    param[9].Value = obj_userapp_project_id_task_id_sub_tasks.user_ids_requesting_app_notification_on_changes_made;

                    param[10] = new MySqlParameter("p_user_ids_requesting_app_notification_on_completion", MySqlDbType.VarChar);
                    param[10].Value = obj_userapp_project_id_task_id_sub_tasks.user_ids_requesting_app_notification_on_completion;

                    param[11] = new MySqlParameter("p_user_ids_requesting_app_notification_on_delay", MySqlDbType.VarChar);
                    param[11].Value = obj_userapp_project_id_task_id_sub_tasks.user_ids_requesting_app_notification_on_delay;

                    param[12] = new MySqlParameter("p_user_ids_requesting_app_notification_on_suspension", MySqlDbType.VarChar);
                    param[12].Value = obj_userapp_project_id_task_id_sub_tasks.user_ids_requesting_app_notification_on_suspension;

                    param[13] = new MySqlParameter("p_project_id", MySqlDbType.VarChar);
                    param[13].Value = obj_userapp_project_id_task_id_sub_tasks.project_id;

                    param[14] = new MySqlParameter("p_task_id", MySqlDbType.Int64);
                    param[14].Value = obj_userapp_project_id_task_id_sub_tasks.task_id;

                    param[15] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[15].Value = obj_userapp_project_id_task_id_sub_tasks.user_id;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AddUserappProjectIdTaskIdSubTasks", param);
                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MySqlParameter[] param1 = new MySqlParameter[3];

                        string GetSub_Task_MaxId = ds.Tables[0].Rows[0]["Sub_Task_MaxId"].ToString();
                        using MySqlConnection con1 = new MySqlConnection(connection);
                        {
                            param1[0] = new MySqlParameter("P_Sub_Task_MaxId", MySqlDbType.Int64);
                            param1[0].Value = GetSub_Task_MaxId;

                            param1[1] = new MySqlParameter("p_project_id", MySqlDbType.VarChar);
                            param1[1].Value = obj_userapp_project_id_task_id_sub_tasks.project_id;

                            param1[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                            param1[2].Value = obj_userapp_project_id_task_id_sub_tasks.user_id;

                            ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_DynamicInserUserappUserPermissions", param1);
                        }

                    }

                    if (Convert.ToString(ds1.Tables[0].Rows[0]["Message"]) == "200")
                    {

                        response.Data = "";
                        response.Message = "Data Inserted successfully";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = Convert.ToString(ds1.Tables[0].Rows[0]["Message"]);
                        response.Status = Convert.ToInt32(ds1.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                    }

                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }


        //public Response AddUserRegisteration(user_registeration obj_user_registeration)
        //{
        //    Response response = new Response();
        //    DataSet ds = new DataSet();

        //    MySqlParameter[] param = new MySqlParameter[3];
        //    try
        //    {
        //        using MySqlConnection con = new MySqlConnection(connection);
        //        {

        //            param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
        //            param[0].Value = obj_user_registeration.user_id;

        //            param[1] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
        //            param[1].Value = obj_user_registeration.text;

        //            param[2] = new MySqlParameter("p_password", MySqlDbType.VarChar);
        //            param[2].Value = obj_user_registeration.password;


        //            ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AddUserRegisteration", param);
        //        }

        //        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
        //        {

        //            response.Data = "";
        //            response.Message = "Data Added successfully";
        //            response.Status = true;
        //        }
        //        else
        //        {
        //            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
        //            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
        //        }

        //    }

        //    catch (Exception ex)
        //    {

        //    }
        //    return response;
        //}

        public Response UpdateUserappWorkProjectMaster(userapp_work_project_master obj_userapp_work_project_master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            MySqlParameter[] param = new MySqlParameter[15];

            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_project_id", MySqlDbType.VarChar);
                param[0].Value = obj_userapp_work_project_master.project_id;

                param[1] = new MySqlParameter("p_project_title", MySqlDbType.VarChar);
                param[1].Value = obj_userapp_work_project_master.project_title;

                param[2] = new MySqlParameter("p_project_description", MySqlDbType.VarChar);
                param[2].Value = obj_userapp_work_project_master.project_description;

                param[3] = new MySqlParameter("p_project_start_utc_timestamp", MySqlDbType.VarChar);
                param[3].Value = obj_userapp_work_project_master.project_start_utc_timestamp;

                param[4] = new MySqlParameter("p_project_end_utc_timestamp", MySqlDbType.VarChar);
                param[4].Value = obj_userapp_work_project_master.project_end_utc_timestamp;

                param[5] = new MySqlParameter("p_project_attachments", MySqlDbType.VarChar);
                param[5].Value = obj_userapp_work_project_master.project_attachments;

                param[6] = new MySqlParameter("p_project_status", MySqlDbType.Int64);
                param[6].Value = obj_userapp_work_project_master.project_status;

                param[7] = new MySqlParameter("p_project_completion_utc_timestamp", MySqlDbType.VarChar);
                param[7].Value = obj_userapp_work_project_master.project_completion_utc_timestamp;

                param[8] = new MySqlParameter("p_project_reason_for_suspension", MySqlDbType.VarChar);
                param[8].Value = obj_userapp_work_project_master.project_reason_for_suspension;

                param[9] = new MySqlParameter("p_user_ids_requesting_app_notification_on_changes_made", MySqlDbType.VarChar);
                param[9].Value = obj_userapp_work_project_master.user_ids_requesting_app_notification_on_changes_made;

                param[10] = new MySqlParameter("p_user_ids_requesting_app_notification_on_completion", MySqlDbType.VarChar);
                param[10].Value = obj_userapp_work_project_master.user_ids_requesting_app_notification_on_completion;

                param[11] = new MySqlParameter("p_user_ids_requesting_app_notification_on_delay", MySqlDbType.VarChar);
                param[11].Value = obj_userapp_work_project_master.user_ids_requesting_app_notification_on_delay;

                param[12] = new MySqlParameter("p_user_ids_requesting_app_notification_on_suspension", MySqlDbType.VarChar);
                param[12].Value = obj_userapp_work_project_master.user_ids_requesting_app_notification_on_suspension;

                param[13] = new MySqlParameter("p_user_ids_requesting_app_notification_on_hiding_deletion", MySqlDbType.VarChar);
                param[13].Value = obj_userapp_work_project_master.user_ids_requesting_app_notification_on_hiding_deletion;

                param[14] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                param[14].Value = obj_userapp_work_project_master.user_id;


                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserappWorkProjectMaster", param);

            }
            catch (Exception ex)
            {

            }
            if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
            {

                response.Data = "";
                response.Message = "Data updated successfully !!";
                response.Status = true;
            }
            else
            {
                response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
            }
            return response;
        }

        public Response UpdateUserappProjectIdTasks(userapp_project_id_tasks obj_userapp_project_id_tasks)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            MySqlParameter[] param = new MySqlParameter[15];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_task_id", MySqlDbType.Int64);
                    param[0].Value = obj_userapp_project_id_tasks.task_id;

                    param[1] = new MySqlParameter("p_task_title", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_project_id_tasks.task_title;

                    param[2] = new MySqlParameter("p_task_description", MySqlDbType.VarChar);
                    param[2].Value = obj_userapp_project_id_tasks.task_description;

                    param[3] = new MySqlParameter("p_task_start_utc_timestamp", MySqlDbType.VarChar);
                    param[3].Value = obj_userapp_project_id_tasks.task_start_utc_timestamp;

                    param[4] = new MySqlParameter("p_task_end_utc_timestamp", MySqlDbType.VarChar);
                    param[4].Value = obj_userapp_project_id_tasks.task_end_utc_timestamp;

                    param[5] = new MySqlParameter("p_task_attachments", MySqlDbType.VarChar);
                    param[5].Value = obj_userapp_project_id_tasks.task_attachments;

                    param[6] = new MySqlParameter("p_task_status", MySqlDbType.Int64);
                    param[6].Value = obj_userapp_project_id_tasks.task_status;

                    param[7] = new MySqlParameter("p_task_completion_utc_timestamp", MySqlDbType.VarChar);
                    param[7].Value = obj_userapp_project_id_tasks.task_completion_utc_timestamp;



                    param[8] = new MySqlParameter("p_task_reason_for_suspension", MySqlDbType.VarChar);
                    param[8].Value = obj_userapp_project_id_tasks.task_reason_for_suspension;

                    param[9] = new MySqlParameter("p_user_ids_requesting_app_notification_on_changes_made", MySqlDbType.VarChar);
                    param[9].Value = obj_userapp_project_id_tasks.user_ids_requesting_app_notification_on_changes_made;

                    param[10] = new MySqlParameter("p_user_ids_requesting_app_notification_on_completion", MySqlDbType.VarChar);
                    param[10].Value = obj_userapp_project_id_tasks.user_ids_requesting_app_notification_on_completion;

                    param[11] = new MySqlParameter("p_user_ids_requesting_app_notification_on_delay", MySqlDbType.VarChar);
                    param[11].Value = obj_userapp_project_id_tasks.user_ids_requesting_app_notification_on_delay;

                    param[12] = new MySqlParameter("p_user_ids_requesting_app_notification_on_suspension", MySqlDbType.VarChar);
                    param[12].Value = obj_userapp_project_id_tasks.user_ids_requesting_app_notification_on_suspension;

                    param[13] = new MySqlParameter("p_project_id", MySqlDbType.VarChar);
                    param[13].Value = obj_userapp_project_id_tasks.project_id;

                    param[14] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[14].Value = obj_userapp_project_id_tasks.user_id;

                    //SP_AddUserappProjectIdTasks

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserappProjectIdTasks", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data update successfully !!";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }

        public Response UpdateUserappProjectIdTaskIdSubTasks(userapp_project_id_task_id_sub_tasks obj_userapp_project_id_task_id_sub_tasks)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[16];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_sub_task_id", MySqlDbType.Int64);
                    param[0].Value = obj_userapp_project_id_task_id_sub_tasks.sub_task_id;

                    param[1] = new MySqlParameter("p_sub_task_title", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_project_id_task_id_sub_tasks.sub_task_title;

                    param[2] = new MySqlParameter("p_sub_task_description", MySqlDbType.VarChar);
                    param[2].Value = obj_userapp_project_id_task_id_sub_tasks.sub_task_description;

                    param[3] = new MySqlParameter("p_sub_start_utc_timestamp", MySqlDbType.VarChar);
                    param[3].Value = obj_userapp_project_id_task_id_sub_tasks.sub_start_utc_timestamp;

                    param[4] = new MySqlParameter("p_sub_end_utc_timestamp", MySqlDbType.VarChar);
                    param[4].Value = obj_userapp_project_id_task_id_sub_tasks.sub_end_utc_timestamp;

                    param[5] = new MySqlParameter("p_sub_task_attachments", MySqlDbType.VarChar);
                    param[5].Value = obj_userapp_project_id_task_id_sub_tasks.sub_task_attachments;

                    param[6] = new MySqlParameter("p_sub_task_status", MySqlDbType.Int64);
                    param[6].Value = obj_userapp_project_id_task_id_sub_tasks.sub_task_status;

                    param[7] = new MySqlParameter("p_sub_task_completion_utc_timestamp", MySqlDbType.VarChar);
                    param[7].Value = obj_userapp_project_id_task_id_sub_tasks.sub_task_completion_utc_timestamp;

                    param[8] = new MySqlParameter("p_sub_task_reason_for_suspension", MySqlDbType.VarChar);
                    param[8].Value = obj_userapp_project_id_task_id_sub_tasks.sub_task_reason_for_suspension;

                    param[9] = new MySqlParameter("p_user_ids_requesting_app_notification_on_changes_made", MySqlDbType.VarChar);
                    param[9].Value = obj_userapp_project_id_task_id_sub_tasks.user_ids_requesting_app_notification_on_changes_made;

                    param[10] = new MySqlParameter("p_user_ids_requesting_app_notification_on_completion", MySqlDbType.VarChar);
                    param[10].Value = obj_userapp_project_id_task_id_sub_tasks.user_ids_requesting_app_notification_on_completion;

                    param[11] = new MySqlParameter("p_user_ids_requesting_app_notification_on_delay", MySqlDbType.VarChar);
                    param[11].Value = obj_userapp_project_id_task_id_sub_tasks.user_ids_requesting_app_notification_on_delay;

                    param[12] = new MySqlParameter("p_user_ids_requesting_app_notification_on_suspension", MySqlDbType.VarChar);
                    param[12].Value = obj_userapp_project_id_task_id_sub_tasks.user_ids_requesting_app_notification_on_suspension;

                    param[13] = new MySqlParameter("p_project_id", MySqlDbType.VarChar);
                    param[13].Value = obj_userapp_project_id_task_id_sub_tasks.project_id;

                    param[14] = new MySqlParameter("p_task_id", MySqlDbType.VarChar);
                    param[14].Value = obj_userapp_project_id_task_id_sub_tasks.task_id;

                    param[15] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[15].Value = obj_userapp_project_id_task_id_sub_tasks.user_id;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserappProjectIdTaskIdSubTasks", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data update successfully !!";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }

        //public Response UpdateUserappUserPermissions(userapp_user_permissions obj_userapp_user_permissions)
        //{
        //    Response response = new Response();
        //    DataSet ds = new DataSet();

        //    MySqlParameter[] param = new MySqlParameter[11];
        //    try
        //    {
        //        using MySqlConnection con = new MySqlConnection(connection);
        //        {

        //            param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
        //            param[0].Value = obj_userapp_user_permissions.user_id;

        //            //param[1] = new MySqlParameter("p_project_id", MySqlDbType.VarChar);
        //            //param[1].Value = obj_userapp_user_permissions.project_id;

        //            param[2] = new MySqlParameter("p_can_edit_project", MySqlDbType.Bool);
        //            param[2].Value = obj_userapp_user_permissions.can_edit_project;

        //            param[3] = new MySqlParameter("p_is_project_leader", MySqlDbType.Bool);
        //            param[3].Value = obj_userapp_user_permissions.is_project_leader;

        //            param[4] = new MySqlParameter("p_task_id", MySqlDbType.VarChar);
        //            param[4].Value = obj_userapp_user_permissions.task_id;


        //            param[5] = new MySqlParameter("p_can_edit_task", MySqlDbType.Bool);
        //            param[5].Value = obj_userapp_user_permissions.can_edit_task;


        //            param[6] = new MySqlParameter("p_is_task_leader", MySqlDbType.Bool);
        //            param[6].Value = obj_userapp_user_permissions.is_task_leader;


        //            param[7] = new MySqlParameter("p_sub_task_id", MySqlDbType.VarChar);
        //            param[7].Value = obj_userapp_user_permissions.sub_task_id;

        //            param[8] = new MySqlParameter("p_can_edit_sub_task", MySqlDbType.Bool);
        //            param[8].Value = obj_userapp_user_permissions.can_edit_sub_task;

        //            param[9] = new MySqlParameter("p_is_sub_task_leader", MySqlDbType.Bool);
        //            param[9].Value = obj_userapp_user_permissions.is_sub_task_leader;

        //            param[10] = new MySqlParameter("p_can_access_team_members_projects", MySqlDbType.Int64);
        //            param[10].Value = obj_userapp_user_permissions.can_access_team_members_projects;


        //            ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserappUserPermissions", param);
        //        }

        //        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
        //        {

        //            response.Data = "";
        //            response.Message = "Data update successfully !!";
        //            response.Status = true;
        //        }
        //        else
        //        {
        //            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
        //            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
        //        }

        //    }

        //    catch (Exception ex)
        //    {

        //    }
        //    return response;
        //}

        public Response DeleteUserappWorkProjectMaster(Int64 Project_Id)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[1];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_Project_Id", MySqlDbType.Int64);
                    param[0].Value = Project_Id;



                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteUserappWorkProjectMaster", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data Deleted successfully !!";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }

        public Response DeleteUserappProjectIdTasks(Int64 Project_Id, Int64 Task_Id)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_Project_Id", MySqlDbType.Int64);
                    param[0].Value = Project_Id;

                    param[1] = new MySqlParameter("p_Task_Id", MySqlDbType.Int64);
                    param[1].Value = Task_Id;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteUserappProjectIdTasks", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data Deleted successfully !!";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }

        public Response DeleteUserappProjectIdTaskIdSubTasks(Int64 Project_Id, Int64 Task_Id, Int64 Sub_Task_Id)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_Project_Id", MySqlDbType.Int64);
                    param[0].Value = Project_Id;

                    param[1] = new MySqlParameter("p_Task_Id", MySqlDbType.Int64);
                    param[1].Value = Task_Id;


                    param[2] = new MySqlParameter("p_Sub_Task_Id", MySqlDbType.Int64);
                    param[2].Value = Sub_Task_Id;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteUserappProjectIdTaskIdSubTasks", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data Deleted successfully !!";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }
        public DataTable GetUserappWorkProjectMaster(Int64 Project_Id)
        {
            {
                Response response = new Response();
                DataTable ds = new DataTable();
                MySqlParameter[] param = new MySqlParameter[1];
                try
                {
                    using MySqlConnection con = new MySqlConnection(connection);
                    {

                        param[0] = new MySqlParameter("p_Project_Id", MySqlDbType.Int64);
                        param[0].Value = Project_Id;


                        ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUserappWorkProjectMaster", param);
                        return ds;

                    }

                }

                catch (Exception ex)
                {

                }
                return ds;
            }
        }

        public DataTable GetUserappProjectIdTasks(Int64 Project_Id, Int64 Task_Id)
        {
            {
                Response response = new Response();
                DataTable ds = new DataTable();
                MySqlParameter[] param = new MySqlParameter[2];
                try
                {
                    using MySqlConnection con = new MySqlConnection(connection);
                    {

                        param[0] = new MySqlParameter("p_Project_Id", MySqlDbType.Int64);
                        param[0].Value = Project_Id;

                        param[1] = new MySqlParameter("p_Task_Id", MySqlDbType.Int64);
                        param[1].Value = Task_Id;

                        ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUserappProjectIdTasks", param);
                        return ds;
                    }
                }

                catch (Exception ex)
                {

                }
                return ds;
            }
        }

        public DataTable GetUserappProjectIdTaskIdSubTasks(Int64 Project_Id, Int64 Task_Id, Int64 Sub_Task_Id)
        {
            {
                Response response = new Response();
                DataTable ds = new DataTable();
                MySqlParameter[] param = new MySqlParameter[3];
                try
                {
                    using MySqlConnection con = new MySqlConnection(connection);
                    {

                        param[0] = new MySqlParameter("p_Project_Id", MySqlDbType.Int64);
                        param[0].Value = Project_Id;

                        param[1] = new MySqlParameter("p_Task_Id", MySqlDbType.Int64);
                        param[1].Value = Task_Id;

                        param[2] = new MySqlParameter("p_Sub_Task_Id", MySqlDbType.Int64);
                        param[2].Value = Sub_Task_Id;

                        ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUserappProjectIdTaskIdSubTasks", param);
                        return ds;
                    }
                }

                catch (Exception ex)
                {

                }
                return ds;
            }
        }

        public DataTable GetUserappUserPermissions(bool Is_Parent, string Parent_Id)
        {
            {
                Response response = new Response();
                DataTable ds = new DataTable();
                MySqlParameter[] param = new MySqlParameter[2];
                try
                {
                    using MySqlConnection con = new MySqlConnection(connection);
                    {
                        param[0] = new MySqlParameter("p_Is_Parent", MySqlDbType.Bool);
                        param[0].Value = Is_Parent;

                        param[1] = new MySqlParameter("p_Parent_Id", MySqlDbType.VarChar);
                        param[1].Value = Parent_Id;


                        ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUserappUserPermissions", param);
                        return ds;
                    }

                }

                catch (Exception ex)
                {

                }
                return ds;
            }
        }
        public DataTable GetUserappAuditTrail(string Task_Id)
        {
            {
                Response response = new Response();
                DataTable ds = new DataTable();
                MySqlParameter[] param = new MySqlParameter[1];
                try
                {
                    using MySqlConnection con = new MySqlConnection(connection);
                    {
                        param[0] = new MySqlParameter("p_Task_Id", MySqlDbType.VarChar);
                        param[0].Value = Task_Id;


                        ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUserappAuditTrail", param);
                        return ds;
                    }

                }

                catch (Exception ex)
                {

                }
                return ds;
            }
        }

        public Response AddUserappWorkProjectMaster1(userapp_work_project_master1 obj_userapp_work_project_master1)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            MySqlParameter[] param = new MySqlParameter[9];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                    param[0].Value = obj_userapp_work_project_master1.id;

                    param[1] = new MySqlParameter("p_parentId", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_work_project_master1.parentId;

                    param[2] = new MySqlParameter("p_title", MySqlDbType.VarChar);
                    param[2].Value = obj_userapp_work_project_master1.title;

                    param[3] = new MySqlParameter("p_start", MySqlDbType.VarChar);
                    param[3].Value = obj_userapp_work_project_master1.start;

                    param[4] = new MySqlParameter("p_end", MySqlDbType.VarChar);
                    param[4].Value = obj_userapp_work_project_master1.end;

                    param[5] = new MySqlParameter("p_progress", MySqlDbType.VarChar);
                    param[5].Value = obj_userapp_work_project_master1.progress;

                    param[6] = new MySqlParameter("p_color", MySqlDbType.VarChar);
                    param[6].Value = obj_userapp_work_project_master1.color;

                    param[7] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[7].Value = obj_userapp_work_project_master1.user_id;

                    param[8] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                    param[8].Value = obj_userapp_work_project_master1.user_name;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AddUserappWorkProjectMaster1", param);
                }


                MySqlParameter[] param1 = new MySqlParameter[1];
                try
                {

                    var Project_Id_wothout_special_charaters = obj_userapp_work_project_master1.id.Replace("-","");

                    using MySqlConnection con1 = new MySqlConnection(connection);
                    {
                        param1[0] = new MySqlParameter("p_Get_Project_Max_Id", MySqlDbType.VarChar);
                        param1[0].Value = Project_Id_wothout_special_charaters;


                        ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_DynamicallyCreatedCheckList", param1);
                    }
                }
                catch (Exception ex)
                {

                }

                if (Convert.ToString(ds1.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data Added successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds1.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds1.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }

        public Response UpdateUserappWorkProjectMaster1(userapp_work_project_master1 obj_userapp_work_project_master1)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            try
            {
                if (obj_userapp_work_project_master1.title != null)
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    MySqlParameter[] param = new MySqlParameter[4];
                    {

                        param[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                        param[0].Value = obj_userapp_work_project_master1.id;


                        param[1] = new MySqlParameter("p_title", MySqlDbType.VarChar);
                        param[1].Value = obj_userapp_work_project_master1.title;


                        param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                        param[2].Value = obj_userapp_work_project_master1.user_id;

                        param[3] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                        param[3].Value = obj_userapp_work_project_master1.user_name;



                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserappWorkProjectMaster1", param);
                    }


                }


                if (obj_userapp_work_project_master1.color != null)
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    MySqlParameter[] param = new MySqlParameter[4];
                    {

                        param[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                        param[0].Value = obj_userapp_work_project_master1.id;

                        param[1] = new MySqlParameter("p_color", MySqlDbType.VarChar);
                        param[1].Value = obj_userapp_work_project_master1.color;

                        param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                        param[2].Value = obj_userapp_work_project_master1.user_id;

                        param[3] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                        param[3].Value = obj_userapp_work_project_master1.user_name;

                      
                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateWorkMaster1Color", param);
                    }


                }


                if (obj_userapp_work_project_master1.parentId != null)
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    MySqlParameter[] param = new MySqlParameter[4];
                    {

                        param[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                        param[0].Value = obj_userapp_work_project_master1.id;

                        param[1] = new MySqlParameter("p_parentId", MySqlDbType.VarChar);
                        param[1].Value = obj_userapp_work_project_master1.parentId;

                        param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                        param[2].Value = obj_userapp_work_project_master1.user_id;

                        param[3] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                        param[3].Value = obj_userapp_work_project_master1.user_name;


                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateWorkMaster1ParentId", param);
                    }


                }



                if (obj_userapp_work_project_master1.start != null)
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    MySqlParameter[] param = new MySqlParameter[4];
                    {

                        param[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                        param[0].Value = obj_userapp_work_project_master1.id;

                        param[1] = new MySqlParameter("p_start", MySqlDbType.VarChar);
                        param[1].Value = obj_userapp_work_project_master1.start;

                        param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                        param[2].Value = obj_userapp_work_project_master1.user_id;

                        param[3] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                        param[3].Value = obj_userapp_work_project_master1.user_name;


                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateWorkMaster1Start", param);
                    }


                }


                if (obj_userapp_work_project_master1.end != null)
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    MySqlParameter[] param = new MySqlParameter[4];
                    {

                        param[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                        param[0].Value = obj_userapp_work_project_master1.id;

                        param[1] = new MySqlParameter("p_end", MySqlDbType.VarChar);
                        param[1].Value = obj_userapp_work_project_master1.end;

                        param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                        param[2].Value = obj_userapp_work_project_master1.user_id;

                        param[3] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                        param[3].Value = obj_userapp_work_project_master1.user_name;


                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateWorkMaster1End   ", param);
                    }


                }

                if (obj_userapp_work_project_master1.progress != null)
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    MySqlParameter[] param = new MySqlParameter[4];
                    {

                        param[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                        param[0].Value = obj_userapp_work_project_master1.id;

                        param[1] = new MySqlParameter("p_progress", MySqlDbType.VarChar);
                        param[1].Value = obj_userapp_work_project_master1.progress;

                        param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                        param[2].Value = obj_userapp_work_project_master1.user_id;

                        param[3] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                        param[3].Value = obj_userapp_work_project_master1.user_name;


                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateWorkMaster1Progress", param);
                    }


                }


                if (obj_userapp_work_project_master1.end !=null)
                {
                    var Project_Id_wothout_special_charaters = obj_userapp_work_project_master1.id.Replace("-", "");

                    using MySqlConnection cons = new MySqlConnection(connection);

                    MySqlParameter[] dateobjparam = new MySqlParameter[4];
                    {

                        dateobjparam[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                        dateobjparam[0].Value = Project_Id_wothout_special_charaters;

                        dateobjparam[1] = new MySqlParameter("p_end", MySqlDbType.VarChar);
                        dateobjparam[1].Value = obj_userapp_work_project_master1.end;

                        dateobjparam[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                        dateobjparam[2].Value = obj_userapp_work_project_master1.user_id;

                        dateobjparam[3] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                        dateobjparam[3].Value = obj_userapp_work_project_master1.user_name;



                        ds = SqlHelpher.ExecuteDataset(cons, CommandType.StoredProcedure, "SP_InsertRevisionInEndDates", dateobjparam);
                    }


                }



                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                    {

                        response.Data = "";
                        response.Message = "Data Updated successfully  !!";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                        response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                    }


                  
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public DataTable GetAllUserappWorkProjectMaster1()
        {
            {
                Response response = new Response();
                DataTable ds = new DataTable();
                MySqlParameter[] param = new MySqlParameter[0];
                try
                {
                    using MySqlConnection con = new MySqlConnection(connection);
                    {


                        ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAllUserappWorkProjectMaster1", param);
                        return ds;
                    }

                }

                catch (Exception ex)
                {

                }
                return ds;
            }
        }

        public DataTable GetTasksByResourceId(string Resource_Id)
        {
            {
                // List<common_class_for_in_completed_projects> obj_common_class_for_in_completed_projects = new List<common_class_for_in_completed_projects>();
                common_class_resource_id_projects_tasks obj_common_class_resource_id_projects_tasks = new common_class_resource_id_projects_tasks();
                 Response response = new Response();
                DataTable ds = new DataTable();
                DataTable ds1 = new DataTable();
                DataTable ds2 = new DataTable();
                DataTable ds3 = new DataTable();
                MySqlParameter[] param = new MySqlParameter[1];
                try
                {
                    using MySqlConnection con = new MySqlConnection(connection);
                    {
                        param[0] = new MySqlParameter("p_Resource_Id", MySqlDbType.VarChar);
                        param[0].Value = Resource_Id;


                        ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetTasksByResourceId", param);
                    }

                    for (int i = 0; i<ds.Columns.Count; i++)
                    {
                       
                        MySqlParameter[] param1 = new MySqlParameter[1];
                        try
                        {
                            using MySqlConnection con1 = new MySqlConnection(connection);
                            {
                                param1[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                                param1[0].Value = ds.Rows[i]["taskId"].ToString();

                                //param2[1] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                                //param2[1].Value = "loop_sub_tasks";

                                ds1 = SqlHelpher.ExecuteDataTable(con1, CommandType.StoredProcedure, "SP_GetParentIdsfromProjectMaster1", param1);

                            }
                        }
                        catch (Exception EX)
                        {

                        }
                        
                        
                        for (int j = 0; j < ds1.Columns.Count; j++)
                        {

                            MySqlParameter[] param2 = new MySqlParameter[1];
                            try
                            {
                                using MySqlConnection con2 = new MySqlConnection(connection);
                                {
                                    param2[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                                    param2[0].Value = ds.Rows[i]["taskId"].ToString();

                                    //param2[1] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                                    //param2[1].Value = "loop_sub_tasks";

                                    ds2 = SqlHelpher.ExecuteDataTable(con2, CommandType.StoredProcedure, "SP_GetParentIdsfromProjectMaster1", param2);

                                }
                            }
                            catch (Exception EX)
                            {

                            }
                        }

                    }     
                   return ds2;       
                }
                catch (Exception ex)
                {

                }
                return ds;
            }
        }


        public DataTable GetResourceAssignmentWithOutId()
        {
            {
                Response response = new Response();
                DataTable ds = new DataTable();
                MySqlParameter[] param = new MySqlParameter[0];
                try
                {
                    using MySqlConnection con = new MySqlConnection(connection);
                    {


                        ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetResourceAssignmentWithOutId", param);
                        return ds;
                    }

                }

                catch (Exception ex)
                {

                }
                return ds;
            }
        }

        public Response DeleteUserappWorkProjectMaster1(string Id, string User_Name, Int64 User_Id, string Project_Name)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            MySqlParameter[] param1 = new MySqlParameter[1];
            try
            {
                var project_id_without_special_characters = Id.Replace("-", "");

                using MySqlConnection con1 = new MySqlConnection(connection);
                {

                    param1[0] = new MySqlParameter("p_project_Task_SubTask_Id", MySqlDbType.VarChar);
                    param1[0].Value = project_id_without_special_characters;

                    ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_DeleteCheckListTable", param1);
                }
            }
            catch (Exception ex)
            {

            }

            var DeleteCheckListTable_Result = ds1.Tables[0].Rows[0]["Message"].ToString();

            if(DeleteCheckListTable_Result == "200" || DeleteCheckListTable_Result == "201" )
            {
                MySqlParameter[] param = new MySqlParameter[4];
                try
                {

                    using MySqlConnection con = new MySqlConnection(connection);
                    {

                        param[0] = new MySqlParameter("p_Id", MySqlDbType.VarChar);
                        param[0].Value = Id;

                        param[1] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                        param[1].Value = User_Name;

                        param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                        param[2].Value = User_Id;

                        param[3] = new MySqlParameter("p_Project_Name", MySqlDbType.VarChar);
                        param[3].Value = Project_Name;

                        ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteUserappWorkProjectMaster1", param);
                    }

                    if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                    {

                        response.Data = "";
                        response.Message = "Delete Userapp Work Project Master1 Successfully!!";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                        response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                    }
                }
                catch (Exception ex)
                {

                }
            }

           
            return response;
        }


        //public Response AddUserProfile(user_profile obj_user_profile)
        //{
        //    Response response = new Response();
        //    DataSet ds = new DataSet();
        //    DataSet ds1 = new DataSet();

        //    MySqlParameter[] param = new MySqlParameter[0];
        //    try
        //    {
        //        using MySqlConnection con = new MySqlConnection(connection);
        //        {
        //            ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetUserProfileTaskId", param);
        //        }

        //        string GetTask_Id = ds.Tables[0].Rows[0]["Task_Id"].ToString();

        //        if (GetTask_Id != obj_user_profile.task_id)        
        //        {
        //            MySqlParameter[] param1 = new MySqlParameter[3];


        //            using MySqlConnection con1 = new MySqlConnection(connection);
        //            {
        //                param1[0] = new MySqlParameter("P_GetTask_Id", MySqlDbType.Int64);
        //                param1[0].Value = GetTask_Id;

        //                param1[1] = new MySqlParameter("p_task_id", MySqlDbType.VarChar);
        //                param1[1].Value = obj_user_profile.task_id;

        //                param1[2] = new MySqlParameter("p_photo_id", MySqlDbType.VarChar);
        //                param1[2].Value = obj_user_profile.photo_id;

        //                ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_AddUserProfile2", param1);

        //                if (Convert.ToString(ds1.Tables[0].Rows[0]["Message"]) == "200")
        //                {

        //                    response.Data = "";
        //                    response.Message = "Data Added successfully";
        //                    response.Status = true;
        //                }
        //                else
        //                {
        //                    response.Message = Convert.ToString(ds1.Tables[0].Rows[0]["Message"]);
        //                    response.Status = Convert.ToInt32(ds1.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
        //                }
        //            }
        //        }                     
        //        else if (GetTask_Id == obj_user_profile.task_id)
        //        {
        //            MySqlParameter[] param1 = new MySqlParameter[3];
        //            using MySqlConnection con1 = new MySqlConnection(connection);
        //            {
        //                param1[0] = new MySqlParameter("P_GetTask_Id", MySqlDbType.Int64);
        //                param1[0].Value = GetTask_Id;

        //                param1[1] = new MySqlParameter("p_task_id", MySqlDbType.VarChar);
        //                param1[1].Value = obj_user_profile.task_id;

        //                param1[2] = new MySqlParameter("p_photo_id", MySqlDbType.VarChar);
        //                param1[2].Value = obj_user_profile.photo_id;

        //                ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_UpdateUserProfile", param1);
        //            }
        //            if (Convert.ToString(ds1.Tables[0].Rows[0]["Message"]) == "200")
        //            {
        //                response.Data = "";
        //                response.Message = "Data Updated successfully";
        //                response.Status = true;
        //            }
        //            else
        //            {
        //                response.Message = Convert.ToString(ds1.Tables[0].Rows[0]["Message"]);
        //                response.Status = Convert.ToInt32(ds1.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
        //            }

        //        }


        //    }

        //    catch (Exception ex)
        //    {

        //    }
        //    return response;
        //}




        public Response AddUserAppChatMaster(userapp_chat_master obj_chat_Master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            //JObject json = JObject.Parse(getster_App_About_Demo.getster_app_time_stamp_description);
            try
            {
                MySqlParameter[] param = new MySqlParameter[13];
                {
                    //JObject json = JObject.Parse(getster_App_About_Demo.getster_app_time_stamp_description);
                    //getster_App_About_Demo.getster_app_time_stamp_description = json.ToString();

                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                    param[0].Value = obj_chat_Master.id;

                    param[1] = new MySqlParameter("p_group_chat_name", MySqlDbType.VarChar);
                    param[1].Value = obj_chat_Master.group_chat_name;

                    param[2] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int32);
                    param[2].Value = obj_chat_Master.created_by_user_id;

                    param[3] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                    param[3].Value = obj_chat_Master.created_timestamp;

                    param[4] = new MySqlParameter("p_auto_delete_old_messages_no_of_days", MySqlDbType.Int64);
                    param[4].Value = obj_chat_Master.auto_delete_old_messages_no_of_days;

                    param[5] = new MySqlParameter("P_about_the_chat", MySqlDbType.LongText);
                    param[5].Value = obj_chat_Master.about_the_chat;

                    param[6] = new MySqlParameter("p_pin_chat_to_the_top_of_chat_list", MySqlDbType.VarChar);
                    param[6].Value = obj_chat_Master.pin_chat_to_the_top_of_chat_list;

                    param[7] = new MySqlParameter("p_pin_message_timestamp", MySqlDbType.VarChar);
                    param[7].Value = obj_chat_Master.pin_message_timestamp;

                    param[8] = new MySqlParameter("p_user_profile", MySqlDbType.VarChar);
                    param[8].Value = obj_chat_Master.user_profile;

                    param[9] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[9].Value = "Insert";

                    param[10] = new MySqlParameter("p_chat_type", MySqlDbType.Int64);
                    param[10].Value = obj_chat_Master.chat_type;

                    param[11] = new MySqlParameter("p_auto_delete_old_messages", MySqlDbType.Bool);
                    param[11].Value = obj_chat_Master.auto_delete_old_messages;

                    param[12] = new MySqlParameter("p_businesses_associated_with_this_group", MySqlDbType.VarChar);
                    param[12].Value = obj_chat_Master.businesses_associated_with_this_group;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertUserAppChatMaster", param);
                }

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        // string GetMaxId = ds.Tables[0].Rows[0]["MaxId"].ToString();

                        MySqlParameter[] param1 = new MySqlParameter[5];
                        using MySqlConnection con1 = new MySqlConnection(connection);
                        {
                            param1[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                            param1[0].Value = obj_chat_Master.id;

                            param1[1] = new MySqlParameter("p_chat_type", MySqlDbType.Int64);
                            param1[1].Value = obj_chat_Master.chat_type;

                            param1[2] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int64);
                            param1[2].Value = obj_chat_Master.created_by_user_id;

                            param1[3] = new MySqlParameter("p_Message", MySqlDbType.LongText);
                            param1[3].Value = obj_chat_Master.Message;

                            param1[4] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                            param1[4].Value = obj_chat_Master.created_timestamp;


                            ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_CreateDynamicTablesBasedOnChatId", param1);
                        }

                        if (Convert.ToString(ds1.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "Insert  successfully";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds1.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds1.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }

















        public Response AddUserappUserPermissions(userapp_user_permissions obj_userapp_user_permissions)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[13];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = obj_userapp_user_permissions.user_id;



                    param[1] = new MySqlParameter("p_project_id", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_user_permissions.project_id;

                    param[2] = new MySqlParameter("p_parent_id", MySqlDbType.VarChar);
                    param[2].Value = obj_userapp_user_permissions.parent_id;

                    param[3] = new MySqlParameter("p_is_parent", MySqlDbType.Bool);
                    param[3].Value = obj_userapp_user_permissions.is_parent;

                    param[4] = new MySqlParameter("p_can_edit_project", MySqlDbType.Bool);
                    param[4].Value = obj_userapp_user_permissions.can_edit_project;

                    param[5] = new MySqlParameter("P_is_project_leader", MySqlDbType.Bool);
                    param[5].Value = obj_userapp_user_permissions.is_project_leader;

                    param[6] = new MySqlParameter("p_task_id", MySqlDbType.VarChar);
                    param[6].Value = obj_userapp_user_permissions.task_id;

                    param[7] = new MySqlParameter("p_can_edit_task", MySqlDbType.Bool);
                    param[7].Value = obj_userapp_user_permissions.can_edit_task;

                    param[8] = new MySqlParameter("p_is_task_leader", MySqlDbType.Bool);
                    param[8].Value = obj_userapp_user_permissions.is_task_leader;


                    param[9] = new MySqlParameter("p_sub_task_id", MySqlDbType.VarChar);
                    param[9].Value = obj_userapp_user_permissions.sub_task_id;

                    param[10] = new MySqlParameter("p_can_edit_sub_task", MySqlDbType.Bool);
                    param[10].Value = obj_userapp_user_permissions.can_edit_sub_task;

                    param[11] = new MySqlParameter("p_is_sub_task_leader", MySqlDbType.Bool);
                    param[11].Value = obj_userapp_user_permissions.is_sub_task_leader; //can_access_team_members_projects

                    param[12] = new MySqlParameter("p_can_access_team_members_projects", MySqlDbType.Bool);
                    param[12].Value = obj_userapp_user_permissions.can_access_team_members_projects; //


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AddUserappUserPermissions", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data Added successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }










        public Response AddResourceAssignment(resource_assignment obj_resource_assignment)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[6];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                    param[0].Value = obj_resource_assignment.id;

                    param[1] = new MySqlParameter("p_resourceId", MySqlDbType.VarChar);
                    param[1].Value = obj_resource_assignment.resourceId;

                    param[2] = new MySqlParameter("p_taskId", MySqlDbType.VarChar);
                    param[2].Value = obj_resource_assignment.taskId;

                    param[3] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                    param[3].Value = obj_resource_assignment.user_name;

                    param[4] = new MySqlParameter("p_project_name", MySqlDbType.VarChar);
                    param[4].Value = obj_resource_assignment.project_name;

                    param[5] = new MySqlParameter("p_is_project_leader", MySqlDbType.Bool);
                    param[5].Value = obj_resource_assignment.is_project_leader;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AddResourceAssignment", param);
                }
                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {
                    response.Data = "";
                    response.Message = "Data Added successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }




        public Response UpdateResourceAssignment(resource_assignment obj_resource_assignment)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[6];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                    param[0].Value = obj_resource_assignment.id;

                    param[1] = new MySqlParameter("p_resourceId", MySqlDbType.VarChar);
                    param[1].Value = obj_resource_assignment.resourceId;

                    param[2] = new MySqlParameter("p_taskId", MySqlDbType.VarChar);
                    param[2].Value = obj_resource_assignment.taskId;

                    param[3] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                    param[3].Value = obj_resource_assignment.user_name;

                    param[4] = new MySqlParameter("p_project_name", MySqlDbType.VarChar);
                    param[4].Value = obj_resource_assignment.project_name;

                    param[5] = new MySqlParameter("p_is_project_leader", MySqlDbType.Bool);
                    param[5].Value = obj_resource_assignment.is_project_leader;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateResourceAssignment", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data Added successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }

















        public Response DeleteResourceAssignmentById(string Resource_Id, string Task_Id, string Projct_Name, string User_Name)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            MySqlParameter[] param = new MySqlParameter[4];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_Resource_Id", MySqlDbType.VarChar);
                    param[0].Value = Resource_Id;

                    param[1] = new MySqlParameter("p_Task_Id", MySqlDbType.VarChar);
                    param[1].Value = Task_Id;

                    param[2] = new MySqlParameter("p_Projct_Name", MySqlDbType.Int64);
                    param[2].Value = Projct_Name;

                    param[3] = new MySqlParameter("p_User_Name", MySqlDbType.VarChar);
                    param[3].Value = User_Name;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteResourceAssignmentById", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Date Deletd Successfully!!";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }








        public Response AddDependency(dependency obj_dependency)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[7];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                    param[0].Value = obj_dependency.id;

                    param[1] = new MySqlParameter("p_predecessorId", MySqlDbType.VarChar);
                    param[1].Value = obj_dependency.predecessorId;

                    param[2] = new MySqlParameter("p_successorId", MySqlDbType.VarChar);
                    param[2].Value = obj_dependency.successorId;

                    param[3] = new MySqlParameter("p_project_name", MySqlDbType.VarChar);
                    param[3].Value = obj_dependency.project_name;

                    param[4] = new MySqlParameter("p_entry_by_user_id", MySqlDbType.VarChar);
                    param[4].Value = obj_dependency.entry_by_user_id;

                    param[5] = new MySqlParameter("p_entry_by_user_name", MySqlDbType.VarChar);
                    param[5].Value = obj_dependency.entry_by_user_name;

                    param[6] = new MySqlParameter("p_type", MySqlDbType.Int64);
                    param[6].Value = obj_dependency.type;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AddDependency", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data Added successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }


        public Response UpdateDependency(dependency obj_dependency)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[7];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                    param[0].Value = obj_dependency.id;

                    param[1] = new MySqlParameter("p_predecessorId", MySqlDbType.VarChar);
                    param[1].Value = obj_dependency.predecessorId;

                    param[2] = new MySqlParameter("p_successorId", MySqlDbType.VarChar);
                    param[2].Value = obj_dependency.successorId;

                    param[3] = new MySqlParameter("p_project_name", MySqlDbType.VarChar);
                    param[3].Value = obj_dependency.project_name;

                    param[4] = new MySqlParameter("p_entry_by_user_id", MySqlDbType.VarChar);
                    param[4].Value = obj_dependency.entry_by_user_id;

                    param[5] = new MySqlParameter("p_entry_by_user_name", MySqlDbType.VarChar);
                    param[5].Value = obj_dependency.entry_by_user_name;

                    param[6] = new MySqlParameter("p_type", MySqlDbType.Int64);
                    param[6].Value = obj_dependency.type;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateDependency", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data Updated successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }


        public Response DeleteDependency(string Id, string Project_Name, string Entry_By_User_Id, string Entry_By_User_Name)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            MySqlParameter[] param = new MySqlParameter[4];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_Id", MySqlDbType.VarChar);
                    param[0].Value = Id;

                    param[1] = new MySqlParameter("p_Project_Name", MySqlDbType.VarChar);
                    param[1].Value = Project_Name;

                    param[2] = new MySqlParameter("p_Entry_By_User_Id", MySqlDbType.VarChar);
                    param[2].Value = Entry_By_User_Id;

                    param[3] = new MySqlParameter("p_Entry_By_User_Name", MySqlDbType.VarChar);
                    param[3].Value = Entry_By_User_Name;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteDependency", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Date Deletd Successfully!!";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public Response AddUserappWorkProjectMaster1CheckList(userapp_work_project_master1_check_list obj_userapp_work_project_master1_check_list)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[9];
            try
            {

                var project_id_without_special_characters = obj_userapp_work_project_master1_check_list.id.Replace("-","");
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_check_list_s_no", MySqlDbType.VarChar);
                    param[0].Value = obj_userapp_work_project_master1_check_list.check_list_s_no;

                    param[1] = new MySqlParameter("p_id", MySqlDbType.VarChar); 
                    param[1].Value = project_id_without_special_characters;

                    
                    param[2] = new MySqlParameter("p_check_list_desc", MySqlDbType.LongText);
                    param[2].Value = obj_userapp_work_project_master1_check_list.check_list_desc;

                    param[3] = new MySqlParameter("p_check_list_completed_verified", MySqlDbType.Bool);
                    param[3].Value = obj_userapp_work_project_master1_check_list.check_list_completed_verified;

                    param[4] = new MySqlParameter("p_main_id", MySqlDbType.LongText);
                    param[4].Value = obj_userapp_work_project_master1_check_list.id;

                    param[5] = new MySqlParameter("p_project_name", MySqlDbType.VarChar);
                    param[5].Value = obj_userapp_work_project_master1_check_list.project_name;

                    param[6] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[6].Value = obj_userapp_work_project_master1_check_list.check_list_user_id;

                    param[7] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                    param[7].Value = obj_userapp_work_project_master1_check_list.check_list_user_name;

                    param[8] = new MySqlParameter("p_check_list_timestamp", MySqlDbType.VarChar);
                    param[8].Value = obj_userapp_work_project_master1_check_list.check_list_timestamp;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AddUserappWorkProjectMaster1CheckList", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data Added successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }




        public Response UpdateUserappWorkProjectMaster1CheckList(userapp_work_project_master1_check_list obj_userapp_work_project_master1_check_list)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[10];
            try
            {
                var project_id_without_special_characters = obj_userapp_work_project_master1_check_list.id.Replace("-", "");

                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_check_list_s_no", MySqlDbType.VarChar);
                    param[0].Value = obj_userapp_work_project_master1_check_list.check_list_s_no;

                    param[1] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                    param[1].Value = project_id_without_special_characters; 

                    param[2] = new MySqlParameter("p_check_list_desc", MySqlDbType.LongText);
                    param[2].Value = obj_userapp_work_project_master1_check_list.check_list_desc;

                    param[3] = new MySqlParameter("p_check_list_completed_verified", MySqlDbType.Bool);
                    param[3].Value = obj_userapp_work_project_master1_check_list.check_list_completed_verified;


                    param[4] = new MySqlParameter("p_main_id", MySqlDbType.LongText);
                    param[4].Value = obj_userapp_work_project_master1_check_list.id;

                    param[5] = new MySqlParameter("p_project_name", MySqlDbType.VarChar);
                    param[5].Value = obj_userapp_work_project_master1_check_list.project_name;

                    param[6] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[6].Value = obj_userapp_work_project_master1_check_list.check_list_user_id;

                    param[7] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                    param[7].Value = obj_userapp_work_project_master1_check_list.check_list_user_name;


                    param[8] = new MySqlParameter("p_check_list_user_id", MySqlDbType.VarChar);
                    param[8].Value = obj_userapp_work_project_master1_check_list.check_list_user_id;


                    param[9] = new MySqlParameter("p_check_list_user_name", MySqlDbType.VarChar);
                    param[9].Value = obj_userapp_work_project_master1_check_list.check_list_user_name;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserappWorkProjectMaster1CheckList", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data Updated successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }





        public DataTable GetALLUserappWorkProjectMaster1CheckList(string Id)
        {


            Response response = new Response();
            DataTable ds = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];
            try
            {
                var project_id_without_special_characters = Id.Replace("-", "");

                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_Id", MySqlDbType.VarChar);
                    param[0].Value = project_id_without_special_characters;


                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetALLUserappWorkProjectMaster1CheckList", param);
                    return ds;

                }

            }

            catch (Exception ex)
            {

            }
            return ds;


        }




        public Response ReArrangCheckList(rearang_check_list obj_rearang_check_list)
        {
               Response response = new Response();             
               DataTable ds = new DataTable();
               DataTable ds1 = new DataTable();

            foreach (var result in obj_rearang_check_list.Data)
            {
                MySqlParameter[] param1 = new MySqlParameter[1];
                try
                {
                    using MySqlConnection con1 = new MySqlConnection(connection);
                    {
                        param1[0] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                        param1[0].Value = result.id;

                        ds1 = SqlHelpher.ExecuteDataTable(con1, CommandType.StoredProcedure, "SP_TruncateCheckList", param1);
                    }
                }
                catch (Exception ex)
                {

                }
            }
            var Truncate_Message = ds1.Rows[0]["Message"].ToString();
            if (Truncate_Message == "200")
            {
                foreach (var result in obj_rearang_check_list.Data)
                {
                    MySqlParameter[] param = new MySqlParameter[7];
                    try
                    {
                        using MySqlConnection con = new MySqlConnection(connection);
                        {
                            param[0] = new MySqlParameter("p_check_list_s_no", MySqlDbType.VarChar);
                            param[0].Value = result.check_list_s_no;

                            param[1] = new MySqlParameter("p_check_list_desc", MySqlDbType.VarChar);
                            param[1].Value = result.check_list_desc;

                            param[2] = new MySqlParameter("p_check_list_completed_verified", MySqlDbType.VarChar);
                            param[2].Value = result.check_list_completed_verified;

                            param[3] = new MySqlParameter("p_id", MySqlDbType.VarChar);
                            param[3].Value = result.id;

                            param[4] = new MySqlParameter("p_user_id", MySqlDbType.VarChar);
                            param[4].Value = result.check_list_user_id;

                            param[5] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                            param[5].Value = result.check_list_user_name;

                            param[6] = new MySqlParameter("p_check_list_timestamp", MySqlDbType.VarChar);
                            param[6].Value = result.check_list_timestamp;

                            ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_ReArrangCheckList", param);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            if (Convert.ToString(ds.Rows[0]["Message"]) == "200")
            {

                response.Data = "";
                response.Message = "CheckList ReArrang successfully !!";
                response.Status = true;
            }
            else
            {
                response.Message = Convert.ToString(ds.Rows[0]["Message"]);
                response.Status = Convert.ToInt32(ds.Rows[0]["Status"]) != -1 ? true : false;
            }
            return response;
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
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[6];
            try
            {

                var project_id_without_special_characters = id.Replace("-", "");
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_Id", MySqlDbType.VarChar);
                    param[0].Value = project_id_without_special_characters;

                    param[1] = new MySqlParameter("p_Check_List_S_No", MySqlDbType.VarChar);
                    param[1].Value = check_list_s_no;

                    param[2] = new MySqlParameter("p_main_id", MySqlDbType.LongText);
                    param[2].Value = id;

                    param[3] = new MySqlParameter("p_project_name", MySqlDbType.VarChar);
                    param[3].Value = project_name;

                    param[4] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[4].Value = check_list_user_id;

                    param[5] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                    param[5].Value = check_list_user_name;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteUserappWorkProjectMaster1CheckList", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data Deleted successfully !!";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }


        public List<common_class_for_completed_projects> GetCompletedProjects()
        {
            List<completed_projects_list> obj_completed_projects_list = new List<completed_projects_list>();
            List<common_class_for_completed_projects> obj_common_class_for_completed_projects = new List<common_class_for_completed_projects>();

            Response response = new Response();
            DataTable ds = new DataTable();
            DataTable ds1 = new DataTable();
            DataTable ds2 = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_SelectCompletedProjectsBasedOnProgress", param);
                }
            }
            catch (Exception ex)
            {

            }
            foreach (DataRow row1 in ds.Rows)
            {
                var id = Convert.ToString(row1["id"].ToString());
                var parentId = Convert.ToString(row1["parentId"].ToString());
                var title = Convert.ToString(row1["title"].ToString());
                var start = Convert.ToString(row1["start"].ToString());
                var end = Convert.ToString(row1["end"].ToString());
                var progress = Convert.ToString(row1["progress"].ToString());
                var color = Convert.ToString(row1["color"].ToString());

                common_class_for_completed_projects _obj_completed_projects_list = new common_class_for_completed_projects();
                //    completed_projects_list _obj_completed_projects_list = new completed_projects_list();
                _obj_completed_projects_list.id = id;
                _obj_completed_projects_list.parentId = parentId;
                _obj_completed_projects_list.title = title;
                _obj_completed_projects_list.start = start;
                _obj_completed_projects_list.end = end;
                _obj_completed_projects_list.progress = progress;
                _obj_completed_projects_list.color = color;

                obj_common_class_for_completed_projects.Add(_obj_completed_projects_list);

                MySqlParameter[] param1 = new MySqlParameter[1];
                try
                {
                    using MySqlConnection con1 = new MySqlConnection(connection);
                    {
                        param1[0] = new MySqlParameter("p_loop_task_id", MySqlDbType.VarChar);
                        param1[0].Value = row1["id"].ToString();

                        ds1 = SqlHelpher.ExecuteDataTable(con1, CommandType.StoredProcedure, "SP_GetCompletedTasks", param1);

                        foreach (DataRow row in ds1.Rows)
                        {
                            var id1 = Convert.ToString(row["id"].ToString());
                            var parentId1 = Convert.ToString(row["parentId"].ToString());
                            var title1 = Convert.ToString(row["title"].ToString());
                            var start1 = Convert.ToString(row["start"].ToString());
                            var end1 = Convert.ToString(row["end"].ToString());
                            var progress1 = Convert.ToString(row["progress"].ToString());
                            var color1 = Convert.ToString(row["color"].ToString());

                            common_class_for_completed_projects _obj_completed_projects_list1 = new common_class_for_completed_projects();

                            _obj_completed_projects_list1.id = id1;
                            _obj_completed_projects_list1.parentId = parentId1;
                            _obj_completed_projects_list1.title = title1;
                            _obj_completed_projects_list1.start = start1;
                            _obj_completed_projects_list1.end = end1;
                            _obj_completed_projects_list1.progress = progress1;
                            _obj_completed_projects_list1.color = color1;

                            obj_common_class_for_completed_projects.Add(_obj_completed_projects_list1);

                            MySqlParameter[] param2 = new MySqlParameter[1];
                            try
                            {
                                using MySqlConnection con2 = new MySqlConnection(connection);
                                {
                                    param1[0] = new MySqlParameter("p_loop_subtask_id", MySqlDbType.VarChar);
                                    param1[0].Value = row["id"].ToString();

                                    ds2 = SqlHelpher.ExecuteDataTable(con2, CommandType.StoredProcedure, "SP_GetCompletedSubTasks", param1);

                                    foreach (DataRow row3 in ds2.Rows)
                                    {
                                        var id2 = Convert.ToString(row3["id"].ToString());
                                        var parentId2 = Convert.ToString(row3["parentId"].ToString());
                                        var title2 = Convert.ToString(row3["title"].ToString());
                                        var start2 = Convert.ToString(row3["start"].ToString());
                                        var end2 = Convert.ToString(row3["end"].ToString());
                                        var progress2 = Convert.ToString(row3["progress"].ToString());
                                        var color2 = Convert.ToString(row3["color"].ToString());

                                        common_class_for_completed_projects _obj_completed_projects_list2 = new common_class_for_completed_projects();

                                        _obj_completed_projects_list2.id = id2;
                                        _obj_completed_projects_list2.parentId = parentId2;
                                        _obj_completed_projects_list2.title = title2;
                                        _obj_completed_projects_list2.start = start2;
                                        _obj_completed_projects_list2.end = end2;
                                        _obj_completed_projects_list2.progress = progress2;
                                        _obj_completed_projects_list2.color = color2;

                                        obj_common_class_for_completed_projects.Add(_obj_completed_projects_list2);

                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }            
             }
          //  var completed_projects_list_data = Tuple.Create(ds, obj_common_class_for_completed_projects);
            return obj_common_class_for_completed_projects;
        }




        public List<common_class_for_in_completed_projects> GetInCompletedProjects()
        {
            List<common_class_for_in_completed_projects> obj_common_class_for_in_completed_projects = new List<common_class_for_in_completed_projects>();

            Response response = new Response();
            DataTable ds = new DataTable();
            DataTable ds1 = new DataTable();
            DataTable ds2 = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_SelectInCompletedProjectsBasedOnProgress", param);
                }
            }
            catch (Exception ex)
            {

            }
            foreach (DataRow row1 in ds.Rows)
            {
                var id = Convert.ToString(row1["id"].ToString());
                var parentId = Convert.ToString(row1["parentId"].ToString());
                var title = Convert.ToString(row1["title"].ToString());
                var start = Convert.ToString(row1["start"].ToString());
                var end = Convert.ToString(row1["end"].ToString());
                var progress = Convert.ToString(row1["progress"].ToString());
                var color = Convert.ToString(row1["color"].ToString());

                common_class_for_in_completed_projects _obj_common_class_for_in_completed_projects = new common_class_for_in_completed_projects();
                //    completed_projects_list _obj_completed_projects_list = new completed_projects_list();
                _obj_common_class_for_in_completed_projects.id = id;
                _obj_common_class_for_in_completed_projects.parentId = parentId;
                _obj_common_class_for_in_completed_projects.title = title;
                _obj_common_class_for_in_completed_projects.start = start;
                _obj_common_class_for_in_completed_projects.end = end;
                _obj_common_class_for_in_completed_projects.progress = progress;
                _obj_common_class_for_in_completed_projects.color = color;

                obj_common_class_for_in_completed_projects.Add(_obj_common_class_for_in_completed_projects);
            

                MySqlParameter[] param1 = new MySqlParameter[1];
                try
                {
                    using MySqlConnection con1 = new MySqlConnection(connection);
                    {
                        param1[0] = new MySqlParameter("p_loop_task_id", MySqlDbType.VarChar);
                        param1[0].Value = row1["id"].ToString();

                        ds1 = SqlHelpher.ExecuteDataTable(con1, CommandType.StoredProcedure, "SP_GetInCompletedTasks", param1);

                        foreach (DataRow row in ds1.Rows)
                        {
                            var id1 = Convert.ToString(row["id"].ToString());
                            var parentId1 = Convert.ToString(row["parentId"].ToString());
                            var title1 = Convert.ToString(row["title"].ToString());
                            var start1 = Convert.ToString(row["start"].ToString());
                            var end1 = Convert.ToString(row["end"].ToString());
                            var progress1 = Convert.ToString(row["progress"].ToString());
                            var color1 = Convert.ToString(row["color"].ToString());

                            common_class_for_in_completed_projects _obj_common_class_for_in_completed_projects1 = new common_class_for_in_completed_projects();

                            _obj_common_class_for_in_completed_projects1.id = id1;
                            _obj_common_class_for_in_completed_projects1.parentId = parentId1;
                            _obj_common_class_for_in_completed_projects1.title = title1;
                            _obj_common_class_for_in_completed_projects1.start = start1;
                            _obj_common_class_for_in_completed_projects1.end = end1;
                            _obj_common_class_for_in_completed_projects1.progress = progress1;
                            _obj_common_class_for_in_completed_projects1.color = color1;

                            obj_common_class_for_in_completed_projects.Add(_obj_common_class_for_in_completed_projects1);

                            MySqlParameter[] param2 = new MySqlParameter[1];
                            try
                            {
                                using MySqlConnection con2 = new MySqlConnection(connection);
                                {
                                    param1[0] = new MySqlParameter("p_loop_subtask_id", MySqlDbType.VarChar);
                                    param1[0].Value = row["id"].ToString();

                                    ds2 = SqlHelpher.ExecuteDataTable(con2, CommandType.StoredProcedure, "SP_GetInCompletedSubTasks", param1);

                                    foreach (DataRow row3 in ds2.Rows)
                                    {
                                        var id2 = Convert.ToString(row3["id"].ToString());
                                        var parentId2 = Convert.ToString(row3["parentId"].ToString());
                                        var title2 = Convert.ToString(row3["title"].ToString());
                                        var start2 = Convert.ToString(row3["start"].ToString());
                                        var end2 = Convert.ToString(row3["end"].ToString());
                                        var progress2 = Convert.ToString(row3["progress"].ToString());
                                        var color2 = Convert.ToString(row3["color"].ToString());

                                        common_class_for_in_completed_projects _obj_common_class_for_in_completed_projects2 = new common_class_for_in_completed_projects();

                                        _obj_common_class_for_in_completed_projects2.id = id2;
                                        _obj_common_class_for_in_completed_projects2.parentId = parentId2;
                                        _obj_common_class_for_in_completed_projects2.title = title2;
                                        _obj_common_class_for_in_completed_projects2.start = start2;
                                        _obj_common_class_for_in_completed_projects2.end = end2;
                                        _obj_common_class_for_in_completed_projects2.progress = progress2;
                                        _obj_common_class_for_in_completed_projects2.color = color2;

                                        obj_common_class_for_in_completed_projects.Add(_obj_common_class_for_in_completed_projects2);

                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            //  var completed_projects_list_data = Tuple.Create(ds, obj_common_class_for_completed_projects);
            return obj_common_class_for_in_completed_projects;
        }



        public DataTable GetALLRevisionInEndDates(string Id)
        {


            Response response = new Response();
            DataTable ds = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];
            try
            {
                var project_id_without_special_characters = Id.Replace("-", "");

                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_Id", MySqlDbType.VarChar);
                    param[0].Value = project_id_without_special_characters;


                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetALLRevisionInEndDates", param);
                    return ds;

                }

            }

            catch (Exception ex)
            {

            }
            return ds;


        }


        public Response UpdateUserappWorkProjectMaster1Notification(
             string Id,
             bool NotificationMuteUnmute,
             int UserId
            )
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
               // var project_id_without_special_characters = Id.Replace("-", "");

                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_id", MySqlDbType.VarChar); 
                    param[0].Value = Id;

                    param[1] = new MySqlParameter("p_notification_mute_unmute", MySqlDbType.Bool);
                    param[1].Value = NotificationMuteUnmute;

                    param[2] = new MySqlParameter("p_user_id", MySqlDbType.LongText);
                    param[2].Value = UserId;

           

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserappWorkProjectMaster1Notification", param);
                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Data Updated successfully";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }






        public DataTable GetALLUserAppWorkProjectMaster1Notification(string Id,int UserId)
        {


            Response response = new Response();
            DataTable ds = new DataTable();

            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                //var project_id_without_special_characters = Id.Replace("-", "");

                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_Id", MySqlDbType.VarChar);
                    param[0].Value = Id;

                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.Int32);
                    param[1].Value = UserId;

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetALLUserAppWorkProjectMaster1Notification", param);
                    return ds;

                }

            }

            catch (Exception ex)
            {

            }
            return ds;


        }

    }

}










