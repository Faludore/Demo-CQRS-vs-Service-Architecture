using DemoCQRSvsSevrice.Models;
using System.Collections.Generic;

namespace DemoCQRSvsSevrice.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {       
        IList<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
