using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UMS.Models
{
    public class User
    {
        public int Id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set;}
        public string Email { get; set;}
        public string Password { get; set;}
        public string Role { get; set; }

        protected User(int id, string fname,string lname, int age, string email, string password, string role)
        {
            Id = id;
            FirstName = fname;
            LastName = lname;
            Age = age;
            Email = email;
            Password = password;
            Role = role;
        }

        public static User FromXElement(XElement userElement)
        {
            return new User(
                id: int.Parse(userElement.Element("Id")?.Value ?? "0"),
                fname: userElement.Element("FirstName")?.Value ?? "",
                lname: userElement.Element("LastName")?.Value ?? "",
                age: int.Parse(userElement.Element("Age")?.Value ?? "0"),
                email: userElement.Element("Email")?.Value ?? "",
                password: userElement.Element("Password")?.Value ?? "",
                role: userElement.Element("Role")?.Value ?? ""
            );
        }
    }
}
