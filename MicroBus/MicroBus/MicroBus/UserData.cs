using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MicroBus
{
    [Table("Login")]
    public class UserData
    {
        [Column("username")]
        public string username { get;  set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Phone")]
        public string Phone { get; set; }


    }
}
