using AutoMapper;
using MediatR;
using UMS.Application1.Course.Commands.CourseCreate;
using WebApplication4.Models;

namespace UMS.Application1.Role;

public class RoleCreateCommandHandler : IRequestHandler<RoleCreateCommand, string>
{
    private readonly postgresContext _dbContext;
    public readonly IMapper _mapper;


    public RoleCreateCommandHandler(postgresContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<string> Handle(RoleCreateCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Role r = new Domain.Models.Role()
        {
            Name = request.role
        };
        await _dbContext.AddAsync(r);
        _dbContext.SaveChanges();
        return request.role;
    }
}