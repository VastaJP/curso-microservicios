using Api_Profesor.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Profesor.Persistence
{
    public class ProfesorContext : DbContext
    {
        public ProfesorContext(DbContextOptions<ProfesorContext> options) : base(options) { } 

        public DbSet<Profesor> Datos { get; set; } // -->  nombre de la tabla
    }
}
