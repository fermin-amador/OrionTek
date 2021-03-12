using OrionTek.Data.Models;
using OrionTek.Interfaces.Repositories;
using OrionTek.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Services
{
    public class EmpresaServices : IEmpresaServices
    {
        private readonly IEmpresaRepository _IEmpresaRepository;
        public EmpresaServices(IEmpresaRepository IEmpresaRepository)
        {
            _IEmpresaRepository = IEmpresaRepository;
        }


        public async Task<Empresa> Get(int id)
        {
            return await _IEmpresaRepository.Get(id);
        }
        public async Task<IEnumerable<Empresa>> GetAll()
        {
            return await _IEmpresaRepository.GetAll();
        }
        public void Add(Empresa entity)
        {
            _IEmpresaRepository.Add(entity);
        }
        public void Delete(Empresa entity)
        {
            _IEmpresaRepository.Delete(entity);
        }
        public void Update(Empresa entityDB, Empresa entity)
        {
            _IEmpresaRepository.Update(entityDB, entity);
        }
    }
}
