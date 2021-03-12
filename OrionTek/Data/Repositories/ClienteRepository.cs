using Microsoft.EntityFrameworkCore;
using OrionTek.Data.Models;
using OrionTek.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private OrionTekDbContext _context;
        public ClienteRepository(OrionTekDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Get(int id)
        {
          
            return await _context.Cliente.FindAsync(id);
            
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Cliente.ToListAsync();
        }

        public void Add(Cliente entity)
        {
            _context.Cliente.Add(entity);
            _context.SaveChanges();

        }

        public void Delete(Cliente entity)
        {
            _context.Cliente.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(Cliente dbEntity, Cliente entity)
        {
          
            dbEntity.nombre = entity.nombre;
            dbEntity.apellido = entity.apellido;
            dbEntity.genero = entity.genero;
            dbEntity.telefono = entity.telefono;
            dbEntity.empresaId = entity.empresaId;
            
            _context.Cliente.Update(dbEntity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Cliente>> GetClientesByEmpresa(int id)
        {
            return await _context.Cliente.Where(x => x.empresaId == id).ToListAsync();
        }
    }
}
