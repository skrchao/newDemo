using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.Models;

namespace DemoCore.Service
{
    public class CinemaMemoryService : ICinemaService
    {
        private readonly List<Cinema> _cinemas = new List<Cinema>();

        public CinemaMemoryService()
        {
            _cinemas.Add(new Cinema
            {
                Name = "City Cinema",
                Location = "Road ABC, NO.123",
                Capacity = 1000
            });
            _cinemas.Add(new Cinema
            {
                Name = "Fly Cinema",
                Location = "Road Hello, NO.1024",
                Capacity = 500
            });
        }
        public Task AddAsync(Cinema model)
        {
            var maxId = _cinemas.Max(x => x.Id);
            model.Id = maxId + 1;
            _cinemas.Add(model);
            return Task.CompletedTask;
        }

        public Task<Cinema> GetByIdAsync(int id)
        {
            return Task.Run(() => _cinemas.FirstOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<Cinema>> GetllAllAsync()
        {
            return Task.Run(() => _cinemas.AsEnumerable());
        }

        public Task<Sales> GetSalesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
