using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web_proj_Backend.Data.Interfaces;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Repositories
{
    public class SubscriptionsRepository : ISubscriptionsRepository
    {
        private readonly DataContext _context;
        public SubscriptionsRepository(DataContext context)
        {
            _context = context;
        }
        public Subscriptions GetById(int id)
        {
            return _context.Subscriptions.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Subscriptions subscription)
        {
            _context.Subscriptions.Add(subscription);
            _context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            var subscription = GetById(id);
            _context.Subscriptions.Remove(subscription);
            _context.SaveChanges();
        }
    }
}
