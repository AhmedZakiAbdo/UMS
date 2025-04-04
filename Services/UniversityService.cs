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
    static class UniversityService
    {
        public enum UniversityProperty
        {
            Id,
            Name,
            Location,
            All
        }
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data", "universities.xml");

        public static University GetUniversity(string universityName)
        {
            return GetUniversities().Where(uni => uni.Name.Equals(universityName)).FirstOrDefault(); 
        }
        public static University GetUniversity(int universityId)
        {
            return GetUniversities().Where(uni => uni.Id == universityId).FirstOrDefault();
        }
        public static void AddUniversity(User loggedInUser, University university)
        {
            if (loggedInUser.Role != "Admin")
            {
                Console.WriteLine("Access Denied: Only Admins can add universities.");
                return;
            }

            XDocument doc = XDocument.Load(filePath);
            XElement root = doc.Element("Universities");

            XElement newUniversity = new XElement("University",
                new XElement("Id", university.Id),
                new XElement("Name", university.Name),
                new XElement("Location", university.Location)
            );

            root?.Add(newUniversity);
            doc.Save(filePath);

            Console.WriteLine($"University '{university.Name}' added successfully!");
        }

        public static List<University> GetUniversities()
        {
            XDocument doc = XDocument.Load(filePath);
            return doc.Descendants("University")
                .Select(u => new University
                (
                    int.Parse(u.Element("Id")?.Value ?? "0"),
                    u.Element("Name")?.Value ?? "",
                    u.Element("Location")?.Value ?? ""
                ))
                .ToList();
        }
        public static void UpdateUniversity(User loggedInUser,int universityId, UniversityProperty property)
        {
            if (loggedInUser.Role != "Admin")
            {
                Console.WriteLine("Access Denied: Only Admins can update universities.");
                return;
            }

            XDocument doc = XDocument.Load(filePath);
            XElement university = doc.Descendants("University")
                .FirstOrDefault(u => (int)u.Element("Id") == universityId);
            if (university == null)
            {
                Console.WriteLine("University not found.");
                return;
            }

            //Console.WriteLine("Select the property you want to edit:");
            //Console.WriteLine("- Id");
            //Console.WriteLine("- Name");
            //Console.WriteLine("- Location");
            //Console.WriteLine("- All");
            //Console.Write("Enter choice: ");
            //string userInput = Console.ReadLine() ?? "";
            //if(Enum.TryParse(userInput, true, out property) && Enum.IsDefined(typeof(UniversityProperty),property))
            //{}

            switch (property)
            {
                case UniversityProperty.Id:
                    Console.Write("Enter new University Id: ");
                    int newId= int.Parse(Console.ReadLine()??"0");
                    university.Element("Id")?.SetValue(newId);
                    break;
                case UniversityProperty.Name:
                    Console.Write("Enter new University Name: ");
                    string newName = Console.ReadLine() ?? "";
                    university.Element("Name")?.SetValue(newName);
                    break;
                case UniversityProperty.Location:
                    Console.Write("Enter new University Location: ");
                    string newLocation = Console.ReadLine() ?? "";
                    university.Element("Location")?.SetValue(newLocation);
                    break;
                case UniversityProperty.All:
                    Console.Write("Enter new University Id: ");
                    newId = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Enter new University Name: ");
                    newName = Console.ReadLine() ?? "";
                    Console.Write("Enter new University Location: ");
                    newLocation = Console.ReadLine() ?? "";
                    university.Element("Name")?.SetValue(newName);
                    university.Element("Id")?.SetValue(newId);
                    university.Element("Location")?.SetValue(newLocation);
                    break;
                default:
                    Console.WriteLine("Invalid choice. No changes were made.");
                    return;
            }
            doc.Save(filePath);
            Console.WriteLine("University updated successfully!");
        }

        public static void DeleteUniversity(User loggedInUser, int universityId)
        {
            if (loggedInUser.Role != "Admin")
            {
                Console.WriteLine("Access Denied: Only Admins can delete universities.");
                return;
            }
            XDocument doc = XDocument.Load(filePath);
            XElement university = doc.Descendants("University")
                .FirstOrDefault(u => (int)u.Element("Id") == universityId);
            if (university != null)
            {
                university.Remove();
                doc.Save(filePath);
                Console.WriteLine($"University with ID {universityId} deleted.");
            }
            else
            {
                Console.WriteLine("University not found.");
            }
        }
    }
}
