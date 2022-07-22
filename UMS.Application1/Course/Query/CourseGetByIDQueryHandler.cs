using AutoMapper;
using MediatR;
using UMS.Application1.DTO;
using WebApplication4.Models;

namespace UMS.Application1.Course.Query;

public class CourseGetByIDQueryHandler : IRequestHandler<CourseGetByIDQuery, DTO.CourseCreate>
{
    private readonly postgresContext _dbContext;
    public readonly IMapper _mapper;


    public CourseGetByIDQueryHandler(postgresContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<DTO.CourseCreate> Handle(CourseGetByIDQuery request, CancellationToken cancellationToken)
    {
        var course = _dbContext.Courses.Where(p => p.Id == request.Id).FirstOrDefault();
        Domain.Models.Course course1 = (Domain.Models.Course)course;
        CourseCreate course_conv = _mapper.Map<CourseCreate>(course1);
        return course_conv;
    }
}