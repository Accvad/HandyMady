using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web_proj_Backend.Data.Interfaces;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Repositories
{
    public class PositionsRepository : IPositionsRepository
    {
        private readonly DataContext _context;
        public PositionsRepository(DataContext context)
        {
            _context = context;
        }
        public Positions GetById(int id)
        {
            return _context.Positions.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Positions position)
        {
            _context.Positions.Add(position);
            _context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            var position = GetById(id);
            _context.Positions.Remove(position);
            _context.SaveChanges();
        }
    }
}
