using InterView.Models;

namespace InterView.Services
{
    public class StudentService
    {
        public readonly StudentDbContext _studentContext;
        public StudentService(StudentDbContext studentContext)
        {
            this._studentContext = studentContext;
        }

        public List<Student> GetAllStudents()
        {
            return _studentContext.Students.ToList();
        }
        public void AddStudent(Student student)
        {
            _studentContext.Students.Add(student);
            _studentContext.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            _studentContext.Students.Update(student);
            _studentContext.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
           var student= _studentContext.Students.Find(id);
            if (student != null)
            {
                _studentContext.Students.Remove(student);
                _studentContext.SaveChanges();
            }
        }
    }
}
