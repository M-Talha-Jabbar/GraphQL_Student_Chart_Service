using GraphQL.Types;
using GraphQL_Student_Chart_Service.Models;

namespace GraphQL_Student_Chart_Service.Types
{
    public class StudentCountType : ObjectGraphType<StudentCount>
    {
        public StudentCountType()
        {
            Field(x => x.National);
            Field(x => x.International);
        }
    }
}
