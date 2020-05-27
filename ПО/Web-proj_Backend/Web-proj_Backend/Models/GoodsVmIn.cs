using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_proj_Backend.Models
{
    public class GoodsVmIn
    {
        public int? StoreId { get; set; }
        public string Good_name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int Amount { get; set; }
        public int Cost { get; set; }

    }
    public class GoodsVmOut
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Good_name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int Amount { get; set; }
        public int Cost { get; set; }

    }
}
