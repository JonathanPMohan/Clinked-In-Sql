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
    public class UsersInterestsController : ControllerBase
    {
        readonly UserInterestRepository _userInterestRepository;

        public UsersInterestsController()
        {
            _userInterestRepository = new UserInterestRepository();
        }

        // Add User Interest //
        [HttpPost]
        public ActionResult AddUserInterest(CreateUserInterestRequest createRequest)
        {
            var newUserInterest = _userInterestRepository.AddUserInterest(createRequest.UserId, createRequest.InterestId);

            return Created($"api/userinterests/{newUserInterest.Id}", newUserInterest);
        }


        // Get All User Interests //
        [HttpGet]
        public ActionResult GetAllUserInterests()
        {
            var userInterests = _userInterestRepository.GetAll();

            return Ok(userInterests);
        }



        // Delete User Interest //
        [HttpDelete("{userId}")]
        public ActionResult DeleteUserInterest(int userId)
        {
            _userInterestRepository.DeleteUserInterest(userId);

            return Ok();
        }

        // Update User Interest //
        public ActionResult UpdateUserInterest(int userId, UpdateUserInterestRequest updateUserInterestRequest)
        {
            if (updateUserInterestRequest == null)
            {
                return BadRequest(new { error = "We Need More Info, Buddy" });
            }
            var updatedUser = _userInterestRepository.UpdateUserInterest(
                userId,
                updateUserInterestRequest.UserId,
                updateUserInterestRequest.InterestId);

            return Ok();
        }

    }
}