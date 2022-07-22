using MediatR;

namespace UMS.Application1.Course.Commands.CourseUpdate;

public class CourseUpdateCommand: IRequest <DTO.CourseCreate>
{
    public long id { get; set; }
    public string? Name { get; set; }
    public int? MaxStudentsNumber { get; set; }
    public DateTime start { get; set; }
    public DateTime end { get; set; }
    
}
