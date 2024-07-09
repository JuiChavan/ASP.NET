using Microsoft.AspNetCore.Http.HttpResults;
using SMSApi.Entity;
using System.Net;
namespace SMSApi.Repository
{
    public class StudentRepository
    {
        public static List<Student> GetStudents() {
            using (var context = new StudentCollectionContext()) {
                var slist = from student
                        in context.student
                            select student;
                return slist.ToList<Student>();

            }
        }

        public static Student Insert(Student s) {
            using (var context = new StudentCollectionContext()) {
                context.Add(s);
                context.SaveChanges();
                Console.WriteLine("Student added");
                Student sobj=context.student.Find(s.Id);
                return sobj;
            }
        }

        public static List<Student> FindByStatus(string status){
            using (var context=new StudentCollectionContext()) {
                var slist = from student
                          in context.student
                            where student.Status == status
                            select student;
                return slist.ToList<Student>();
            }
        }

        public static Student FindByStudentId(int id) {
            using (var context=new StudentCollectionContext()) {
                var student = context.student.FirstOrDefault(s=>s.Id==id);
                return (Student)student;
            }
        }

        public static Student UpdateStudent(Student s)
        {
            Student oldStudent = null;
            using (var context = new StudentCollectionContext())
            {   Boolean flag=context.student.Any(s=>s.Id== s.Id);
                if (flag == null) {
                    return null;
                }
                oldStudent=context.student.Find(s.Id);
                if (oldStudent != null)
                {
                    oldStudent.Id = s.Id;
                    oldStudent.Address = s.Address;
                    oldStudent.Status= s.Status;
                    oldStudent.Fees= s.Fees;    
                    oldStudent.Email= s.Email;
                    oldStudent.Name= s.Name;
                    oldStudent.Phone= s.Phone;
                    oldStudent.AddmissionDate= s.AddmissionDate;
                    context.SaveChanges();
                    return oldStudent;
                }

            }
            return oldStudent;
        }
        public static Student DeleteStudentById(int id)
        {
            Student deletedStudent = null;
            using (var contex = new StudentCollectionContext()) {
                Boolean Flag = contex.student.Any(student=>student.Id==id);

                if (Flag == false) {
                    return  null;
                }
                deletedStudent = contex.student.Find(id);
                contex.Remove(deletedStudent);
                contex.SaveChanges();
                return deletedStudent;
            }

            return deletedStudent;

        }

        public static List<Student> Sort() {
            using (var context = new StudentCollectionContext())
            {
                var students = context.student.OrderByDescending(s => s.Status).ToList();
                return students.ToList<Student>();
            }
        }
    }     
}


