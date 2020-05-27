using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_proj_Backend.Models
{
    public class StoresVM 
    {
        public string Token { get; set; }
        public string Store_name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
    }
}
