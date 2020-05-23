using System;
using System.Collections.Generic;
using System.Text;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Interfaces
{
    public interface ISubscriptionsRepository
    {
        /// <summary>
        /// Получение подписки по id
        /// </summary>
        Subscriptions GetById(int id);
        /// <summary>
        /// Создание новой подписки
        /// </summary>
        void Add(Subscriptions subscription);
        /// <summary>
        /// Удаление подписки по id
        /// </summary>
        void DeleteById(int id);

    }
}
