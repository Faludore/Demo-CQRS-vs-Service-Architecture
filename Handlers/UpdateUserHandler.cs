using DemoCQRSvsSevrice.Commands;
using DemoCQRSvsSevrice.Data;
using DemoCQRSvsSevrice.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoCQRSvsSevrice.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IDbContext _context;

        public UpdateUserHandler(IDbContext context)
        {
            _context = context;
        }

        public Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entityOld = _context.Set<User>().FirstOrDefault(x => x.Id == request.User.Id);
            if (entityOld != null)
            {
                _context.Entry(entityOld).CurrentValues.SetValues(request.User);
                _context.SaveChanges();
            }

            return Task.FromResult(request.User);
        }
    }
}
