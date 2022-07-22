using MediatR;

namespace UMS.Application1.Role;

public class RoleCreateCommand: IRequest<string>
{
    public string role { get; set; }
}