using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using TOUR_US.BO.Service;
using TOUR_US.BO.ViewModels;
using TOUR_US.DAL.Models;
using TOUR_US.DAL.Services;

namespace IdentityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(Roles ="User")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IGenericRepos<Category> _cat;
        private readonly QueryFilterBO<Category> _query;




        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IGenericRepos<Category> cat, QueryFilterBO<Category> query)
        {
            _logger = logger;
            _cat = cat;
            _query = query;
        }

        [HttpGet]
        public IEnumerable<Category> Get([FromQuery] QueryFilter queryFilter)
        {
            //var result = _cat.GetAll().Where("Title== @0","Test");
            //new TOUR_US.BO.ViewModels.QueryFilter()
            //{
            //    OrderByDescending = true,
            //    OrderProperty = "Title",
            //    PropertyNames = new string[] { "Title", "Header" },
            //    PropertyValues = new string[] { "Siz", "xxx" },
            //    Condition = "OR"
            //}
            var result = _query.Filter(queryFilter);
            return result;
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
