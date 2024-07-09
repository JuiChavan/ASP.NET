using SMSApi.Entity;
namespace SMSApi.Service
{
    public interface IStudentService
    {
        List<Student> GetAll();
        public Student Insert(Student s);
        public List<Student> GetByStatus(string Status);
        public Student GetById(int id);
        public Student Update(Student s);
        public Student Delete(int id);
        public List<Student> Sort();
    }
}
