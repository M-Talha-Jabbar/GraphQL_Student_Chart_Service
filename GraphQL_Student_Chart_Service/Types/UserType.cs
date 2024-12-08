using GraphQL.Types;
using GraphQL_Student_Chart_Service.Models;

namespace GraphQL_Student_Chart_Service.Types
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Field(x => x.Username);
            Field(x => x.Token);
        }
    }
}
