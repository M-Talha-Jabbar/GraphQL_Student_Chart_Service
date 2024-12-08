using GraphQL.Types;

namespace GraphQL_Student_Chart_Service.Types
{
    public class StudentType : ObjectGraphType<Student>
    {
        public StudentType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Email);
            Field(x => x.Phone);
            Field(x => x.Country);
            Field(x => x.DateOfBirth);
            Field<ListGraphType<StringGraphType>>(nameof(Student.Terms));
            Field<ListGraphType<StringGraphType>>(nameof(Student.Courses));
            Field(x => x.EnrolledYear);
            Field(x => x.IsWaiverApplicable);
            Field(x => x.VPDI);
        }
    }
}
