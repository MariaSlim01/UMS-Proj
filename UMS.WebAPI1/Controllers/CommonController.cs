using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application1.DTO;
using UMS.Application1.User.Command;

namespace UMS.WebAPI1.Controllers;

 public class CommonController : ControllerBase
    {
        private readonly IMediator _mediator;
   

        private readonly ILogger<CommonController> _logger;

        public CommonController(ILogger<CommonController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;


        }
        
        [HttpPost("UserCreate")]

        public Task<UserCreate> CreateUser([FromBody] UserCreateCommand req1)
        {
       
            var result = _mediator.Send(req1);
            return result;

        }
}