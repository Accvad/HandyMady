using System;
using System.Collections.Generic;
using System.Text;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Interfaces
{
    public interface IStoresRepository
    {
        /// <summary>
        /// Получение магазина по id
        /// </summary>
        Stores GetById(int id);
        /// <summary>
        /// Создание магазина
        /// </summary>
        void Add(Stores store);
        /// <summary>
        /// Удаление магазина по id
        /// </summary>
        void DeleteById(int id);
    }
}
