using GraphQL.Types;
using GraphQL_Student_Chart_Service.Models;

namespace GraphQL_Student_Chart_Service.Types
{
    public class WaiverCountType : ObjectGraphType<WaiverCount>
    {
        public WaiverCountType()
        {
            Field(x => x.WithWaiver);
            Field(x => x.WithoutWaiver);
        }
    }
}
