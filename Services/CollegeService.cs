using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UMS.Models;
using static UMS.Services.UniversityService;

namespace UMS.Services
{
    class CollegeService
    {
        public enum CollegeProperty
        {
            Id,
            Name,
            University,
            All
        }
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Data", "colleges.xml");

        public static College GetCollege(string collegeName)
        {
            return GetColleges().Where(c => c.Name.Equals(collegeName)).FirstOrDefault();
        }
        public static College GetCollege(int collegeId)
        {
            return GetColleges().Where(c => c.Id == collegeId).FirstOrDefault();
        }
        public static void AddCollege (User loggedInUser,College college)
        {
            if(loggedInUser.Role != "Admin")
            {
                Console.WriteLine("Access Denied: Only Admins can add colleges.");
                return;
            }
            XDocument doc = XDocument.Load(filePath);
            XElement root = doc.Element("Colleges");
            XElement newCollege = new XElement("College",
               new XElement("Id", college.Id),
               new XElement("Name", college.Name),
               new XElement("University", college.University.Name??"")
                );
            root?.Add(newCollege);
            doc.Save(filePath);
        }

        public static List<College> GetColleges()
        {
            
            XDocument doc = XDocument.Load(filePath);
            return doc.Descendants("College").Select
                (u => new College(
                    int.Parse(u.Element("Id").Value ?? "0"),
                    u.Element("Name").Value??"",
                    UniversityService.GetUniversity(u.Element("University").Value??"")
                )).ToList();
        }

        public static void UpdateUniversity(User loggedInUser, int collegeId, CollegeProperty property)
        {
            if (loggedInUser.Role != "Admin")
            {
                Console.WriteLine("Access Denied: Only Admins can Edit colleges.");
                return;
            }

            XDocument doc = XDocument.Load(filePath);
            XElement college = doc.Descendants("College")
                .FirstOrDefault(u => (int)u.Element("Id") == collegeId);
            if (college == null)
            {
                Console.WriteLine("University not found.");
                return;
            }
            switch (property)
            {

                case CollegeProperty.Id:
                    Console.Write("Enter College's New Id: ");
                    int newId = int.Parse(Console.ReadLine() ?? "0");
                    college.Element("Id")?.SetValue(newId);
                    break;
                case CollegeProperty.Name:
                    Console.Write("Enter College's New Name: ");
                    string newName = Console.ReadLine() ?? "";
                    college.Element("Name")?.SetValue(newName);
                    break;
                case CollegeProperty.University:
                    Console.Write("Enter The New University Name which this college belongs: ");
                    University newUniversity = UniversityService.GetUniversity(Console.ReadLine() ?? "");
                    college.Element("University")?.SetValue(newUniversity.Name);
                    break;
                case CollegeProperty.All:
                    Console.Write("Enter College's New Id: ");
                    newId = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Enter College's New Name: ");
                    newName = Console.ReadLine() ?? "";
                    Console.Write("Enter The New University Name which this college belongs: ");
                    newUniversity = UniversityService.GetUniversity(Console.ReadLine() ?? "");
                    college.Element("Name")?.SetValue(newName);
                    college.Element("Id")?.SetValue(newId);
                    college.Element("University")?.SetValue(newUniversity.Name);
                    break;
                default:
                    Console.WriteLine("Invalid choice. No changes were made.");
                    return;
            }
            doc.Save(filePath);
            Console.WriteLine("University updated successfully!");
        }

        public static void DeleteCollege(User loggedInUser , int collegeId)
        {
            if (loggedInUser.Role != "Admin")
            {
                Console.WriteLine("Access Denied: Only Admins can delete colleges.");
                return;
            }

            XDocument doc = XDocument.Load(filePath);
            XElement selectedCollege = doc.Descendants("College")
                                          .FirstOrDefault(u => (int)u.Element("Id") == collegeId);
            if (selectedCollege != null)
            {
                selectedCollege.Remove();
                doc.Save(filePath);
                Console.WriteLine($"College with ID {collegeId} deleted.");
            }
            else
            {
                Console.WriteLine("College not found.");
            }
        }
    }
}
