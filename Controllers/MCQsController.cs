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
                TempData["Technology"] = std.Technology;
                TempData.Keep("Technology");
                return RedirectToAction("StartTest");
            }
            else
            {
                TempData["loginfailed"] = "Invalid Credentials";
                return View();
            }
        }
        [HttpGet]
        public IActionResult StartTest()
        {
            return View();
        }
        /*  public IActionResult GetAllQuestions()
          {
              var questions = _mcqsService.GetAllQuestions();
              return View(questions);
          }*/
        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            string tech = (string)TempData["Technology"];
            if (tech == "DOTNET")
            {
                var questions = _dbContext.MCQsQuestions.ToList();
                return View(questions);
            }
            else if (tech == "JAVA")
            {
                var questions = _dbContext.JavaMcqs.ToList();
                return View("JavaQuestions",questions);
            }
            else if (tech == "SALESFORCE")
            {
                var questions = _dbContext.SalesForceMcqs.ToList();
                return View("SalesForceQuestions", questions);
            }
            else if (tech == "DEVOPS")
            {
                var questions = _dbContext.DevopsMcqs.ToList();
                return View("DevopsQuestions", questions);
            }
            return View();
        }
        


        [HttpPost]
        public IActionResult GetAllQuestions(IFormCollection form)
        {
           
            int score = 0;
            var id = TempData["id"];
            var stid = _dbContext.Students.Find(id);
            foreach (var key in form.Keys)
            {
                if (int.TryParse(form[key], out int selectedOption))
                {
                    // Get the question ID from the form key
                    int questionId = int.Parse(key.Replace("question", ""));

                    // Get the correct answers of DOTNET from the database
                    if (stid.Technology == "DOTNET")
                    {
                     var  question = _dbContext.MCQsQuestions.FirstOrDefault(q => q.Id == questionId);
                        // Check if the selected option matches the correct answer
                        if (selectedOption == question.CorrectOption)
                        {
                            score++;
                        }
                    }
                    // Get the correct answers of Java from the database
                    else if (stid.Technology == "JAVA")
                    {
                    var question = _dbContext.JavaMcqs.FirstOrDefault(q => q.Id == questionId);
                        // Check if the selected option matches the correct answer
                        if (selectedOption == question.CorrectOption)
                        {
                            score++;
                        }
                    }
                    // Get the correct answers of SalesForce from the database
                    else if (stid.Technology == "SALESFORCE")
                    {
                        var question = _dbContext.SalesForceMcqs.FirstOrDefault(q => q.Id == questionId);
                        // Check if the selected option matches the correct answer
                        if (selectedOption == question.CorrectOption)
                        {
                            score++;
                        }
                    }
                    // Get the correct answers of Devops from the database
                    else if (stid.Technology == "DEVOPS")
                    {
                        var question = _dbContext.DevopsMcqs.FirstOrDefault(q => q.Id == questionId);
                        // Check if the selected option matches the correct answer
                        if (selectedOption == question.CorrectOption)
                        {
                            score++;
                        }
                    }
                    
                }
            }
            stid.Score = score;
            if (stid != null)
            {
                _dbContext.Students.Update(stid);
                _dbContext.SaveChanges();
            }
            return View("Logout");
        }
       
        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logout(Student student)
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ViewAllResult()
        {
            var students = _dbContext.Students.ToList();
            return View(students);
        }
    }

}

