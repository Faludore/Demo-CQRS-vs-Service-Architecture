using DemoCQRSvsSevrice.Data;
using DemoCQRSvsSevrice.Models;
using DemoCQRSvsSevrice.Queries;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCQRSvsSevrice.Handlers
{
    public class GetUsersListHandler : IRequestHandler<GetUsersListQuery, List<User>>
    {
        private readonly IDbContext _context;

        public GetUsersListHandler(IDbContext context)
        {
            _context = context;
        }

        public Task<List<User>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.Set<User>().ToList());
        }
    }
}
