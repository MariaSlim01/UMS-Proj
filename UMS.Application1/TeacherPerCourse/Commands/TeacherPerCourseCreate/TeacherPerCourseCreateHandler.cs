using AutoMapper;
using MediatR;
using UMS.Application1.DTO;
using UMS.Domain.Models;
using WebApplication4.Models;

namespace UMS.Application1.TeacherPerCourse.Commands.TeacherPerCourseCreate;

public class TeacherPerCourseCreateHandler : IRequestHandler<TeacherPerCourseCreateCommand, TeacherPerCourseRequest>
{


    private readonly postgresContext _dbContext;
    public readonly IMapper _mapper;


    public TeacherPerCourseCreateHandler(postgresContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TeacherPerCourseRequest> Handle(TeacherPerCourseCreateCommand request,
        CancellationToken cancellationToken)
    {
        

        bool exists = _dbContext.TeacherPerCourses.Any(p =>
            p.TeacherId == request.req.TeacherId
            && p.CourseId== request.req.CourseId);
        

       // long? sessionId = _dbContext.SessionTimes
         //   .Where(p => p.Id == sessionTime.Id)
          //  .SingleOrDefault()!.Id;
          
          bool exists1 = _dbContext.SessionTimes.Any(p =>
              p.StartTime == request.req.StartTime &&
              p.EndTime == request.req.EndTime);

        /*IQueryable<Domain.Models.TeacherPerCourse> teach =
            _dbContext.TeacherPerCourses
                .Where(p => p.TeacherId == teacherpCourse.TeacherId &&
                            p.CourseId == teacherpCourse.CourseId);

       IQueryable<SessionTime> s = _dbContext.SessionTimes
            .Where(p => p.StartTime == sessionTime.StartTime &&
                        p.EndTime == sessionTime.EndTime);*/

        if (exists==false)
        {
            Domain.Models.TeacherPerCourse teacherpcourse = new Domain.Models.TeacherPerCourse()
            {
                TeacherId = request.req.TeacherId,
                CourseId = request.req.CourseId
            };
            await _dbContext.TeacherPerCourses.AddAsync(teacherpcourse);
            _dbContext.SaveChanges();

        }



        if (exists1 == false)
        {
            Domain.Models.SessionTime sessionTime = new Domain.Models.SessionTime()
            {
                StartTime = request.req.StartTime,
                EndTime = request.req.EndTime
            };
            _dbContext.SessionTimes.AddAsync(sessionTime);
            _dbContext.SaveChanges();
        }

            
            
        
        long sessionId= _dbContext.SessionTimes.Where(p =>
                p.StartTime == request.req.StartTime &&
                p.EndTime == request.req.EndTime).FirstOrDefault().Id;

       
            
        long teacherpCourseId=_dbContext.TeacherPerCourses.Where(p =>
                p.TeacherId == request.req.TeacherId
                && p.CourseId== request.req.CourseId).FirstOrDefault().Id;
            
        bool exists3= _dbContext.TeacherPerCoursePerSessionTimes.Any(p =>
            p.TeacherPerCourseId == teacherpCourseId && p.SessionTimeId==sessionId);

        if (exists3 == false)
        {
            TeacherPerCoursePerSessionTime t = new TeacherPerCoursePerSessionTime()
            {
                TeacherPerCourseId = teacherpCourseId,
                SessionTimeId = sessionId

            };
            _dbContext.TeacherPerCoursePerSessionTimes.AddAsync(t);
            _dbContext.SaveChanges();
        }

        return request.req;
    }
}



