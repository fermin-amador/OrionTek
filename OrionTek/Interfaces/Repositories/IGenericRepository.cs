using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}
