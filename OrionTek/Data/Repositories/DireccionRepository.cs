using Microsoft.EntityFrameworkCore;
using OrionTek.Data.Models;
using OrionTek.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Data.Repositories
{
    public class DireccionRepository : IDireccionRepository
    {
        private readonly OrionTekDbContext _context;
        public DireccionRepository(OrionTekDbContext context)
        {
            _context = context;
        }

        public async Task<Direccion> Get(int id)
        {
            return await _context.Direccion.FindAsync(id);
        }

        public async Task<IEnumerable<Direccion>> GetAll()
        {
            return await _context.Direccion.ToListAsync();
        }

        public void Add(Direccion entity)
        {
            _context.Direccion.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Direccion entity)
        {
            _context.Direccion.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Direccion dbEntity, Direccion entity)
        {
            dbEntity.calle = entity.calle;
            dbEntity.ciudad = entity.ciudad;
            dbEntity.codigoPostal = entity.codigoPostal;
            
            _context.Direccion.Update(dbEntity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Direccion>> GetDireccionesByCliente(int id)
        {
            return await _context.Direccion.Where(x => x.clienteId == id).ToListAsync();
        }
    }
}
