// using AutoMapper;
// using MediatR;
// using NpgsqlTypes;
// using UMS.Application1.Course.Commands.CourseCreate;
// using UMS.Application1.Hubs;
// using UMS.Application1.Students.Commands;
// using UMS.Infrastructure.Abstraction.Mail;
// using UMS.Infrastructure.Mail;
// using WebApplication4.Models;
//
// namespace UMS.Application1.Course.Commands.CourseUpdate;
//
// public class CourseUpdateCommandHandler: IRequestHandler<CourseUpdateCommand, DTO.CourseCreate>
// {
//     private readonly postgresContext _dbContext;
//     public readonly IMapper _mapper;
//     private readonly MailService _mailService;
//     private readonly NotificationHub _notificationHub;
//
//     public CourseUpdateCommandHandler(postgresContext dbContext, IMapper mapper,MailService mailService,NotificationHub notificationHub)
//     {
//         _dbContext = dbContext;
//         _mapper = mapper;
//         _mailService = mailService;
//         _notificationHub = notificationHub;
//     }
//
//     public async Task<DTO.CourseCreate> Handle(CourseUpdateCommand request, CancellationToken cancellationToken)
//     {
//
//         long old_id = request.id;
//         Domain.Models.Course toBeRemoved = _dbContext.Courses.Where(p => p.Id == request.id).FirstOrDefault();
//
//
//
//         toBeRemoved.Name = request.Name;
//         toBeRemoved.MaxStudentsNumber = request.MaxStudentsNumber;
//         toBeRemoved.EnrolmentDateRange = new NpgsqlRange<DateOnly>(DateOnly.FromDateTime(request.start), DateOnly.FromDateTime(request.end));
//
//        // var emails=await _mediator.Send(new GetStudentEmailsByClassId() { id = old_id }); 
//        //
//        // foreach (var email in emails)
//        //  {
//        //      MailRequest mailrequest = new MailRequest()
//        //      {
//        //          ToEmail = email,
//        //          Subject = "the course was updated",
//        //          Body = "the course was updated "
//        //      };
//        //  
//        //
//        //       _mailService.SendEmailAsync(mailrequest);
//        //
//        //      var studentId = _dbContext.Users.Where(p => p.Email == email).SingleOrDefault().Id;
//        //      _notificationHub.SendNotifications(studentId,"course updated");
//        //
//        //  }
//         _dbContext.SaveChanges();
//         return null;
//         
//     }
// }
