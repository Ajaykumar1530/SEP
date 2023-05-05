using InterView.Models;

namespace InterView.Services
{
    public class McqsService
    {
        private readonly StudentDbContext _db;

        public McqsService(StudentDbContext db)
        {
            _db = db;
        }
        public List<MCQsQuestions> GetAllQuestions()
        {
            return _db.MCQsQuestions.ToList();
        }
    }
}
