using Microsoft.EntityFrameworkCore;
using OrionTek.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionTek.Data
{
    public class OrionTekDbContext:DbContext
    {
       
        public OrionTekDbContext(DbContextOptions<OrionTekDbContext> options): base(options)
        {

        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
    }
}
