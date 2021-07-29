using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOUR_US.BO.Service;
using TOUR_US.BO.ViewModels;
using TOUR_US.DAL.Models;
using TOUR_US.DAL.Repos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TOUR_US.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly ActivityBO _activity;
      

        public ActivitiesController(ActivityBO activity, ActivityRepos activityRepos)
        {
            _activity = activity;
          
        }

        // GET: api/<ActivitiesController>
        [HttpGet]
        public IEnumerable<ActivityVM> Get([FromQuery] QueryFilter query)
        {
            return _activity.GetActivities(query);
        }

        [HttpGet]
        public List<Activity> GetActivityByCategoryId(int categoryId)
        {
            return _activity.GetActivityByCategoryId(categoryId);
        }



        // GET api/<ActivitiesController>/5
        [HttpGet("{id}")]
        public async Task<ActivityVM> Get(int id)
        {
            return await _activity.GetById(id);
        }

        // POST api/<ActivitiesController>
        [HttpPost]
        public async Task<ActionResult<ActivityVM>> Post([FromForm] ActivityVM activity)
        {
            if (!ModelState.IsValid) { return BadRequest(activity); }
            try
            {
                return Ok(await _activity.Add(activity));
            }
            catch
            {
                return BadRequest(activity);
            }
        }

        // PUT api/<ActivitiesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ActivityVM>> Put(int id, [FromForm] ActivityVM activity)
        {
            if (id != activity.Id || !ModelState.IsValid)
            {
                return BadRequest(activity);
            }
            try
            {
                return Ok(await _activity.Update(activity));
            }
            catch
            {
                return BadRequest(activity);
            }
        }

        // DELETE api/<ActivitiesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id != default(int))
            {
                try
                {
                    await _activity.Delete(id);
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }
    }
}
