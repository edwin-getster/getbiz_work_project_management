using getbiz_work_project_management.Models;
using getbiz_work_project_management.Repository.Userapp_User_Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_work_project_management.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserappUserPermissionsController : ControllerBase
    {



        public readonly IUserappUserPermissionsRepository _userappUserPermissionsRepository;
        public UserappUserPermissionsController(IUserappUserPermissionsRepository userappUserPermissionsRepository)
        {
            _userappUserPermissionsRepository = userappUserPermissionsRepository;
        }


        [HttpPost]
        [Route("api/AddUserappUserPermissions")]
        public IActionResult AddUserappUserPermissions(userapp_user_permissions obj_userapp_user_permissions)
        {
            try
            {
                var messages = _userappUserPermissionsRepository.AddUserappUserPermissions(obj_userapp_user_permissions);
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
        [Route("api/GetUserappUserPermissions")]
        public IActionResult GetUserappUserPermissions(bool Is_Parent, string Parent_Id)
        {
            try
            {
                var messages = _userappUserPermissionsRepository.GetUserappUserPermissions(Is_Parent, Parent_Id);
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



















        //[HttpPatch]
        //[Route("api/UpdateUserappUserPermissions")]
        //public IActionResult UpdateUserappUserPermissions(userapp_user_permissions obj_userapp_user_permissions)
        //{
        //    try
        //    {
        //        var messages = _userappUserPermissionsRepository.UpdateUserappUserPermissions(obj_userapp_user_permissions);
        //        if (messages == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(messages);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}






    }
}
