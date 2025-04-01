using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UMS.Models
{
    class People
    {
        public int Id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        protected People(int id, string fname,string lname, int age, string email)
        {
            Id = id;
            FirstName = fname;
            LastName = lname;
            Age = age;
            Email = email;
        }
    }
}
