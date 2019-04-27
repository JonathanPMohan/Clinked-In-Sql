using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedInSql.Data;
using ClinkedInSql.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedInSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly UsersRepository _userRepository;

        public UsersController()
        {
            _userRepository = new UsersRepository();
        }

        // GET: api/Users
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult GetAllUsers()
        {

            var users = _userRepository.GetAll();

            return Ok(users);
        }

    }
}