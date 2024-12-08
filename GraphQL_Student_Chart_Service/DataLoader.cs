using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;

namespace GraphQL_Student_Chart_Service
{
    public static class DataLoader
    {
        private static List<Student> students = new List<Student>();

        static DataLoader()
        {
            LoadStudentsFromCsv();
        }

        public static List<Student> GetStudents()
        {
            return students;
        }

        public static void AddStudent(Student newStudent)
        {
            students.Add(newStudent);
        }

        public static void LoadStudentsFromCsv()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "DummyData", "students.csv");

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true, // specifies that the first row of the CSV file contains headers, not data
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            using (var reader = new StreamReader(filePath))
            {
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.GetRecords<dynamic>().ToList();

                    foreach (var record in records)
                    {
                        var student = new Student
                        {
                            Id = int.Parse(record.id),
                            Name = record.name,
                            Email = record.email,
                            Phone = record.phone,
                            Country = record.country,
                            DateOfBirth = record.dateofbirth,
                            EnrolledYear = int.Parse(record.enrolledyear),
                            IsWaiverApplicable = bool.Parse(record.iswaiverapplicable),
                            VPDI = record.vpdi,
                            Terms = record.terms?.ToString().Split(',', StringSplitOptions.RemoveEmptyEntries),
                            Courses = record.courses?.ToString().Split(',', StringSplitOptions.RemoveEmptyEntries)
                        };
                        students.Add(student);
                    }
                }
            }
        }
    }
}
