using getbiz_work_project_management.Models;
using getbiz_work_project_management.Repository.User_Registeration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_work_project_management.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisterationController : ControllerBase
    {


        public readonly IUserRegisterationRepository _userRegisterationRepository;
        public UserRegisterationController(IUserRegisterationRepository userRegisterationRepository)
        {
            _userRegisterationRepository = userRegisterationRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddUserRegisteration")]
        public IActionResult AddUserRegisteration(user_registeration obj_user_registeration)
        {
            try
            {
                var messages = _userRegisterationRepository.AddUserRegisteration(obj_user_registeration);
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
        [Route("api/GetUserRegisteration")]
        public IActionResult GetUserRegisteration()
        {
            try
            {
                var messages = _userRegisterationRepository.GetUserRegisteration();
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
