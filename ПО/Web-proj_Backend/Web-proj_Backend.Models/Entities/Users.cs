using System;
using System.Collections.Generic;
using System.Text;

namespace Web_proj_Backend.Models.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string Full_name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Money { get; set; }

        public List<Subscriptions> Subscribe_list { get; set; }
        public List<Stores> Stores { get; set; }
        public List<Purchases> Purchase { get; set; }

    }
}