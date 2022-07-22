using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using NpgsqlTypes;
using UMS.Application1.DTO;
using UMS.Domain.Models;
using WebApplication4.Models;

namespace UMS.WebAPI1.Controllers;

public class DataController:ODataController
{
    public postgresContext _dbContext;
    private readonly ILogger<DataController> _logger;
    public readonly IMapper _mapper;

    
    public DataController(postgresContext dbContext,ILogger<DataController> logger,IMapper mapper)
    {
        _dbContext = dbContext;
        _logger = logger;
        _mapper = mapper;
    }
    
    
    [EnableQuery]
    [HttpGet("Get-Users")]

    public IQueryable<User> GetUsers()
    {

       IQueryable<User> users= _dbContext.Users;
       _dbContext.SaveChanges();

       return users;

    }
    
    [EnableQuery]
    [HttpPost("Create-Course")]

    public async Task<IActionResult> Post([FromBody] CourseCreate coursedto)
    {
        Course course = new Course()
        {
            Name = coursedto.Name,
            MaxStudentsNumber= coursedto.MaxStudentsNumber,
            EnrolmentDateRange = new NpgsqlRange<DateOnly>(DateOnly.FromDateTime(coursedto.start),DateOnly.FromDateTime(coursedto.end)) ,

        };
        _dbContext.Courses.Add(course);
        await _dbContext.SaveChangesAsync();
        return Created(course);
    }
    
    [EnableQuery]
    [HttpGet("Get-Courses")]

    public IQueryable<Course> GetCourses()
    {

        IQueryable<Course> courses= _dbContext.Courses;
        _dbContext.SaveChanges();

        return courses;

    }

    [EnableQuery]
    [HttpGet("Get-Enrollments")]

    public IQueryable<ClassEnrollment> GetEnrollments()
    {

        IQueryable<ClassEnrollment> enrollments= _dbContext.ClassEnrollments;
        _dbContext.SaveChanges();

        return enrollments;

    }

    
}