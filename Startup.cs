using getbiz_work_project_management.Getbiz_DbContext;
using getbiz_work_project_management.Repository.Dependency;
using getbiz_work_project_management.Repository.Resource_Assignment;
using getbiz_work_project_management.Repository.User_Profile;
using getbiz_work_project_management.Repository.User_Registeration;
using getbiz_work_project_management.Repository.Userapp_Audit_Trail;
using getbiz_work_project_management.Repository.Userapp_Chat_Master;
using getbiz_work_project_management.Repository.Userapp_Project_Id_Task_Id_Sub_Tasks;
using getbiz_work_project_management.Repository.Userapp_Project_Id_Tasks;
using getbiz_work_project_management.Repository.Userapp_User_Permissions;
using getbiz_work_project_management.Repository.Userapp_Work_Project_Master;
using getbiz_work_project_management.Repository.Userapp_Work_Project_Master1;
using getbiz_work_project_management.Repository.Userapp_Work_Project_Master1_Check_List;
using getbiz_work_project_management.Repository.Userapp_Work_Project_Master1_Notification;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace getbiz_work_project_management
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<WorkProjectManagementAppDB_DbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));




            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "getbiz_work_project_management", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                          Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          }
                        },
                        new string[]{}
                    }
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = Configuration["Jwt:Issuer"],
                      ValidAudience = Configuration["Jwt:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))

                  };
              });

            services.AddMvc();
            services.AddScoped<IUserappWorkProjectMasterRepository, UserappWorkProjectMasterRepository>();
            services.AddScoped<IUserappProjectIdTasksRepository, UserappProjectIdTasksRepository>();
            services.AddScoped<IUserappProjectIdTaskIdSubTasksRepository, UserappProjectIdTaskIdSubTasksRepository>();
            services.AddScoped<IUserappUserPermissionsRepository, UserappUserPermissionsRepository>();
            services.AddScoped<IUserRegisterationRepository, UserRegisterationRepository>();
            services.AddScoped<IUserappAuditTrailRepository, UserappAuditTrailRepository>();
            services.AddScoped<IUserappWorkProjectMaster1Repository, UserappWorkProjectMaster1Repository>();
            services.AddScoped<IResourceAssignmentReposiotry, ResourceAssignmentRepository>();
            //services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IDependencyRepository, DependencyRepository>();
            services.AddScoped<IUserAppChatMasterRepository, UserAppChatMasterRepository>();
            services.AddScoped<IUserappWorkProjectMaster1CheckListRepository, UserappWorkProjectMaster1CheckListRepository>();
            services.AddScoped<IUserappWorkProjectMaster1NotificationRepository, UserappWorkProjectMaster1NotificationRepository>();
          


            services.AddCors(option => option.AddPolicy("getbiz_work_project_management", builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));



        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "getbiz_work_project_management v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true)
              .AllowCredentials());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
