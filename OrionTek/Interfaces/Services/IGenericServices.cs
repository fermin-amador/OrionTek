using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Interfaces.Services
{
    public interface IGenericServices<TEntity>
    {

        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entityDB, TEntity entity);
        void Delete( TEntity entity);

    }
}
