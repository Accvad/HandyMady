using System;
using System.Collections.Generic;
using System.Text;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Interfaces
{
    public interface IPurchaseRepository
    {
        /// <summary>
        /// Получение корзин по id
        /// </summary>
        Purchases GetById(int id);
        /// <summary>
        /// Создание новой корзины
        /// </summary>
        void Add(Purchases purchase);
        /// <summary>
        /// Удаление корзины и товаров внутри
        /// </summary>
        void DeleteById(int id);

    }
}
