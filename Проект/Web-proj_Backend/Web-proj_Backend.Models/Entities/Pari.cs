using System;
using System.Collections.Generic;
using System.Text;

namespace Web_proj_Backend.Models.Entities
{
    public class Pari
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Ending { get; set; }
    }
}