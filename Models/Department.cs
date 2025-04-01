using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public College College { get; set; } // Reference to its college
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Professor> Professors { get; set; } = new List<Professor>();
    }
}
