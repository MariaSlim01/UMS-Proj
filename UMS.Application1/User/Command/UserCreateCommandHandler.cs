using AutoMapper;
using MediatR;
using UMS.Application1.Course.Commands.CourseCreate;
using UMS.Application1.DTO;
using UMS.Domain.Models;
using UMS.Persistence;
using WebApplication4.Models;

namespace UMS.Application1.User.Command;

public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, UserCreate>
{

    private readonly postgresContext _dbContext;
    public readonly IMapper _mapper;


    public UserCreateCommandHandler(postgresContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UserCreate> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.User user = new Domain.Models.User()
        {
        Name= request.user.Name,
        Email=request.user.Email,
        RoleId = _dbContext.Roles.Where(p=>p.Name==request.user.Role).FirstOrDefault().Id,
        KeycloakId = request.KeycloakId
        };
        await _dbContext.Users.AddAsync(user);
        _dbContext.SaveChanges();
        return request.user;
    }
}