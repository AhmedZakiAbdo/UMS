using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models
{
    class Admin : People
    {
        public string Role { get; set; } // Example: "Registrar", "Dean"
        public University University { get; set; } // Works at a university

        public Admin(int id, string fname, string lname, int age, string email, string role, University university)
               :base(id, fname, lname, age, email)
        {
            Role = role;
            University = university;
        }
    }
}
