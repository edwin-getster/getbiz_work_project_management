using getbiz_work_project_management.Models;
using System;

namespace getbiz_work_project_management.Repository.Userapp_Audit_Trail
{
    public interface IUserappAuditTrailRepository
    {

        Response GetUserappAuditTrail( string p_Task_Id);
    }
}
