using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExerciseLogAPI.Core.Services;
using ExerciseLogAPI.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExerciseLogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        //Injection
        private IActivityService _activityService { get; set; }

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        // GET: api/activities
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Activity> activities = _activityService.GetAll();
            if (activities == null)
                return NotFound();

            return Ok(activities);
        }

        // GET api/activities
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Activity activity = _activityService.Get(id);

            if (activity == null)
                return NotFound();

            return Ok(activity);
        }

        // POST api/activities
        [HttpPost]
        public IActionResult Post([FromBody]Activity newActivity)
        {
            if (_activityService.Add(newActivity) == null)
                return BadRequest();

            return CreatedAtAction("Get", new { Id = newActivity.Id }, newActivity);
        }

        // PUT api/activities/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Activity updatedActivity)
        {
            Activity activity = _activityService.Update(updatedActivity);

            if (activity == null)
                return BadRequest();

            return Ok(updatedActivity);
        }

        // DELETE api/activities/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Activity delActivity = _activityService.Get(id);

            if (delActivity == null)
                return NotFound();

            _activityService.Remove(delActivity);
            return NoContent();
        }
    }
}
