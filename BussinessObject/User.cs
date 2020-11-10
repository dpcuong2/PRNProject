using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class User : BusinessObject
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Role { get; set; }
        public bool Status { get; set; }
        public string Name { get; set; }
    }
}
