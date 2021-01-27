using Api_Alumnos.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Alumnos.Persistence
{
    /// <summary>
    /// clase que crea la instancia a la BD
    /// </summary>
    public class AlumnosContext : DbContext
    {
        public AlumnosContext(DbContextOptions<AlumnosContext> options) : base(options) { } //hago esto para poder setear la cadena de coleccion al sql desde la clase startup.

        public DbSet<Alumno> ListadoAlumnos { get; set; } // este va a ser el nombre de la tabla

    }
}
