using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedInSql.Data;
using ClinkedInSql.Models;
using ClinkedInSql.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedInSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly UsersRepository _userRepository;
        readonly UserRequestValidator _validator;

        public UsersController()
        {
            _userRepository = new UsersRepository();
            _validator = new UserRequestValidator();
        }

       // Get All Users //
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult GetAllUsers()
        {

            var users = _userRepository.GetAll();

            return Ok(users);
        }


        // Add User //
        [HttpPost("register")]
        public ActionResult AddUser(CreateUserRequest createRequest)
        {
            if (!_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "Does Our User Have A Name?" });
            }

            var newUser = _userRepository.AddUser(createRequest.Name, createRequest.ReleaseDate, createRequest.Age, createRequest.IsPrisoner);

            return Created($"api/users/{newUser.Id}", newUser);
        }


        // Delete User //
        [HttpDelete("{userId}")]
        public ActionResult DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);

            return Ok();
        }


        // Update User //
        [HttpPut("{userId}")]
        public ActionResult UpdateUser(int userId, UpdateUserRequest updateUserRequest)
        {
            if (updateUserRequest == null)
            {
                return BadRequest(new { error = "Your Argument Is Invalid" });
            }
            var updatedUser = _userRepository.UpdateUser(
                userId,
                updateUserRequest.Name,
                updateUserRequest.ReleaseDate,
                updateUserRequest.Age,
                updateUserRequest.IsPrisoner);
            return Ok();
        }
    }
}