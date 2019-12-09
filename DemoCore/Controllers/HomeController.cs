using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.Models;
using DemoCore.Service;
using DemoCore.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DemoCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public HomeController(ICinemaService cinemaService,IOptions<ConnectionOptions>options)
        {
            _cinemaService = cinemaService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "电影院";
            return View(await _cinemaService.GetllAllAsync());
        }
        public IActionResult Add()
        {
            ViewBag.Title = "添加电影院";
            return View(new Cinema());
        }

        public async Task<IActionResult> Edit(int cinemaId)
        {
            var cinema = await _cinemaService.GetByIdAsync(cinemaId);
            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cinema model)
        {
            if (ModelState.IsValid)
            {
                var exist = await _cinemaService.GetByIdAsync(id);
                if (exist == null)
                {
                    return NotFound();
                }
                exist.Name = model.Name;
                exist.Location = model.Location;
                exist.Capacity = model.Capacity;
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Add(Cinema model)
        {
            if (ModelState.IsValid)
            {
                await _cinemaService.AddAsync(model);
            }       
            return RedirectToAction("Index");
        }


    }
}