using System;
using System.Collections.Generic;
using System.Text;

namespace Web_proj_Backend.Models.Entities
{
    public class Positions
    {
        public int Id { get; set; }
        public int GoodId { get; set; }
        public int Amount { get; set; }

        public List<Purchases> Purchase { get; set; }

        public Goods Good { get; set; }
    }
}
