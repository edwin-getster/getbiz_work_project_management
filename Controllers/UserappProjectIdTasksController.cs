using getbiz_work_project_management.Models;
using getbiz_work_project_management.Repository.Userapp_Project_Id_Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_work_project_management.Controllers
{
   // [Authorize]
   // [Route("api/[controller]")]
    [ApiController]
    public class UserappProjectIdTasksController : ControllerBase
    {



        public readonly IUserappProjectIdTasksRepository _userappProjectIdTasksRepository;
        public UserappProjectIdTasksController(IUserappProjectIdTasksRepository userappProjectIdTasksRepository)
        {
            _userappProjectIdTasksRepository = userappProjectIdTasksRepository;
        }


        [HttpPost]
        [Route("api/AddUserappProjectIdTasks")]
        public IActionResult AddUserappProjectIdTasks(userapp_project_id_tasks obj_userapp_project_id_tasks)
        {
            try
            {
                var messages = _userappProjectIdTasksRepository.AddUserappProjectIdTasks(obj_userapp_project_id_tasks);
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
        [Route("api/UpdateUserappProjectIdTasks")]
        public IActionResult UpdateUserappProjectIdTasks(userapp_project_id_tasks obj_userapp_project_id_tasks)
        {
            try
            {
                var messages = _userappProjectIdTasksRepository.UpdateUserappProjectIdTasks(obj_userapp_project_id_tasks);
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
        [Route("api/DeleteUserappProjectIdTasks")]
        public IActionResult DeleteUserappProjectIdTasks(Int64 Project_Id, Int64 Task_Id)
        {
            try
            {
                var messages = _userappProjectIdTasksRepository.DeleteUserappProjectIdTasks(Project_Id, Task_Id);
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
        [Route("api/GetUserappProjectIdTasks")]
        public IActionResult GetUserappProjectIdTasks(Int64 Project_Id, Int64 Task_Id)
        {
            try
            {
                var messages = _userappProjectIdTasksRepository.GetUserappProjectIdTasks(Project_Id, Task_Id);
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
