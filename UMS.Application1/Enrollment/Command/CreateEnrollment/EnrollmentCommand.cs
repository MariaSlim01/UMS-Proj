using MediatR;
using UMS.Application1.DTO;

namespace UMS.Application1.Enrollment.Command.CreateEnrollment;

public class EnrollmentCommand: IRequest <EnrollmentDTO>
{
    public EnrollmentDTO enrollment { get; set; }
}