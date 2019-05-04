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
    [Route("api/[controller]"), ApiController]
    public class InterestsController : ControllerBase

    {
        readonly InterestRepository _interestRepository;
        readonly InterestRequestValidator _validator;

        public InterestsController()
        {
            _validator = new InterestRequestValidator();
            _interestRepository = new InterestRepository();
        }

        // Add Interest //
        [HttpPost()]
        public ActionResult AddInterest(CreateInterestRequest createRequest)
        {
            if (!_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "Does Your Interest Have A Title?" });
            }

            var newInterest = _interestRepository.AddInterest(createRequest.Name);

            return Created($"api/interests/{newInterest.Id}", newInterest);
        }


        // Get All Interests //
        [HttpGet]
        public ActionResult GetAllInterests()
        {
            var interests = _interestRepository.GetAll();

            return Ok(interests);
        }


        // Delete Interest //
        [HttpDelete("{userId}")]
        public ActionResult DeleteInterest(int userId)
        {
            _interestRepository.DeleteInterest(userId);

            return Ok();
        }


        // Update Interest //
        [HttpPut("{userId}")]
        public ActionResult UpdateInterest(int userId, UpdateInterestRequest updateInterestRequest)
        {
            if (updateInterestRequest == null)
            {
                return BadRequest(new { error = "We Need More Interest Infomation" });
            }
            var updatedUser = _interestRepository.UpdateInterest(
                userId,
                updateInterestRequest.Name);

            return Ok();
        }
    }
}