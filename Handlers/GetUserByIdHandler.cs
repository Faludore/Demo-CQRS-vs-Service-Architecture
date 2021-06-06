using DemoCQRSvsSevrice.Data;
using DemoCQRSvsSevrice.Models;
using DemoCQRSvsSevrice.Queries;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace DemoCQRSvsSevrice.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IDbContext _context;

        public GetUserByIdHandler(IDbContext context)
        {
            _context = context;
        }

        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.Set<User>().FirstOrDefault(x => x.Id == request.Id));
        }
    }
}
