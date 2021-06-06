using DemoCQRSvsSevrice.Models;
using MediatR;

namespace DemoCQRSvsSevrice.Queries
{
    public record GetUserByIdQuery(int Id) : IRequest<User>;
}
