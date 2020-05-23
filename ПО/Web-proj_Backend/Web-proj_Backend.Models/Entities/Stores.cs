using System;
using System.Collections.Generic;
using System.Text;

namespace Web_proj_Backend.Models.Entities
{
    public class Stores
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Store_name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }

        public List<Goods> Goods { get; set; }
        public List<Sales> Sales { get; set; }
        public List<Subscriptions> Subscribe_List { get; set; }

        public Users User { get; set; }
    }
}
