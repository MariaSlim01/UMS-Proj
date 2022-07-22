using AutoMapper;
using MediatR;
using UMS.Application1.DTO;
using UMS.Domain.Models;
using UMS.Infrastructure;
using UMS.Infrastructure.Abstraction.Mail;
using WebApplication4.Models;


namespace UMS.Application1.Enrollment.Command.CreateEnrollment;

public class EnrollmentRequestHandler : IRequestHandler<EnrollmentCommand, EnrollmentDTO>
{


    private readonly postgresContext _dbContext;
    public readonly IMapper _mapper;
    public readonly IMailService _mailService;

    public EnrollmentRequestHandler(postgresContext dbContext, IMapper mapper, IMailService mailService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _mailService = mailService;

    }

    public async Task<EnrollmentDTO> Handle(EnrollmentCommand request, CancellationToken cancellationToken)
    {
        
        var class_id = _dbContext.TeacherPerCourses
            .Where(x => x.Id == request.enrollment.ClassId).SingleOrDefault().CourseId;

        var date = _dbContext.Courses.Where(x => x.Id == class_id).SingleOrDefault()
            ?.EnrolmentDateRange;

        var courseName = _dbContext.Courses.Where(x => x.Id == class_id).SingleOrDefault()
            .Name;

        DateOnly recentdate = DateOnly.FromDateTime(DateTime.Now);

        bool exists = _dbContext.ClassEnrollments.Any
        (p => p.ClassId == request.enrollment.ClassId &&
              p.StudentId == request.enrollment.StudentId);

        if (recentdate < date.Value.UpperBound && recentdate > date.Value.LowerBound && exists == false)
        {
            ClassEnrollment c = new ClassEnrollment()
            {
                ClassId = request.enrollment.ClassId,
                StudentId = request.enrollment.StudentId
            };
            _dbContext.AddAsync(c);
            _dbContext.SaveChanges();




            long std_id = request.enrollment.StudentId;

            MailRequest mailrequest = new MailRequest()
            {
                ToEmail = _dbContext.Users.Where(p => p.Id == std_id).FirstOrDefault().Email,
                Subject = "new enrollment  ",
                Body = "you have enrolled in a new class "
            };


            await _mailService.SendEmailAsync(mailrequest);

        }

        return request.enrollment;

    }
}



