using getbiz_work_project_management.Models;
using Microsoft.EntityFrameworkCore;

namespace getbiz_work_project_management.Getbiz_DbContext
{
    public class WorkProjectManagementAppDB_DbContext : DbContext
    {



        public WorkProjectManagementAppDB_DbContext(DbContextOptions<WorkProjectManagementAppDB_DbContext> dbContext) : base(dbContext)
        {

        }


        public DbSet<userapp_work_project_master> userapp_work_project_master { get; set; }
        public DbSet<userapp_user_permissions> userapp_user_permissions { get; set; }
        public DbSet<userapp_audit_trail> userapp_audit_trail { get; set; }
        public DbSet<user_registeration> user_registeration { get; set; }
        public DbSet<userapp_work_project_master1> userapp_work_project_master1 { get; set; }
        public DbSet<resource_assignment> resource_assignment { get; set; }
        public DbSet<user_profile> user_profile { get; set; }
        public DbSet<dependency> dependency { get; set; }
    }
}
