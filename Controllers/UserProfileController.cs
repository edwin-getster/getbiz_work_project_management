using getbiz_work_project_management.Getbiz_DbContext;
using getbiz_work_project_management.Models;
using getbiz_work_project_management.Repository.User_Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Controllers
{
    //[Authorize]
    //[Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        public readonly WorkProjectManagementAppDB_DbContext _DbContext;

        private IUserProfileRepository _userProfileRepository;
        public UserProfileController(IUserProfileRepository userProfileRepository, WorkProjectManagementAppDB_DbContext DbContext)
        {
            _userProfileRepository = userProfileRepository;

            _DbContext = DbContext;
        }

        [HttpPost]
        [Route("api/AddUserProfile")]
        public IActionResult AddUserProfile(user_profile obj_user_profile)
        {
            try
            {
                var messages = _userProfileRepository.AddUserProfile(obj_user_profile);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



        [HttpGet]
        [Route("api/GetUserProfile")]
        public IActionResult GetUserProfile(string Task_Id)
        {
            try
            {
                var messages = _userProfileRepository.GetUserProfile(Task_Id);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpDelete]
        [Route("api/DeleteUserProfileById")]
        public IActionResult DeleteUserProfile(string Task_Id)
        {
            try
            {
                var messages = _userProfileRepository.DeleteUserProfile(Task_Id);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }




        [HttpDelete]
        [Route("api/DeleteUserProfile")]    
        public async Task<IActionResult> DeleteALLgps()
        {
            try
            {
                var result = _DbContext.user_profile.ToList();
                _DbContext.RemoveRange(result);
                await _DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return new JsonResult("Data Successfully Deleted");
        }
    }
}
