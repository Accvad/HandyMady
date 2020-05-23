using System;
using System.Collections.Generic;
using System.Text;

namespace Web_proj_Backend.Models.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int GoodId { get; set; }
        public string Sale_name { get; set; }
        public string Description { get; set; }
        public string Start { get; set; }
        public string Stop { get; set; }
        public int Percent { get; set; }

        public Goods Good { get; set; }
        public Stores Store { get; set; }
    }
}
