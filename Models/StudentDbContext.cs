using Microsoft.EntityFrameworkCore;

namespace InterView.Models
{
    public class StudentDbContext:DbContext
    {
       

        public StudentDbContext(DbContextOptions<StudentDbContext>options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<MCQsQuestions> MCQsQuestions { get; set; }
        public DbSet<CandidatesList> CandidatesList { get; set; }   
        public DbSet<Admin> Admin { get; set; }   
    }
}
