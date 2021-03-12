using OrionTek.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Interfaces.Services
{
    public interface IClienteServices: IGenericServices<Cliente>
    {

        Task<IEnumerable<Cliente>> GetClientesByEmpresa(int id);
    }
}
