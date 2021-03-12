using OrionTek.Data.Models;
using OrionTek.Data.Repositories;
using OrionTek.Interfaces.Repositories;
using OrionTek.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Services
{
    public class ClienteServices:IClienteServices
    {
        private readonly IClienteRepository _IClienteRepository;
        public ClienteServices(IClienteRepository IClienteRepository)
        {
            _IClienteRepository = IClienteRepository;
        }

        public async Task<Cliente> Get(int id)
        {
            return await _IClienteRepository.Get(id);
        }
        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _IClienteRepository.GetAll();
        }
        public void Add(Cliente entity)
        {
             _IClienteRepository.Add(entity);  
        }

        public void Delete(Cliente entity)
        {
            _IClienteRepository.Delete(entity);
        }
        public void Update(Cliente entityDB,Cliente entity)
        {
             _IClienteRepository.Update(entityDB, entity);  
        }

        public async Task<IEnumerable<Cliente>> GetClientesByEmpresa(int id)
        {
            return await _IClienteRepository.GetClientesByEmpresa(id);
        }
    }
}
