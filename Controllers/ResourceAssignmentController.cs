using getbiz_work_project_management.Models;
using getbiz_work_project_management.Repository.Resource_Assignment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_work_project_management.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceAssignmentController : ControllerBase
    {
        public readonly IResourceAssignmentReposiotry _resourceAssignmentReposiotry;
        public ResourceAssignmentController(IResourceAssignmentReposiotry resourceAssignmentReposiotry)
        {
            _resourceAssignmentReposiotry = resourceAssignmentReposiotry;
        }



        [HttpPost]
        [Route("api/AddResourceAssignment")]
        public IActionResult AddResourceAssignment(resource_assignment obj_resource_assignment)
        {
            try
            {
                var messages = _resourceAssignmentReposiotry.AddResourceAssignment(obj_resource_assignment);
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
        [Route("api/UpdateResourceAssignment")]
        public IActionResult UpdateResourceAssignment(resource_assignment obj_resource_assignment)
        {
            try
            {
                var messages = _resourceAssignmentReposiotry.UpdateResourceAssignment(obj_resource_assignment);
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
        [Route("api/GetTasksByResourceId")]
        public IActionResult GetTasksByResourceId(string Resource_Id)
        {
            try
            {
                var messages = _resourceAssignmentReposiotry.GetTasksByResourceId(Resource_Id);
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
        [Route("api/GetResourceAssignmentWithOutId")]
        public IActionResult GetResourceAssignmentWithOutId()
        {
            try
            {
                var messages = _resourceAssignmentReposiotry.GetResourceAssignmentWithOutId();
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
        [Route("api/DeleteResourceAssignmentById")]
        public IActionResult DeleteResourceAssignmentById(string Resource_Id, string Task_Id, string Projct_Name, string User_Name)
        {
            try
            {
                var messages = _resourceAssignmentReposiotry.DeleteResourceAssignmentById( Resource_Id,  Task_Id,  Projct_Name,  User_Name);
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
