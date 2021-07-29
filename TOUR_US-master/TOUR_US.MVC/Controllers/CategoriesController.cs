using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using TOUR_US.DAL.Models;
using TOUR_US.DAL.Services;

namespace TOUR_US.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IGenericRepos<Category> _generic;

        public CategoriesController(IGenericRepos<Category> generic)
        {
            _generic = generic;
        }
        public IActionResult Index()
        {

            var result = _generic.GetAll().Where(string.Format("{0}=={1}", "Title", "Test"));
            return View();
        }
    }
}
