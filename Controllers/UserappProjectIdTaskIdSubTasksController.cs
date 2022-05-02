using getbiz_work_project_management.Models;
using getbiz_work_project_management.Repository.Userapp_Project_Id_Task_Id_Sub_Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_work_project_management.Controllers
{
   // [Authorize]
   // [Route("api/[controller]")]
    [ApiController]
    public class UserappProjectIdTaskIdSubTasksController : ControllerBase
    {


        public readonly IUserappProjectIdTaskIdSubTasksRepository _userappProjectIdTaskIdSubTasksRepository;
        public UserappProjectIdTaskIdSubTasksController(IUserappProjectIdTaskIdSubTasksRepository userappProjectIdTaskIdSubTasksRepository)
        {
            _userappProjectIdTaskIdSubTasksRepository = userappProjectIdTaskIdSubTasksRepository;
        }


        [HttpPost]
        [Route("api/AddUserappProjectIdTaskIdSubTasks")]
        public IActionResult AddUserappProjectIdTaskIdSubTasks(userapp_project_id_task_id_sub_tasks obj_userapp_project_id_task_id_sub_tasks)
        {
            try
            {
                var messages = _userappProjectIdTaskIdSubTasksRepository.AddUserappProjectIdTaskIdSubTasks(obj_userapp_project_id_task_id_sub_tasks);
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
        [Route("api/UpdateUserappProjectIdTaskIdSubTasks")]
        public IActionResult UpdateUserappProjectIdTaskIdSubTasks(userapp_project_id_task_id_sub_tasks obj_userapp_project_id_task_id_sub_tasks)
        {
            try
            {
                var messages = _userappProjectIdTaskIdSubTasksRepository.UpdateUserappProjectIdTaskIdSubTasks(obj_userapp_project_id_task_id_sub_tasks);
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
        [Route("api/DeleteUserappProjectIdTaskIdSubTasks")]
        public IActionResult DeleteUserappProjectIdTaskIdSubTasks(Int64 Project_Id, Int64 Task_Id, Int64 Sub_Task_Id)
        {
            try
            {
                var messages = _userappProjectIdTaskIdSubTasksRepository.DeleteUserappProjectIdTaskIdSubTasks(Project_Id, Task_Id, Sub_Task_Id);
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
        [Route("api/GetUserappProjectIdTaskIdSubTasks")]
        public IActionResult GetUserappProjectIdTaskIdSubTasks(Int64 Project_Id, Int64 Task_Id, Int64 Sub_Task_Id)
        {
            try
            {
                var messages = _userappProjectIdTaskIdSubTasksRepository.GetUserappProjectIdTaskIdSubTasks(Project_Id, Task_Id, Sub_Task_Id);
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
