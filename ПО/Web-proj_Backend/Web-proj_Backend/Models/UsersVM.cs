using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_proj_Backend.Models
{
    public class UsersVM
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Full_name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
