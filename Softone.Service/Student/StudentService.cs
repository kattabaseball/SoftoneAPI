using Softone.Core.Student;
using Softone.DataAccess.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softone.Service.Student
{
    public class StudentService : IStudentService
    {
        IStudentDataAccess _studentDataAccess;

        public StudentService(IStudentDataAccess studentDataAccess)
        {
            _studentDataAccess = studentDataAccess;
        }

        public string AddStudent(string spType, AddStudent addStudent)
        {
            return _studentDataAccess.AddStudent(spType, addStudent);
        }

        public List<StudentDetails> GetStudentDetails()
        {
            var result = _studentDataAccess.GetStudentDetails();

            return result;
        }

        public string RemoveStudent(string spType, int id)
        {
            return _studentDataAccess.RemoveStudent(spType, id);
        }

        public string UpdateStudent(string spType, StudentDetails student)
        {
            return _studentDataAccess.UpdateStudent(spType, student);
        }
    }
}
