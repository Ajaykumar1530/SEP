using InterView.Models;
using InterView.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterView.Controllers
{
    public class MCQsController : Controller
    {

        private readonly McqsService _mcqsService;
        private readonly StudentDbContext _dbContext;

        public MCQsController(McqsService mcqsService, StudentDbContext dbContext)
        {
            this._mcqsService = mcqsService;
            this._dbContext = dbContext;
        }

        /*  public IActionResult GetAllQuestions()
          {
              var questions = _mcqsService.GetAllQuestions();
              return View(questions);
          }*/
        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            var questions = _dbContext.MCQsQuestions.ToList();
            return View(questions);
        }

        [HttpPost]
        public IActionResult GetAllQuestions(IFormCollection form)
        {
            int score = 0;

            foreach (var key in form.Keys)
            {
                if (int.TryParse(form[key], out int selectedOption))
                {
                    // Get the question ID from the form key
                    int questionId = int.Parse(key.Replace("question", ""));
                    // Get the correct answer from the database
                    var question = _dbContext.MCQsQuestions.FirstOrDefault(q => q.Id == questionId);
                    // Check if the selected option matches the correct answer
                    if (selectedOption == question.CorrectOption)
                    {
                        score++;
                    }
                }
                TempData["Score"] = score;
            }
            TempData.Keep("Score");
            return View("Result");
        }
        [HttpGet]
        public IActionResult StartTest()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Result()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(Student student)
        {
            var id = TempData["id"];
            var stid = _dbContext.Students.Find(id);
            int score = 0;
            if (TempData.ContainsKey("Score") && TempData["Score"] != null)
            {
                score = (int)TempData["Score"];
            }
            stid.Score = score;
            if (stid != null)
            {
                _dbContext.Students.Update(stid);
                _dbContext.SaveChanges();
            }
            return View("StudentLogin");
        }

        [HttpGet]
        public IActionResult SignupStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignupStudent(Student student)
        {
            if (student.Password == student.ConfirmPassword)
            {
                _dbContext.Students.Add(student);
                _dbContext.SaveChanges();
                TempData["SuccessMessage"] = "SignUp successful";
                return View();
            }
            else
            {
                TempData["ComparePwd"] = "The password and confirmation password should match.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult StudentLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StudentLogin(Student student)
        {
            var std = _dbContext.Students.FirstOrDefault(s => s.StudentEmail == student.StudentEmail && s.Password == student.Password);
            if (std != null)
            {
                TempData["id"] = std.StudentId;
                return RedirectToAction("StartTest");
            }
            else
            {
                TempData["loginfailed"] = "Invalid Credentials";
                return View();
            }
        }
    }

}

