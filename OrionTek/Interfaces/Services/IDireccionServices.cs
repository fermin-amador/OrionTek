using OrionTek.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Interfaces.Services
{
    public interface IDireccionServices:IGenericServices<Direccion>
    {
        Task<IEnumerable<Direccion>> GetDireccionesByCliente(int id);
    }
}
