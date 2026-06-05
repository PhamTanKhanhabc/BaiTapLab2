namespace DapperApi.Models;

public class Course
{
    public int Id { get; set; }
    public string CourseName { get; set; } = string.Empty;
}

public class StudentWithCourses
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Course> Courses { get; set; } = new();
}