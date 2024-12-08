using GraphQL;
using GraphQL.Types;
using GraphQL_Student_Chart_Service.Interfaces;
using GraphQL_Student_Chart_Service.Models;
using GraphQL_Student_Chart_Service.Types;

namespace GraphQL_Student_Chart_Service.Queries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IStudentInterface studentInterface)
        {
            Name = "Query";


            Field<ListGraphType<StudentType>>("students")
                .Description("Retrieve all students")
                .AuthorizeWithPolicy("Trusted") 
                .Resolve(context => studentInterface.GetStudents());


            Field<StudentType>("student")
                .Description("Retrieve a student by their ID")
                .AuthorizeWithPolicy("Trusted")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Resolve(context => studentInterface.GetStudentById(context.GetArgument<int>("id")));


            Field<ListGraphType<StudentType>>("studentsByEnrolledYear")
                .Description("Retrieve students by their enrolled year")
                .AuthorizeWithPolicy("Trusted")
                .Argument<NonNullGraphType<IntGraphType>>("year")
                .Resolve(context => studentInterface.GetStudents().Where(s => s.EnrolledYear == context.GetArgument<int>("year")));


            Field<ListGraphType<StudentType>>("studentsWithWaiver")
                .Description("Retrieve students who are eligible for a waiver")
                .AuthorizeWithPolicy("Trusted")
                .Resolve(context => studentInterface.GetStudents().Where(s => s.IsWaiverApplicable));


            Field<IntGraphType>("totalStudents")
                .Description("Get the total number of students")
                .AuthorizeWithPolicy("Trusted")
                .Resolve(context => studentInterface.GetStudents().Count);


            Field<ListGraphType<StudentType>>("studentsByCountry")
                .Description("Retrieve students by their country")
                .AuthorizeWithPolicy("Trusted")
                .Argument<StringGraphType>("country", "Country of the student")
                .Resolve(context => studentInterface.GetStudents().Where(s => s.Country.Equals(context.GetArgument<string>("country"), StringComparison.OrdinalIgnoreCase)));


            Field<ListGraphType<StudentType>>("filteredStudents")
                .Description("Retrieve students filtered by country, enrolled year, and waiver status")
                .AuthorizeWithPolicy("Trusted")
                .Argument<StringGraphType>("country")
                .Argument<IntGraphType>("enrolledYear")
                .Argument<BooleanGraphType>("isWaiverApplicable")
                .Resolve(context => {
                    var country = context.GetArgument<string>("country");
                    var enrolledYear = context.GetArgument<int?>("enrolledYear");
                    var isWaiverApplicable = context.GetArgument<bool?>("isWaiverApplicable");

                    return studentInterface.GetStudents()
                        .Where(s => (string.IsNullOrEmpty(country) || s.Country.Equals(country, StringComparison.OrdinalIgnoreCase)) &&
                                    (!enrolledYear.HasValue || s.EnrolledYear == enrolledYear) &&
                                    (!isWaiverApplicable.HasValue || s.IsWaiverApplicable == isWaiverApplicable))
                        .ToList();
                });


            Field<WaiverCountType>("waiverCountByYear")
                .Description("Retrieve the count of students with and without waiver in a specified enrollment year")
                .AuthorizeWithPolicy("Trusted")
                .Argument<NonNullGraphType<IntGraphType>>("year")
                .Resolve(context =>
                {
                    var year = context.GetArgument<int>("year");
                    var studentsInYear = studentInterface.GetStudents().Where(s => s.EnrolledYear == year).ToList();

                    return new WaiverCount
                    {
                        WithWaiver = studentsInYear.Count(s => s.IsWaiverApplicable),
                        WithoutWaiver = studentsInYear.Count(s => !s.IsWaiverApplicable)
                    };
                });


            Field<StudentCountType>("studentCountByYear")
                .Description("Retrieve the count of national (USA) and international students in a specified enrollment year")
                .AuthorizeWithPolicy("Trusted")
                .Argument<NonNullGraphType<IntGraphType>>("year")
                .Resolve(context =>
                {
                    var year = context.GetArgument<int>("year");
                    var studentsInYear = studentInterface.GetStudents().Where(s => s.EnrolledYear == year).ToList();

                    return new StudentCount
                    {
                        National = studentsInYear.Count(s => s.Country.Equals("United States of America", StringComparison.OrdinalIgnoreCase)),
                        International = studentsInYear.Count(s => !s.Country.Equals("United States of America", StringComparison.OrdinalIgnoreCase))
                    };
                });
        }
    }
}
