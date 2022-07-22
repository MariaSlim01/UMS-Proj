using MediatR;
using UMS.Application1.DTO;

namespace UMS.Application1.TeacherPerCourse.Commands.TeacherPerCourseCreate;

public class TeacherPerCourseCreateCommand: IRequest <TeacherPerCourseRequest>
{
    public TeacherPerCourseRequest req { get; set; }


}