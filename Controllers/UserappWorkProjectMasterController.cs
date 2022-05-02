
using getbiz_work_project_management.Models;
using getbiz_work_project_management.Repository.Userapp_Work_Project_Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_work_project_management.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserappWorkProjectMasterController : ControllerBase
    {
        public readonly IUserappWorkProjectMasterRepository _userappWorkProjectMasterRepository;
        public UserappWorkProjectMasterController(IUserappWorkProjectMasterRepository userappWorkProjectMasterRepository)
        {
            _userappWorkProjectMasterRepository = userappWorkProjectMasterRepository;
        }


        [HttpPost]
        [Route("api/AddUserappWorkProjectMaster")]
        public IActionResult AddUserappWorkProjectMaster(userapp_work_project_master obj_userapp_work_project_master)
        {
            try
            {
                var messages = _userappWorkProjectMasterRepository.AddUserappWorkProjectMaster(obj_userapp_work_project_master);
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




        [HttpPatch]
        [Route("api/UpdateUserappWorkProjectMaster")]
        public IActionResult UpdateUserappWorkProjectMaster(userapp_work_project_master obj_userapp_work_project_master)
        {
            try
            {
                var messages = _userappWorkProjectMasterRepository.UpdateUserappWorkProjectMaster(obj_userapp_work_project_master);
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
        [Route("api/DeleteUserappWorkProjectMaster")]
        public IActionResult DeleteUserappWorkProjectMaster(Int64 Project_Id)
        {
            try
            {
                var messages = _userappWorkProjectMasterRepository.DeleteUserappWorkProjectMaster(Project_Id);
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
        [Route("api/GetUserappWorkProjectMaster")]
        public IActionResult GetUserappWorkProjectMaster(Int64 Project_Id)
        {
            try
            {
                var messages = _userappWorkProjectMasterRepository.GetUserappWorkProjectMaster(Project_Id);
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




    }




}
