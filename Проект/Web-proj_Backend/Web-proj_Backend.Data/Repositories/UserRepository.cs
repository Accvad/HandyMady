using System.Linq;
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
        /// Получение пользователя по айди
        /// </summary>
        public User Get(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        /// <summary>
        /// Получение пользователя по логину
        /// </summary>
        public User Get(string login)
        {
            return _context.Users.FirstOrDefault(u => u.Login == login);
        }

        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        public void Remove(int userId)
        {
            var user = Get(userId);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        /// <summary>
        /// Получение пользователя по токену
        /// </summary>
        public User GetWithTok(string token)
        {
            return _context.Users.FirstOrDefault(u => u.Token == token);
        }
    }
}