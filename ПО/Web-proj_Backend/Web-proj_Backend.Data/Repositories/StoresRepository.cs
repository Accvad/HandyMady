using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web_proj_Backend.Data.Interfaces;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Repositories
{
    public class StoresRepository : IStoresRepository
    {
        private readonly DataContext _context;

        public StoresRepository(DataContext context)
        {
            _context = context;
        }

        public Stores GetById(int id)
        {
            return _context.Stores.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Stores store)
        {
            _context.Stores.Add(store);
            _context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            var store = GetById(id);
            _context.Stores.Remove(store);
            _context.SaveChanges();
        }
    }
}
