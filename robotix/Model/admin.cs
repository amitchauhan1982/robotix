using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace robotix.Model
{
    public class admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginDate { get; set; }        
        public Userrole userrole { get; set; } 
        public DateTime CreatedDate { get; set; }

    public admin()
    {
        this.CreatedDate = DateTime.UtcNow;
    }
}
   
    public enum Userrole
    {
        Manager,Subscriber
    }
}
