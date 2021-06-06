using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DemoCQRSvsSevrice.Data;
using DemoCQRSvsSevrice.Models;

namespace DemoCQRSvsSevrice.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private IDbSet<T> _entities;
        private readonly IDbContext _context;

        public EfRepository(IDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public IList<T> GetAll()
        {
            return this.Entities.ToList();
        }

        public T GetById(int id)
        {
            return this.Entities.FirstOrDefault(x => x.Id == id);
        }

        public void Create(T entity)
        {
            this.Entities.Add(entity);
            this._context.SaveChanges();
        }

        public void Update(T entity)
        {
            var entityOld = this.Entities.FirstOrDefault(x => x.Id == entity.Id);
            if (entityOld != null)
            {
                this._context.Entry(entityOld).CurrentValues.SetValues(entity);
                this._context.SaveChanges();
            }        
        }

        public void Delete(T entity)
        {
            this.Entities.Remove(entity);
            this._context.SaveChanges();
        }

        public void Save()
        {
             this._context.SaveChanges();
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
}
