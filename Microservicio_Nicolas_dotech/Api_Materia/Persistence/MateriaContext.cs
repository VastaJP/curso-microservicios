using Api_Materia.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_Materia.Persistence
{
    /// <summary>
    /// clase que crea la instancia a la BD
    /// </summary>
    public class MateriaContext : DbContext
    {
        public MateriaContext(DbContextOptions<MateriaContext> options) : base(options) { } //hago esto para poder setear la cadena de coleccion al sql desde la clase startup.

        public DbSet<Materia> ListadoMaterias { get; set; } // este va a ser el nombre de la tabla

    }
}
