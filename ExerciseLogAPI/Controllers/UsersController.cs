using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExerciseLogAPI.Core.Services;
using ExerciseLogAPI.Core.Models;

namespace ExerciseLogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        //Injection
        private IUserService _userService { get; set; }

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("GetAllUsers", ex.Message);
                return NotFound(ModelState);
            }
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
               return Ok(_userService.Get(id));
            }
            catch (ApplicationException ex)
            {
                ModelState.AddModelError("GetUser", ex.Message);
                return NotFound(ModelState);
            }
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody] User newUser)
        {
            try
            {
                _userService.Add(newUser);
            }
            catch(ApplicationException ex)
            {
                ModelState.AddModelError("AddUser", ex.Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newUser.Id }, newUser);
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User updatedUser)
        {
            try
            {
                return Ok(_userService.Update(updatedUser));
            }
            catch(ApplicationException ex)
            {
                ModelState.AddModelError("UpdateUser", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                User delUser = _userService.Get(id);
                _userService.Remove(delUser);

                return NoContent();
            }
            catch(ApplicationException ex)
            {
                ModelState.AddModelError("DeleteUser", ex.Message);
                return NotFound(ModelState);
            }
        }
    }
}
