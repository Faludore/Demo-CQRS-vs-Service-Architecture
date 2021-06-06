using DemoCQRSvsSevrice.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using DemoCQRSvsSevrice.Data;
using DemoCQRSvsSevrice.Commands;
using System.Linq;

namespace DemoCQRSvsSevrice.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly IDbContext _context;

        public DeleteUserHandler(IDbContext context)
        {
            _context = context;
        }

        public Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = _context.Set<User>().Remove(request.User);
            _context.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
