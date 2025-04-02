using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UMS.Models;
namespace UMS.Services
{
    public static class AuthenticationService
    {
        private static User _loggedInUser = null;
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data", "users.xml");

        public static bool Login(string email, string password)
        {
            XDocument doc = XDocument.Load(filePath);

            XElement userElement = doc.Descendants("User")
                          .FirstOrDefault(u => u.Element("Email")?.Value == email);

            if (userElement == null)
            {
                Console.WriteLine("User not found.");
                return false;
            }
            User user = User.FromXElement(userElement);

            string storedHash = user.Password;

            if (!PasswordHasher.VerifyPassword(password, storedHash))
            {
                Console.WriteLine("Invalid password.");
                return false;
            }
            _loggedInUser =user;

            Console.WriteLine($"Login successful! Welcome {_loggedInUser.FirstName}");
            return true;
        }

        public static void Logout()
        {
            Console.WriteLine("User logged out.");
            _loggedInUser = null;
        }
        public static bool IsLoggedIn()
        {
            return _loggedInUser != null;
        }
        public static bool HasPermission(string requiredRole)
        {
            return _loggedInUser != null && _loggedInUser.Role.ToString() == requiredRole;
        }
        public  static User GetLoggedInUser()
        {
            return _loggedInUser;
        }
        
    }
}
