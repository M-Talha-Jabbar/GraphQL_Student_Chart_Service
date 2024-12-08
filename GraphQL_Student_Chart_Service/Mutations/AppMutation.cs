using GraphQL;
using GraphQL.Types;
using GraphQL_Student_Chart_Service.Interfaces;
using GraphQL_Student_Chart_Service.Types;
using System.Xml.Linq;

namespace GraphQL_Student_Chart_Service.Mutations
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IAuthInterface authInterface, IStudentInterface studentInterface)
        {
            Name = "Mutation";


            Field<UserType>("login")
                .Description("Log in with username and password")
                .Argument<NonNullGraphType<StringGraphType>>("username")
                .Argument<NonNullGraphType<StringGraphType>>("password")
                .Resolve(context =>
                {
                    var username = context.GetArgument<string>("username");
                    var password = context.GetArgument<string>("password");

                    var user = authInterface.Login(username, password);

                    if (user == null)
                    {
                        context.Errors.Add(new ExecutionError("Invalid username or password")); 
                        return null; 
                    }

                    return user;
                });


            Field<StudentType>("createStudent")
                .Description("Create a new student")
                .AuthorizeWithPolicy("Trusted")
                .Argument<NonNullGraphType<StringGraphType>>("name")
                .Argument<NonNullGraphType<StringGraphType>>("email")
                .Argument<NonNullGraphType<StringGraphType>>("phone")
                .Argument<NonNullGraphType<StringGraphType>>("country")
                .Argument<NonNullGraphType<StringGraphType>>("dateOfBirth")
                .Argument<ListGraphType<StringGraphType>>("terms")
                .Argument<ListGraphType<StringGraphType>>("courses")
                .Argument<NonNullGraphType<IntGraphType>>("enrolledYear")
                .Argument<NonNullGraphType<BooleanGraphType>>("isWaiverApplicable")
                .Argument<NonNullGraphType<StringGraphType>>("VPDI")
                .Resolve(context =>
                {
                    var name = context.GetArgument<string>("name");
                    var email = context.GetArgument<string>("email");
                    var phone = context.GetArgument<string>("phone");
                    var country = context.GetArgument<string>("country");
                    var dateOfBirth = context.GetArgument<string>("dateOfBirth");
                    var terms = context.GetArgument<string[]>("terms"); 
                    var courses = context.GetArgument<string[]>("courses"); 
                    var enrolledYear = context.GetArgument<int>("enrolledYear");
                    var isWaiverApplicable = context.GetArgument<bool>("isWaiverApplicable");
                    var vpdi = context.GetArgument<string>("VPDI");

                    var student = new Student
                    {
                        Name = name,
                        Email = email,
                        Phone = phone,
                        Country = country,
                        DateOfBirth = dateOfBirth,
                        Terms = terms, 
                        Courses = courses, 
                        EnrolledYear = enrolledYear,
                        IsWaiverApplicable = isWaiverApplicable,
                        VPDI = vpdi
                    };

                    return studentInterface.AddStudent(student);
                });
        }
    }
}
