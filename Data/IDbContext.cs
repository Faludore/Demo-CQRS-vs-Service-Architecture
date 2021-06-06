using DemoCQRSvsSevrice.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DemoCQRSvsSevrice.Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        int SaveChanges();

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : BaseEntity;
    }
}
