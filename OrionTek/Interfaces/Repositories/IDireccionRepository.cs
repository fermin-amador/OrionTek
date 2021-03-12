using OrionTek.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Interfaces.Repositories
{
    public interface IDireccionRepository : IGenericRepository<Direccion>
    {
        Task<IEnumerable<Direccion>> GetDireccionesByCliente(int id);
    }
}
