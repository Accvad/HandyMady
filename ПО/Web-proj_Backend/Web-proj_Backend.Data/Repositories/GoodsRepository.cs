﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web_proj_Backend.Data.Interfaces;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Data.Repositories
{
    public class GoodsRepository : IGoodsRepository
    {
        private readonly DataContext _context;
        public GoodsRepository(DataContext context)
        {
            _context = context;
        }
        public Goods GetById(int id)
        {
            return _context.Goods.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Goods Good)
        {
            _context.Goods.Add(Good);
            _context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            var Good = GetById(id);
            _context.Goods.Remove(Good);
            _context.SaveChanges();
        }

    }
}
