using System;
using System.Collections.Generic;
using System.Text;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Interfaces
{
    public interface IGoodsRepository
    {
        /// <summary>
        /// Получение товара по id
        /// </summary>
        Goods GetById(int id);
        /// <summary>
        /// Создание товара
        /// </summary>
        void Add(Goods good);
        /// <summary>
        /// Удаление товара по id
        /// </summary>
        void DeleteById(int id);
    }
}
