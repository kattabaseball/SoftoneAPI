using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softone.Core.Student
{
    public class StudentDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile {  get; set; }
        public string Email { get; set; }
        public string NIC { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set;}
        public string ImageUrl { get; set;}
        public bool IsDisable { get; set; }
    }
}
