using DemoCQRSvsSevrice.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DemoCQRSvsSevrice.Data
{
    public class DefaultContext : DbContext, IDbContext
    {
        public DefaultContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<User> Users { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            return base.Entry(entity);
        }
    }
}
