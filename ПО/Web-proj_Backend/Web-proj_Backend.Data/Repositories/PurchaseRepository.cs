using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web_proj_Backend.Data.Interfaces;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DataContext _context;
        public PurchaseRepository(DataContext context)
        {
            _context = context;
        }
        public Purchases GetById(int id)
        {
            return _context.Purchases.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Purchases purchase)
        {
            _context.Purchases.Add(purchase);
            _context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            var purchase = GetById(id);
            _context.Purchases.Remove(purchase);
            _context.SaveChanges();
        }
    }
}
