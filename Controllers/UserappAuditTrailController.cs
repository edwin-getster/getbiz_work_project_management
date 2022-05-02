using getbiz_work_project_management.Repository.Userapp_Audit_Trail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_work_project_management.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserappAuditTrailController : ControllerBase
    {
        public readonly IUserappAuditTrailRepository _userappAuditTrailRepository;
        public UserappAuditTrailController(IUserappAuditTrailRepository userappAuditTrailRepository)
        {
            _userappAuditTrailRepository = userappAuditTrailRepository;
        }



        [HttpGet]
        [Route("api/GetUserappAuditTrail")]
        public IActionResult GetUserappAuditTrail(string Task_Id)
        {
            try
            {
                var messages = _userappAuditTrailRepository.GetUserappAuditTrail( Task_Id);
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
