using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Получение пользователя по айди
        /// </summary>
        Users GetById(int id);
        /// <summary>
        /// Добавление нового пользователя
        /// </summary>
        void Add(Users user);
        /// <summary>
        /// Получение пользователя по логину
        /// </summary>
        Users GetByLogin(string login);
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        void RemoveById(int userId);
        /// <summary>
        /// Получение пользователя по токену
        /// </summary>

        Users GetByToken(string Token);        
    }
}