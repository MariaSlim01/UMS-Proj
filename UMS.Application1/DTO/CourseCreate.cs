namespace UMS.Application1.DTO;

public class CourseCreate
{
    public string? Name { get; set; }
    public int? MaxStudentsNumber { get; set; } 
    public DateTime start { get; set; }
    public DateTime end { get; set; }

}