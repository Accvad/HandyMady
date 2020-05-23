using System;
using System.Collections.Generic;
using System.Text;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Interfaces
{
    public interface ISalesRepository
    {
        /// <summary>
        /// Получение акции по id
        /// </summary>
        Sales GetById(int id);
        /// <summary>
        /// Создание акции
        /// </summary>
        void Add(Sales sale);
        /// <summary>
        /// Удаление акции по id
        /// </summary>
        void DeleteById(int id);

    }
}
