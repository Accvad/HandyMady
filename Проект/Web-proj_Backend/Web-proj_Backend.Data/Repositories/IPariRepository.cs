using System;
using System.Collections.Generic;
using System.Text;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Repositories
{
    public interface IPariRepository
    {
        /// <summary>
        /// Получить пари по айди
        /// </summary>
        Pari Get(int pariId);

        /// <summary>
        /// Получить все пари пользователя
        /// </summary>
        IEnumerable<Pari> GetAllUser(int userId);

        /// <summary>
        /// Получить все пари
        /// </summary>
        IEnumerable<Pari> GetAll();

        /// <summary>
        /// Добавить новое пари
        /// </summary>
        void Add(Pari pari);

        /// <summary>
        /// Удалить пари
        /// </summary>
        void Delete(int pariId);
        /// <summary>
        /// Получить все пари пользователя по токену
        /// </summary>
        IEnumerable<Pari> GetAllToken(string token);
    }
}
