using SMSApi.Controllers;
using SMSApi.Entity;
using SMSApi.Repository;
using System.Security.Cryptography.Xml;
using SMSApi.Exceptions;
namespace SMSApi.Service
{
    public class StudentService : IStudentService
    { 
        public List<Student> GetAll()
        {
            return StudentRepository.GetStudents();
        }

        public Student  Insert(Student s) {
           Student sobj= StudentRepository.Insert(s);
            return sobj;
        }

        public List<Student> GetByStatus(string Status) {
            return StudentRepository.FindByStatus(Status) ;
        }

        public  Student GetById(int id) {
            return StudentRepository.FindByStudentId(id);
        }

        public Student Update(Student s) {
            Student sobj=StudentRepository.UpdateStudent(s);
            if (sobj == null) {
                throw new StudentException("Student not found");
            }
            return sobj;
        }

        public Student Delete(int id) { 
            Student s= StudentRepository.DeleteStudentById(id);
            if (s == null) {
                throw new StudentException("Student not found");
            }
            return s;
        }

        public List<Student> Sort() {
            List<Student> slist = StudentRepository.Sort();
            if (slist == null) {
                throw new StudentException("Student list is empty");
            }
            return slist;
        }




    }
}

