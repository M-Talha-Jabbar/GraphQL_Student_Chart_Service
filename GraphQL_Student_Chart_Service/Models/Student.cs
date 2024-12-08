namespace GraphQL_Student_Chart_Service
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string DateOfBirth { get; set; }
        public string[] Terms { get; set; }
        public string[] Courses { get; set; }
        public int EnrolledYear { get; set; }
        public bool IsWaiverApplicable { get; set; }
        public string VPDI { get; set; }
    }
}
