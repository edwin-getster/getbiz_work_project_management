using getbiz_work_project_management.Models;
using getbiz_work_project_management.Repository.Dependency;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_work_project_management.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DependencyController : ControllerBase
    {

        private IDependencyRepository _dependencyRepository;
        public DependencyController(IDependencyRepository dependencyRepository)
        {
            _dependencyRepository = dependencyRepository;
        }


        [HttpPost]
        [Route("api/AddDependency")]
        public IActionResult AddDependency(dependency obj_dependency)
        {
            try
            {
                var messages = _dependencyRepository.AddDependency(obj_dependency);
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
        [Route("api/UpdateDependency")]
        public IActionResult UpdateDependency(dependency obj_dependency)
        {
            try
            {
                var messages = _dependencyRepository.UpdateDependency(obj_dependency);
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
        [Route("api/GetDependency")]
        public IActionResult GetDependency( )
        {
            try
            {
                var messages = _dependencyRepository.GetDependency();
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
        [Route("api/DeleteDependency")]
        public IActionResult DeleteDependency(string Id, string Project_Name, string Entry_By_User_Id, string Entry_By_User_Name)
        {
            try
            {
                var messages = _dependencyRepository.DeleteDependency( Id,  Project_Name,  Entry_By_User_Id,  Entry_By_User_Name);
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
