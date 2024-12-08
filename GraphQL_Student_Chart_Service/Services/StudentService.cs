using GraphQL_Student_Chart_Service.Interfaces;

namespace GraphQL_Student_Chart_Service.Services
{
    public class StudentService : IStudentInterface
    {
        public StudentService() { }

        public List<Student> GetStudents()
        {
            return DataLoader.GetStudents();
        }

        public Student GetStudentById(int id)
        {
            return DataLoader.GetStudents().FirstOrDefault(s => s.Id == id);
        }

        public Student AddStudent(Student newStudent)
        {
            newStudent.Id = DataLoader.GetStudents().Max(s => s.Id) + 1;
            DataLoader.AddStudent(newStudent);
            return newStudent;
        }
    }
}
