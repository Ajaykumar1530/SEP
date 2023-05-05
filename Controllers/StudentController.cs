using InterView.Models;
using InterView.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterView.Controllers
{
    public class StudentController : Controller
    {
        public readonly StudentService _studentService;
        public StudentController(StudentService studenService)
        {
            this._studentService = studenService;
        }

        public IActionResult GetAllEmployees()
        {
            var student = _studentService.GetAllStudents();
            return View(student);
        }
        public async Task<IActionResult> AddStudent(Student student)
        {
             _studentService.AddStudent(student);
            return View(student);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
