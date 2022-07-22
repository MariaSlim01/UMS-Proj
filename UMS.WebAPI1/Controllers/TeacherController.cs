using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application1.DTO;
using UMS.Application1.TeacherPerCourse.Commands.TeacherPerCourseCreate;

namespace UMS.WebAPI1.Controllers;

public class TeacherController : ControllerBase
{
    private readonly IMediator _mediator;
   

    private readonly ILogger<TeacherController> _logger;

    public TeacherController(ILogger<TeacherController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;


    }
    [HttpPost("ChooseCourse")]

    public Task<TeacherPerCourseRequest> ChooseCourse([FromBody] TeacherPerCourseCreateCommand req1)
    {
       
        var result = _mediator.Send(req1);
        return result;

    }
}