using System;
using System.Collections.Generic;
using System.Text;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Interfaces
{
    public interface IPositionsRepository
    {
        /// <summary>
        /// Получение позиции для товара по id
        /// </summary>
        Positions GetById(int id);
        /// <summary>
        /// Создание новой позиции для товара
        /// </summary>
        void Add(Positions position);
        /// <summary>
        /// Удаление позиции для товаров по id
        /// </summary>
        void DeleteById(int id);

    }
}
