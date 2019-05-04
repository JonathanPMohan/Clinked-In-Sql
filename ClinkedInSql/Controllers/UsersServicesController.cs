using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClinkedInSql.Data;
using ClinkedInSql.Models;
using ClinkedInSql.Validators;

namespace ClinkedInSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserServicesController : ControllerBase
    {
        readonly UserServiceRepository _userServiceRepository;

        public UserServicesController()
        {
            _userServiceRepository = new UserServiceRepository();
        }


        // Add User Service //
        [HttpPost()]
        public ActionResult AddUserService(CreateUserServiceRequest createRequest)
        {

            var newUserService = _userServiceRepository.AddUserService(createRequest.UserId, createRequest.ServiceId);

            return Created($"api/userservices/{newUserService.Id}", newUserService);
        }

        // Get All User Services //
        [HttpGet]
        public ActionResult GetAllUserServices()
        {
            var userServices = _userServiceRepository.GetAll();

            return Ok(userServices);
        }


        // Delete User Service //
        [HttpDelete("{userId}")]
        public ActionResult DeleteUserService(int userId)
        {
            _userServiceRepository.DeleteUserService(userId);

            return Ok();
        }


        // Update User Service //
        [HttpPut("{userId}")]
        public ActionResult UpdateUserService(int userId, UpdateUserServiceRequest updateUserServiceRequest)
        {
            if (updateUserServiceRequest == null)
            {
                return BadRequest(new { error = "We Need More Info About Your Service" });
            }
            var updatedUser = _userServiceRepository.UpdateUserService(
                userId,
                updateUserServiceRequest.UserId,
                updateUserServiceRequest.ServiceId);

            return Ok();
        }
    }
}