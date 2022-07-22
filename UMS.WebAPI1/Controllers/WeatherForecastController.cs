// using MediatR;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.OData.Formatter;
// using Microsoft.AspNetCore.OData.Query;
// using UMS.Application1.Course.Commands.CourseCreate;
// using UMS.Application1.Course.Query;
// using UMS.Application1.DTO;
// using UMS.Application1.Enrollment.Command.CreateEnrollment;
// using UMS.Application1.Role;
// using UMS.Application1.TeacherPerCourse.Commands.TeacherPerCourseCreate;
// using UMS.Application1.User.Command;
// using UMS.Domain.Models;
//
// namespace UMS.WebAPI1.Controllers;
//
// [ApiController]
// [Route("[controller]")]
// public class WeatherForecastController : ControllerBase
// {
//     private readonly IMediator _mediator;
//    
//
//     private readonly ILogger<WeatherForecastController> _logger;
//
//     public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
//     {
//         _logger = logger;
//         _mediator = mediator;
//
//
//     }
//     private static readonly string[] Summaries = new[]
//     {
//         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//     };
//     [HttpGet(Name = "GetWeatherForecast")]
//     [EnableQuery]
//     public IEnumerable<WeatherForecast> Get()
//     {
//         return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//             {
//                 Date = DateTime.Now.AddDays(index),
//                 TemperatureC = Random.Shared.Next(-20, 55),
//                 Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//             })
//             .ToArray();
//     }
//
//     
//     
//     [HttpPost("CreateCourse")]
//     public async Task<CourseCreate> CreateCourse([FromBody] CourseCreateCommand command)
//     {
//         
//         var result = await _mediator.Send(command);
//         return result;
//
//     }
//     [HttpPost("ChooseCourse")]
//
//     public Task<TeacherPerCourseRequest> ChooseCourse([FromBody] TeacherPerCourseCreateCommand req1)
//     {
//        
//         var result = _mediator.Send(req1);
//         return result;
//
//     }
//     
//     [HttpPost("UserCreate")]
//
//     public Task<UserCreate> CreateUser([FromBody] UserCreateCommand req1)
//     {
//        
//         var result = _mediator.Send(req1);
//         return result;
//
//     }
//     
//     [HttpPost("RoleCreate")]
//
//     public Task<string> ChooseCourse([FromBody] RoleCreateCommand req1)
//     {
//        
//         var result = _mediator.Send(req1);
//         return result;
//
//     }
//     [HttpPost("Enroll")]
//
//     public async Task<EnrollmentDTO> Enroll([FromBody] EnrollmentCommand req1)
//     {
//         
//         
//         var result = await _mediator.Send(req1);
//         return result;
//
//     }
//     
//     [EnableQuery]
//     [HttpGet("GetCourseByID")]
//
//     public async Task<CourseCreate> Enroll([FromHeader] long id)
//     {
//
//         CourseGetByIDQuery query = new CourseGetByIDQuery()
//         {
//             Id = id
//         };
//         var result = await _mediator.Send(query);
//         return result;
//
//     }
//     
//     
// }
