using System.Linq;
using Web_proj_Backend.Data.Interfaces;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получение пользователя по id
        /// </summary>
        public Users GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);             
        }

        /// <summary>
        /// Получение пользователя по логину
        /// </summary>
        public Users GetByLogin(string login)
        {
            return _context.Users.FirstOrDefault(u => u.Login == login);
        }

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        public void Add(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        public void RemoveById(int userId)
        {
            var user = GetById(userId);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        /// <summary>
        /// Получение пользователя по токену
        /// </summary>
        public Users GetByToken(string token)
        {
            return _context.Users.FirstOrDefault(u => u.Token == token);
        }
    }
}