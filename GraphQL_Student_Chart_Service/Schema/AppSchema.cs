using GraphQL.Types;
using GraphQL_Student_Chart_Service.Mutations;
using GraphQL_Student_Chart_Service.Queries;

namespace GraphQL_Student_Chart_Service.Schema
{
    public class AppSchema : GraphQL.Types.Schema
    {
        public AppSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<AppQuery>();
            Mutation = serviceProvider.GetRequiredService<AppMutation>();
        }
    }
}
