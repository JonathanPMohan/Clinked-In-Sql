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
    public class ServicesController : ControllerBase
    {
        readonly ServicesRepository _serviceRepository;
        readonly ServiceRequestValidator _validator;

        public ServicesController()
        {
            _validator = new ServiceRequestValidator();
            _serviceRepository = new ServicesRepository();
        }

        // Add Service //
        [HttpPost()]
        public ActionResult AddService(CreateServiceRequest createRequest)
        {
            if (!_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "What Is The Name Of Your Service?" });
            }

            var newService = _serviceRepository.AddService(createRequest.Name, createRequest.Description, createRequest.Price);

            return Created($"api/services/{newService.Id}", newService);
        }


        // Get All Services //
        [HttpGet]
        public ActionResult GetAllServices()
        {
            var services = _serviceRepository.GetAll();

            return Ok(services);
        }


        // Update Services //
        [HttpPut("{userId}")]
        public ActionResult UpdateService(int userId, UpdateServiceRequest updateServiceRequest)
        {
            if (updateServiceRequest == null)
            {
                return BadRequest(new { error = "We Need More Info About Your Service" });
            }

            var updatedUser = _serviceRepository.UpdateService(
                userId,
                updateServiceRequest.Name,
                updateServiceRequest.Description,
                updateServiceRequest.Price);

            return Ok();
        }


        // Delete Service //
        [HttpDelete("{userId}")]
        public ActionResult DeleteService(int userId)
        {
            _serviceRepository.DeleteService(userId);

            return Ok();
        }
    }
}