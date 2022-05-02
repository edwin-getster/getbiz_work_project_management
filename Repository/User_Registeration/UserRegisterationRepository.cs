using getbiz_work_project_management.Getbiz_DbContext;
using getbiz_work_project_management.Models;
using System;
using System.Linq;

namespace getbiz_work_project_management.Repository.User_Registeration
{
    public class UserRegisterationRepository : IUserRegisterationRepository
    {


        public readonly WorkProjectManagementAppDB_DbContext _DbContext;
        public UserRegisterationRepository(WorkProjectManagementAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserRegisteration(user_registeration obj_user_registeration)
        {
            Response response = new Response();
            try
            {
                user_registeration _obj_user_registeration = new user_registeration();

                _obj_user_registeration.text = obj_user_registeration.text;
                _obj_user_registeration.password = obj_user_registeration.password;
                _obj_user_registeration.photo_id = obj_user_registeration.photo_id;
                _obj_user_registeration.mobile_number = obj_user_registeration.mobile_number;
                _obj_user_registeration.user_type = obj_user_registeration.user_type;
                _obj_user_registeration.user_id = obj_user_registeration.user_id;

                _DbContext.Attach(_obj_user_registeration);
                _DbContext.Entry(_obj_user_registeration).Property(p => p.text).IsModified = true;
                _DbContext.Entry(_obj_user_registeration).Property(p => p.password).IsModified = true;
                _DbContext.Entry(_obj_user_registeration).Property(p => p.photo_id).IsModified = true;
                _DbContext.Entry(_obj_user_registeration).Property(p => p.mobile_number).IsModified = true;
                _DbContext.Entry(_obj_user_registeration).Property(p => p.user_type).IsModified = true;
                _DbContext.Entry(_obj_user_registeration).Property(p => p.user_id).IsModified = true;
                _DbContext.SaveChanges();

                response.Message = "Data Added successfully !!";
                response.Status = true;
            }
            catch (Exception)
            {
                response.Message = "Data Added failed !!";
                response.Status = false;
            }
            return response;
        }




        public Response GetUserRegisteration()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.user_registeration
                                 select new
                                 {
                                     ID = master.id,
                                     Text = master.text,
                                     Photo_id = master.photo_id,
                                 }).ToList();
                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }














    }
}
