using DemoCQRSvsSevrice.Models;
using MediatR;

namespace DemoCQRSvsSevrice.Commands
{
    public record InsertUserCommand(User User) : IRequest<User>;
}
