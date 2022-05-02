﻿
using getbiz_work_project_management.Models;
using getbiz_work_project_management.Repository.Userapp_Chat_Master;
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
    [ApiController]
    public class UserAppChatMasterController : ControllerBase
    {
        private IUserAppChatMasterRepository _chatMasterRepository;

        public UserAppChatMasterController(IUserAppChatMasterRepository chatMasterRepository)
        {
            _chatMasterRepository = chatMasterRepository;
        }


       
        [HttpPost]
        [Route("api/AddUserAppChatMaster")]
        public IActionResult AddUserAppChatMaster(userapp_chat_master obj_chat_master)
        {
            try
            {
                //obj_chat_master.Message = Message;
                var messages = _chatMasterRepository.AddUserAppChatMaster(obj_chat_master);
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


        //[HttpPut]
        //[Route("api/UpdateUserAppChatMaster")]
        //public IActionResult UpdateChatMaster(userapp_chat_master obj_chat_master)
        //{
        //    try
        //    {
        //        var messages = _chatMasterRepository.UpdateUserAppChatMaster(obj_chat_master);
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

//        [HttpDelete]
//        [Route("api/DeleteUserAppChatMasterById")]
//        public IActionResult DeleteChatMasterById(string CustId, Int64 ChatId)
//        {
//            try
//            {
//                var messages = _chatMasterRepository.DeleteUserAppChatMasterById(CustId, ChatId);
//                if (messages == null)
//                {
//                    return NotFound();
//                }

//                return Ok(messages);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest();
//            }
//        }

//        [HttpGet]
//        [Route("api/GetUserAppChatMasterById")]
//        public IActionResult GetChatMasterById(string CustId, Int64 ChatId,Int64 UserId)               
//        {
//            try
//            {
//                var messages = _chatMasterRepository.GetUserAppChatMasterById(CustId, ChatId, UserId);
//                if (messages == null)
//                {
//                    return NotFound();
//                }

//                return Ok(messages);
//            }

//            catch (Exception ex)
//            {
//                return BadRequest();
//            }
//        }

//        [HttpGet]
//        [Route("api/GetAllUserAppChatMaster")]
//        public IActionResult GetAllChatMaster(string CustId, Int64 UserId)
//        {
//            try
//            {
//                var messages = _chatMasterRepository.GetAllUserAppChatMaster(CustId, UserId);
//                if (messages == null)
//                {
//                    return NotFound();
//                }

//                return Ok(messages);
//            }

//            catch (Exception ex)
//            {
//                return BadRequest();
//            }

//        }



      
//        [HttpPut]
//        [Route("api/UpdateColumnUserAppChatMaster")]
//        public IActionResult UpdateColumnUserAppChatMaster(userapp_chat_master obj_chat_master)
//        {
//            try
//            {
//                var messages = _chatMasterRepository.UpdateColumnUserAppChatMaster(obj_chat_master);
//                if (messages == null)
//                {
//                    return NotFound();
//                }

//                return Ok(messages);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest();
//            }
//        }
        
   }   
}
