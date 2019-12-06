using CoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCore.Service
{
    public interface IMovieService
    {
        Task AddAsync(Movie model);
        Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId);
    }
}
