﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models
{
    class Student : User
    {
        public string Major { get; set; }
        public Department Department { get; set; } // Student's department
        public List<Course> RegisteredCourses { get; set; } = new List<Course>(); // Courses taken

        public Student(
            int id,
            string fname,
            string lname,
            int age,
            string email,
            string password,
            string major,
            Department department
            )
            :base(id, fname,lname,age, email, password,"Student")
        {
            Major = major;
            Department = department;
        }
    }
}
