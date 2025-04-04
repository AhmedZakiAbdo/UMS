using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Models;

namespace UMS.Services
{
    class InputService
    {

        public static University GetUniversityInput()
        {
            Console.WriteLine("Enter University Details:");

            Console.Write("Enter University ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter University Name: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Enter University Location: ");
            string location = Console.ReadLine() ?? "";

            return new University(id,name,location);
        }
    }
}
