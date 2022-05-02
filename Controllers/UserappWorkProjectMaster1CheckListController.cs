using getbiz_work_project_management.Models;
using getbiz_work_project_management.Repository.Userapp_Work_Project_Master1_Check_List;
using getbiz_work_project_management.V_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Controllers
{
   // [Authorize]
    //[Route("api/[controller]")]
    [ApiController]
    public class UserappWorkProjectMaster1CheckListController : ControllerBase
    {


        private IUserappWorkProjectMaster1CheckListRepository _userappWorkProjectMaster1CheckListRepository;
        public UserappWorkProjectMaster1CheckListController(IUserappWorkProjectMaster1CheckListRepository userappWorkProjectMaster1CheckListRepository)
        {
            _userappWorkProjectMaster1CheckListRepository = userappWorkProjectMaster1CheckListRepository;
        }


        [HttpPost]
        [Route("api/AddUserappWorkProjectMaster1CheckList")]
        public IActionResult AddUserappWorkProjectMaster1CheckList(userapp_work_project_master1_check_list obj_userapp_work_project_master1_check_list)
        {
            try
            {
                var messages = _userappWorkProjectMaster1CheckListRepository.AddUserappWorkProjectMaster1CheckList(obj_userapp_work_project_master1_check_list);
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
        [Route("api/UpdateUserappWorkProjectMaster1CheckList")]
        public IActionResult UpdateUserappWorkProjectMaster1CheckList(userapp_work_project_master1_check_list obj_userapp_work_project_master1_check_list)
        {
            try
            {
                var messages = _userappWorkProjectMaster1CheckListRepository.UpdateUserappWorkProjectMaster1CheckList(obj_userapp_work_project_master1_check_list);
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
        [Route("api/GetALLUserappWorkProjectMaster1CheckList")]
        public IActionResult GetALLUserappWorkProjectMaster1CheckList(string Id)
        {
            try
            {
                var messages = _userappWorkProjectMaster1CheckListRepository.GetALLUserappWorkProjectMaster1CheckList(Id);
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
        [Route("api/DeleteUserappWorkProjectMaster1CheckList")]
        public IActionResult DeleteUserappWorkProjectMaster1CheckList(
            string check_list_s_no,
            string id,
            string project_name,
            int check_list_user_id,
            string check_list_user_name)
        {
            try
            {
                var messages = _userappWorkProjectMaster1CheckListRepository.DeleteUserappWorkProjectMaster1CheckList(
                 check_list_s_no,
                 id,
                 project_name,
                 check_list_user_id,
                 check_list_user_name);
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





        [HttpPost]
        [Route("api/ReArrangCheckList")]
        public IActionResult ReArrangCheckList(rearang_check_list obj_rearang_check_list)
        {
            try
            {
                var messages = _userappWorkProjectMaster1CheckListRepository.ReArrangCheckList(obj_rearang_check_list);
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
