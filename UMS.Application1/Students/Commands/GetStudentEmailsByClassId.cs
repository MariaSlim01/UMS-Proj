using AutoMapper;
using MediatR;
using UMS.Application1.DTO;
using UMS.Application1.Role;
using WebApplication4.Models;

namespace UMS.Application1.Students.Commands;

public class GetStudentEmailsByClassId : IRequest<List<string>>
{
    public long id { get; set; }
}