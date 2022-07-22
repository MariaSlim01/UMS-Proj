using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using UMS.Application1.Course.Query;
using UMS.Application1.DTO;
using UMS.Application1.Enrollment.Command.CreateEnrollment;
using UMS.Application1.TeacherPerCourse.Commands.TeacherPerCourseCreate;

namespace UMS.WebAPI1.Controllers;

public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;
   

    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;


    }
    
    [HttpPost("Enroll")]

    public async Task<EnrollmentDTO> Enroll([FromBody] EnrollmentCommand req1)
    {
        
        
        var result = await _mediator.Send(req1);
        return result;

    }
    
    [EnableQuery]
    [HttpGet("GetCourseByID")]

    public async Task<CourseCreate> Enroll([FromHeader] long id)
    {

        CourseGetByIDQuery query = new CourseGetByIDQuery()
        {
            Id = id
        };
        var result = await _mediator.Send(query);
        return result;

    }

    
}