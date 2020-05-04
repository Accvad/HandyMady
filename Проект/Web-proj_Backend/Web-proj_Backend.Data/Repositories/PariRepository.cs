using System.Collections.Generic;
using Web_proj_Backend.Models.Entities;
using System.Linq;

namespace Web_proj_Backend.Data.Repositories
{
    public class PariRepository : IPariRepository
    {
        private readonly DataContext _context;
        public PariRepository(DataContext context)
        {
            _context = context;
        }
        public Pari Get(int pariId)
        {
            var pari = _context.Paris.FirstOrDefault(p => p.Id == pariId);
            return pari;
        }

        public IEnumerable<Pari> GetAll()
        {
            return _context.Paris;
        }
        public IEnumerable<Pari> GetAllUser(int userId)
        {
            return _context.Paris.Where(p => p.UserId == userId);
        }
                
        public void Add(Pari pari)
        {
            _context.Paris.Add(pari);
            _context.SaveChanges();
        }

        public void Delete(int pariId)
        {
            var pari = Get(pariId);
            _context.Paris.Remove(pari);
            _context.SaveChanges();
        }
        public IEnumerable<Pari> GetAllToken(string token)
        {
            var user = _context.Users.FirstOrDefault(u => u.Token == token);
            return _context.Paris.Where(p => p.UserId == user.Id);
        }

    }
}
