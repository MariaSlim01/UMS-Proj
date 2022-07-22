using MediatR;

namespace UMS.Application1.Course.Commands.CourseCreate;

public class CourseCreateCommand: IRequest <DTO.CourseCreate>
{
    public string? Name { get; set; }
    public int? MaxStudentsNumber { get; set; }
    public DateTime start { get; set; }
    public DateTime end { get; set; }
    
}