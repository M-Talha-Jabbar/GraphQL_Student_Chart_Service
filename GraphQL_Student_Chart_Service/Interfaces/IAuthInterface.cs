using GraphQL_Student_Chart_Service.Models;

namespace GraphQL_Student_Chart_Service.Interfaces
{
    public interface IAuthInterface
    {
        User Login(string username, string password);
    }
}
