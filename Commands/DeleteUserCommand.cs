using DemoCQRSvsSevrice.Models;
using MediatR;

namespace DemoCQRSvsSevrice.Commands
{
    public record DeleteUserCommand(User User) : IRequest<User>;
}
