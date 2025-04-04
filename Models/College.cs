using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models
{
    class College
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public University University { get; set; } // Reference to its university
        public List<Department> Departments { get; set; } = new List<Department>();
        public College(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public College(int id, string name, University university)
        {
            Id = id;
            Name = name;
            University = university;
        }
    }
}
