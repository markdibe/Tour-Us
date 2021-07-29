using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOUR_US.BO.Service;
using TOUR_US.BO.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TOUR_US.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryBO _category;

        public CategoriesController(CategoryBO category)
        {
            _category = category;
        }

        [HttpGet]
        public IEnumerable<CategoryVM> Get([FromQuery] QueryFilter query)
        {
            return _category.GetCategories(query);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<CategoryVM> Get(int id)
        {
            return await _category.GetById(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<CategoryVM>> Post([FromForm] CategoryVM category)
        {
            if (!ModelState.IsValid) { return BadRequest(category); }
            try
            {
                return Ok(await _category.Add(category));
            }
            catch
            {
                return BadRequest(category);
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryVM>> Put(int id, [FromForm] CategoryVM category)
        {
            if(id != category.Id || !ModelState.IsValid)
            {
                return BadRequest(category);
            }
            try
            {
                return Ok(await _category.Update(category));
            }
            catch
            {
                return BadRequest(category);
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id != default(int))
            {
                try
                {
                    await _category.Delete(id);
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
