using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSApi.Entity;
using SMSApi.Service;

namespace SMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService _iStudentService;

        public StudentController(IStudentService iStudentService) {
            _iStudentService = iStudentService;
        }

        [HttpGet("students")]
        public IActionResult GetAllStudents() {
            return Ok(_iStudentService.GetAll());
        }

        [HttpPost("insert")]
        public IActionResult Insert(Student s) {
           Student sobj= _iStudentService.Insert(s);
            Console.WriteLine("Student Inserted");
            return Ok("Inserted student "+sobj);
        }

        [HttpGet("getByStatus/{status}/")]
        public IActionResult GetByStatus(string status) {
            return Ok(_iStudentService.GetByStatus(status));
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById(int id) {
            return Ok(_iStudentService.GetById(id));
        }

        [HttpPut("/update")]
        public IActionResult Update(Student s) {
            Student sobj = _iStudentService.Update(s);
            return Ok(s);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) { 
            Student s=_iStudentService.Delete(id);
            return Ok("Delete obj" + s);
        }

        [HttpGet("sort")]
        public IActionResult Sort() {
            return Ok(_iStudentService.Sort());
        }
    }

}
