using Microsoft.EntityFrameworkCore;
using OrionTek.Data.Models;
using OrionTek.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {

        private readonly OrionTekDbContext _context;
        public EmpresaRepository(OrionTekDbContext context)
        {
            _context = context;
        }

        public async Task<Empresa> Get(int id)
        {
            return await _context.Empresa.FindAsync(id);
        }

        public async Task<IEnumerable<Empresa>> GetAll()
        {
            return await _context.Empresa.ToListAsync();
        }

        public void Add(Empresa entity)
        {
            _context.Empresa.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Empresa entity)
        {
            _context.Empresa.Remove(entity);
            _context.SaveChanges();
        }

      

        public void Update(Empresa dbEntity, Empresa entity)
        {
            dbEntity.nombre = entity.nombre;
            dbEntity.descripcion = entity.descripcion;
            dbEntity.telefono = entity.telefono;
           
            _context.Empresa.Update(dbEntity);
            _context.SaveChanges();
        }
    }
}
