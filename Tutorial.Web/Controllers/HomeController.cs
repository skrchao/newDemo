using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Web.Model;
using Tutorial.Web.Services;
using Tutorial.Web.ViewModels;

namespace Tutorial.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Student> _repository;
        public HomeController(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var list = _repository.GetAll();
            var vms = list.Select(x => new HomeIndexViewModel
            {
                Name = $"{x.FirstName} {x.LastName}",
                Age = DateTime.Now.Subtract(x.BirthDate).Days / 365
            });
            return View (vms);
        }
    }
}
