using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Получение пользователя по айди
        /// </summary>
        User Get(int id);
        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        void Add(User user);
        /// <summary>
        /// Получение пользователя по логину
        /// </summary>
        User Get(string login);
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        void Remove(int userId);
        /// <summary>
        /// Получение пользователя по токену
        /// </summary>

        User GetWithTok(string Token);        
    }
}