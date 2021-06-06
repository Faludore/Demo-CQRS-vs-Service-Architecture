using DemoCQRSvsSevrice.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DemoCQRSvsSevrice.Data;
using DemoCQRSvsSevrice.Commands;

namespace DemoCQRSvsSevrice.Handlers
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, User>
    {
        private readonly IDbContext _context;

        public InsertUserHandler(IDbContext context)
        {
            _context = context;
        }

        public Task<User> Handle(InsertUserCommand request, CancellationToken cancellationToken)
        {
            var result = _context.Set<User>().Add(request.User);
            _context.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
