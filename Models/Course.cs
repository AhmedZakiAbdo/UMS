using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models
{
    class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public Department Department { get; set; } 
        public List<Professor> Instructors { get; set; } = new List<Professor>();

        public Course(int id, string name, int credits, Department department)
        {
            Id = id;
            Name = name;
            Credits = credits;
            Department = department;
        }

    }
}
