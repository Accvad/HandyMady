using System;
using System.Collections.Generic;
using System.Text;

namespace Web_proj_Backend.Models.Entities
{
    public class Purchases
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PositionId { get; set; }
        public string Date { get; set; }
        public int Status { get; set; }
        public int Full_price { get; set; }
        public int Rate_store { get; set; }
        public int Rate_good { get; set; }

        public Users User { get; set; }
        public Positions Position { get; set; }
    }
}
