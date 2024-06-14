using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Softone.Core.Student;
using Softone.Service.Student;
using System.Threading.Tasks;

namespace SoftoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet("GetStudentDetails")]

        public IActionResult GetStudentDetails() 
        {
            try
            {
                var result = _studentService.GetStudentDetails();
                //returning the data
                return Json(result);
            }
            catch (Exception ex)
            {
                //Throwing an exception
                throw new Exception("GetStudentDetails api failed at controller : " + ex.Message);
            }

        }

        [HttpPost("AddStudent")]

        public IActionResult AddStudent([FromBody] AddStudent addStudent, string spType)
        {
            try
            {
                var result = _studentService.AddStudent(spType, addStudent);
                //returning the data
                return Json(result);
            }
            catch (Exception ex)
            {
                //Throwing an exception
                throw new Exception("AddStudent api failed at controller : " + ex.Message);
            }
        }



        [HttpPost("UpdateStudent")]

        public IActionResult UpdateStudent(string spType, StudentDetails student)
        {
            try
            {
                var result = _studentService.UpdateStudent(spType, student);
                //returning the data
                return Json(result);
            }
            catch (Exception ex)
            {
                //Throwing an exception
                throw new Exception("UpdateStudent api failed at controller : " + ex.Message);
            }
        }


        [HttpDelete("RemoveStudent")]

        public IActionResult RemoveStudent(string spType, int id)
        {
            try
            {
                var result = _studentService.RemoveStudent(spType, id);
                //returning the data
                return Json(result);
            }
            catch (Exception ex)
            {
                //Throwing an exception
                throw new Exception("RemoveStudent api failed at controller : " + ex.Message);
            }
        }


    }
}
