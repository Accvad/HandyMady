using System;
using System.Collections.Generic;
using System.Text;

namespace Web_proj_Backend.Models.Entities
{
    public class Subscriptions
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StoreId { get; set; }

        public Users User { get; set; }
        public Stores Store { get; set; }
    }
}
