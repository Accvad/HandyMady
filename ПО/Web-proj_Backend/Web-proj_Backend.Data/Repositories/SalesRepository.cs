using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web_proj_Backend.Data.Interfaces;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly DataContext _context;
        public SalesRepository(DataContext context)
        {
            _context = context;
        }
        public Sales GetById(int id)
        {
            return _context.Sales.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Sales sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            var sale = GetById(id);
            _context.Sales.Remove(sale);
            _context.SaveChanges();
        }
    }
}
