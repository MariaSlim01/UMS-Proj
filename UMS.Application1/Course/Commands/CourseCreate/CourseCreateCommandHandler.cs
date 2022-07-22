using AutoMapper;
using MediatR;
using NpgsqlTypes;
using WebApplication4.Models;
using static System.TimeOnly;

namespace UMS.Application1.Course.Commands.CourseCreate;

public class CourseCreateCommandHandler : IRequestHandler<CourseCreateCommand, DTO.CourseCreate>
{
    private readonly postgresContext _dbContext;
    public readonly IMapper _mapper;


    public CourseCreateCommandHandler(postgresContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<DTO.CourseCreate> Handle(CourseCreateCommand request, CancellationToken cancellationToken)
    {

        Domain.Models.Course c = new Domain.Models.Course()
        {
            Name = request.Name,
            MaxStudentsNumber= request.MaxStudentsNumber,
            EnrolmentDateRange = new NpgsqlRange<DateOnly>(DateOnly.FromDateTime(request.start),DateOnly.FromDateTime(request.end)) ,

        };
        
        
        await _dbContext.Courses.AddAsync(c);
        _dbContext.SaveChanges();
        return null;
        
    }
}
