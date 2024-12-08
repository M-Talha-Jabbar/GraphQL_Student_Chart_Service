namespace GraphQL_Student_Chart_Service.Interfaces
{
    public interface IStudentInterface
    {
        List<Student> GetStudents();
        Student GetStudentById(int id);
        Student AddStudent(Student newStudent);
    }
}
