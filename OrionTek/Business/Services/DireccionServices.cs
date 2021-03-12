using OrionTek.Data.Models;
using OrionTek.Interfaces.Repositories;
using OrionTek.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Business.Services
{
    public class DireccionServices : IDireccionServices
    {
        private readonly IDireccionRepository _IDireccionRepository;
        public DireccionServices(IDireccionRepository IDireccionRepository)
        {
            _IDireccionRepository = IDireccionRepository;
        }


        public async Task<Direccion> Get(int id)
        {
            return await _IDireccionRepository.Get(id);
        }
        public async Task<IEnumerable<Direccion>> GetAll()
        {
            return await _IDireccionRepository.GetAll();
        }
        public void Add(Direccion entity)
        {
            _IDireccionRepository.Add(entity);
        }
        public void Delete(Direccion entity)
        {
            _IDireccionRepository.Delete(entity);
        }
        public void Update(Direccion entityDB, Direccion entity)
        {
            _IDireccionRepository.Update(entityDB, entity);
        }

        public async Task<IEnumerable<Direccion>> GetDireccionesByCliente(int id)
        {
           return await _IDireccionRepository.GetDireccionesByCliente(id);
        }
    }
}
