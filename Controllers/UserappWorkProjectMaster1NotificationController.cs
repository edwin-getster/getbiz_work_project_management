using getbiz_work_project_management.Repository.Userapp_Work_Project_Master1_Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserappWorkProjectMaster1NotificationController : ControllerBase
    {


        public readonly IUserappWorkProjectMaster1NotificationRepository _userappWorkProjectMaster1NotificationRepository;
        public UserappWorkProjectMaster1NotificationController(IUserappWorkProjectMaster1NotificationRepository userappWorkProjectMaster1NotificationRepository)
        {
            _userappWorkProjectMaster1NotificationRepository = userappWorkProjectMaster1NotificationRepository;
        }



        [HttpPut]
        [Route("api/UpdateUserappWorkProjectMaster1Notification")]
        public IActionResult UpdateUserappWorkProjectMaster1Notification(
             string Id,
             bool NotificationMuteUnmute,
             int UserId
            )
        {
            try
            {
                var messages = _userappWorkProjectMaster1NotificationRepository.UpdateUserappWorkProjectMaster1Notification(Id, NotificationMuteUnmute, UserId);
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
        [Route("api/GetALLUserAppWorkProjectMaster1Notification")]
        public IActionResult GetALLUserAppWorkProjectMaster1Notification(string Id, int UserId)
        {
            try
            {
                var messages = _userappWorkProjectMaster1NotificationRepository.GetALLUserAppWorkProjectMaster1Notification(Id,UserId);
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
