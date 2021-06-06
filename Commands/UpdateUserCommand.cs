using DemoCQRSvsSevrice.Models;
using MediatR;

namespace DemoCQRSvsSevrice.Commands
{
    public record UpdateUserCommand(User User) : IRequest<User>;   
}
