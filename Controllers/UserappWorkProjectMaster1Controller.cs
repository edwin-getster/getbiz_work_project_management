using getbiz_work_project_management.Getbiz_DbContext;
using getbiz_work_project_management.Models;
using getbiz_work_project_management.Repository.Userapp_Work_Project_Master1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_work_project_management.Controllers
{
   // [Authorize]
   // [Route("api/[controller]")]
    [ApiController]
    public class UserappWorkProjectMaster1Controller : ControllerBase
    {
        public readonly IUserappWorkProjectMaster1Repository _userappWorkProjectMaster1Repository;
        public UserappWorkProjectMaster1Controller(IUserappWorkProjectMaster1Repository userappWorkProjectMaster1Repository)
        {
            _userappWorkProjectMaster1Repository = userappWorkProjectMaster1Repository;
        }

        [HttpPost]
        [Route("api/AddUserappWorkProjectMaster1")]
        public IActionResult AddUserappWorkProjectMaster1(userapp_work_project_master1 obj_userapp_work_project_master1)
        {
            try
            {
                var messages = _userappWorkProjectMaster1Repository.AddUserappWorkProjectMaster1(obj_userapp_work_project_master1);
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


        [HttpPut]
        [Route("api/UpdateUserappWorkProjectMaster1")]
        public IActionResult UpdateUserappWorkProjectMaster1(userapp_work_project_master1 obj_userapp_work_project_master1)
        {
            try
            {
                var messages = _userappWorkProjectMaster1Repository.UpdateUserappWorkProjectMaster1(obj_userapp_work_project_master1);
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
        [Route("api/GetAllUserappWorkProjectMaster1")]
        public IActionResult GetAllUserappWorkProjectMaster1()
        {
            try
            {
                var messages = _userappWorkProjectMaster1Repository.GetAllUserappWorkProjectMaster1();
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
        [Route("api/DeleteUserappWorkProjectMaster1")]
        public IActionResult DeleteUserappWorkProjectMaster1(string Id, string User_Name,Int64 User_Id, string Project_Name)
        {
            try
            {
                var messages = _userappWorkProjectMaster1Repository.DeleteUserappWorkProjectMaster1(Id, User_Name, User_Id, Project_Name);
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
        [Route("api/GetCompletedProjects")]
        public IActionResult GetCompletedProjects()
        {
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();   
                var messages = Obj_getsetdb.GetCompletedProjects();
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
        [Route("api/GetInCompletedProjects")]
        public IActionResult GetInCompletedProjects()
        {
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var messages = Obj_getsetdb.GetInCompletedProjects();
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
        [Route("api/GetALLRevisionInEndDates")]
        public IActionResult GetALLRevisionInEndDates(string Id)
        {
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var messages = Obj_getsetdb.GetALLRevisionInEndDates(Id);
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
