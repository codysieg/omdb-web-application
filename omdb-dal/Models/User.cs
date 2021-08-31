using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace omdb_dal.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Email_Address { get; set; }
        public string Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }  
    }
}