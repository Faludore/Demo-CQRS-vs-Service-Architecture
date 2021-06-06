using DemoCQRSvsSevrice.Models;
using MediatR;
using System.Collections.Generic;

namespace DemoCQRSvsSevrice.Queries
{
    public record GetUsersListQuery() : IRequest<List<User>>;
}
