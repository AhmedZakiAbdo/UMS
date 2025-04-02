using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models
{
    class Professor : User
    {
        public string Title { get; set; } // Example: "Dr.", "Professor"
        public Department Department { get; set; } // Professor's department
        public List<Course> TaughtCourses { get; set; } = new List<Course>(); // Courses taught
        public Professor(int id, string fname, string lname, int age, string email, string password, string title, Department department)
               :base(id, fname, lname, age, email,password, "Professor")
        {
            Title = title;
            Department = department;
        }
    }
}
