using MediatR;
using UMS.Application1.DTO;

namespace UMS.Application1.User.Command;

public class UserCreateCommand: IRequest<UserCreate>
{
    public UserCreate user { get; set; }
    
    public string KeycloakId { get; set; } 

}