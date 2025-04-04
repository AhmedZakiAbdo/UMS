using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models
{
    class University
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public char Classification { get; set; }
        public List<College> Colleges { get; set; } = new List<College>();

        public University(int id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }
    }
}   
