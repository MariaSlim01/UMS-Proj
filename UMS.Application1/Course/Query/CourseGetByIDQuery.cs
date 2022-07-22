using MediatR;
using UMS.Application1.DTO;

namespace UMS.Application1.Course.Query;

public class CourseGetByIDQuery:IRequest <CourseCreate>
{
    public long Id { get; set; }
}