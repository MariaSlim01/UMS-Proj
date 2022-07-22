namespace UMS.Application1.DTO;

public class TeacherPerCourseRequest
{
    public long TeacherId { get; set; }
    public long CourseId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}