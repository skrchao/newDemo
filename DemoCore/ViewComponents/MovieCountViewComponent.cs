using DemoCore.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.ViewComponents
{
    public class MovieCountViewComponent:ViewComponent
    {
        private readonly IMovieService _movieService;

        public MovieCountViewComponent(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int cimemaId)
        {
            var movies = await _movieService.GetByCinemaAsync(cimemaId);
            var count = movies.Count();
            return View(count);
        }

    }
}
