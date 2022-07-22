using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application1.Course.Commands.CourseCreate;
using UMS.Application1.Course.Commands.CourseUpdate;
using UMS.Application1.DTO;
using UMS.Application1.Role;

namespace UMS.WebAPI1.Controllers;

public class AdminController : ControllerBase
{
    private readonly IMediator _mediator;
   

    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;


    }
    
    [HttpPost("CreateCourse")]
    public async Task<CourseCreate> CreateCourse([FromBody] CourseCreateCommand command)
    {
        
        var result = await _mediator.Send(command);
        return result;

    }
    
    [HttpPut("UpdateCourse")]
    public async Task<CourseCreate> Update([FromBody] CourseUpdateCommand command)
    {
        
        var result = await _mediator.Send(command);
        return result;

    }
    
    [HttpPost("RoleCreate")]

    public Task<string> ChooseCourse([FromBody] RoleCreateCommand req1)
    {
       
        var result = _mediator.Send(req1);
        return result;

    }
    
}