using Softone.Core.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softone.Service.Student
{
    public interface IStudentService
    {
        string AddStudent(string spType, AddStudent addStudent);
        List<StudentDetails> GetStudentDetails();
        string RemoveStudent(string spType, int id);
        string UpdateStudent(string spType, StudentDetails student);
    }
}
