using InterView.Models;
using Microsoft.AspNetCore.Mvc;

namespace InterView.Controllers
{
    public class CandidatesListController : Controller
    {
        private readonly StudentDbContext _StudentDbContext;
        public CandidatesListController(StudentDbContext studentDbContext)
        {
            this._StudentDbContext = studentDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllCandidates()
        {
            var candidates = _StudentDbContext.CandidatesList.ToList();
            return View(candidates);
        }
        [HttpGet]
        public IActionResult AddCandidate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCandidate(CandidatesList candidate, IFormFile Resume, IFormFile Image)
        {
            //To Upload Resume
            if (Resume != null && Resume.Length > 0)
            {
                // Read the uploaded file into a byte array
                using (var memoryStream = new MemoryStream())
                {
                    await Resume.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    candidate.Resume = fileBytes;
                }
            }
            //To upload Image
            if (Image != null && Image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await Image.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    candidate.Image = fileBytes;
                }
            }

            _StudentDbContext.CandidatesList.Add(candidate);
            await _StudentDbContext.SaveChangesAsync();

            TempData["message"] = "Candidate added successfully";
            return View();

        }

        //Action Method for Downloading Resume
        public IActionResult DownloadResume(int id)
        {
            // Get the candidate from the database
            var candidate = _StudentDbContext.CandidatesList.Find(id);
            if (candidate == null || candidate.Resume == null)
            {
                return NotFound();
            }

            // Return the resume file as a download
            var resumeStream = new MemoryStream(candidate.Resume);
            //  return File(resumeStream, "application/pdf", $"{candidate.CandidateName}_Resume.pdf");
            return File(candidate.Resume, "application/msword", $"{candidate.CandidateName}'s Resume.doc");

        }
        //Action Mehtod for DownLoading Image
        public IActionResult DownloadImage(int id)
        {
            var candidate = _StudentDbContext.CandidatesList.FirstOrDefault(c => c.Id == id);

            if (candidate == null || candidate.Image == null)
            {
                return NotFound();
            }

            var ms = new MemoryStream(candidate.Image);

            return File(candidate.Image, "image/jpeg",$"{ candidate.CandidateName}'s Img.jpg");
        }
      /*  public IActionResult GetImage(int id)
        {
            var candidate = _StudentDbContext.CandidatesList.Find(id);
            if (candidate != null && candidate.Image != null)
            {
                return File(candidate.Image, "image/jpeg");
            }
            else
            {
                return NotFound();
            }
        }*/
    }
}
