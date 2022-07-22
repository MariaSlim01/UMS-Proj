using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using UMS.Application1.DTO;
using UMS.Application1.Role;
using WebApplication4.Models;

namespace UMS.Application1.Students.Commands;

public class GetStudentEmailsByClassIdHandler : IRequestHandler<GetStudentEmailsByClassId, List<string>>
{
    private readonly postgresContext _dbContext;
    public readonly IMapper _mapper;


    public GetStudentEmailsByClassIdHandler(postgresContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<string>>Handle(GetStudentEmailsByClassId request, CancellationToken cancellationToken)
    {
        var teacher_per_course_id = 
            _dbContext.TeacherPerCourses.Where(p => p.CourseId == request.id)
                .Select(p=>p.Id).ToList();

        List<long> studentIds = new List<long>();
        
        foreach (var id in teacher_per_course_id)
        {
            var studentIds1= 
                _dbContext.ClassEnrollments.Where(p => p.ClassId == id)
                    .Select(p=>p.StudentId).ToList();
            studentIds = studentIds.Concat(studentIds1).ToList();
        }

        List<string> emails = new List<string>();
        
        foreach (var id in studentIds)
        {
           string email= _dbContext.Users.Where(p => p.Id == id).SingleOrDefault().Email;
           emails.Append(email);
        }

        return emails;
    }
}