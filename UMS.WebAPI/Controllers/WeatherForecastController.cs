using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Configuration.DTO;

    [Route("[controller]")]
    
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
    
    
    
        [HttpPost("CreateCourse")]
        public Task<CourseCreate> ChangeReporter([FromBody] CourseCreate course)
        {
            return null;
        }
    }
