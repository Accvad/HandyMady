using System;
using System.Collections.Generic;
using System.Text;

namespace Web_proj_Backend.Models.Entities
{
    public class Goods
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Sale_name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int Amount { get; set; }
        public int Cost { get; set; }

        public List<Positions> Positions { get; set; }
        public List<Sales> Sales { get; set; }

        public Stores Store { get; set; }
    }
}
