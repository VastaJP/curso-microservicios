using Api_Materia.Model;
using Api_Materia.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api_Materia.Aplication.Consultas
{
    // clase que registra una materia
    // uso el patrón CQRS
    public class Registro
    {
        public class Ejecutar : IRequest
        {
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public int ProfesorId { get; set; }
        }

        // acá valido que se cumplan las condiciones que pido al momento de registrar una materia
        public class ValidarCondiciones : AbstractValidator<Ejecutar>
        {
            // señalo que ninguna prop tenga null
            public ValidarCondiciones()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.ProfesorId).NotEmpty();
            }
        }
        /// <summary>
        /// clase que contiene toda la lógica en relación a la BD
        /// </summary>
        public class Logica : IRequestHandler<Ejecutar>
        {
            private readonly MateriaContext _materia;

            public Logica(MateriaContext materiaContext)
            {
                _materia = materiaContext;
            }

            // con esta clase inserto el objeto materia en la BD
            public async Task<Unit> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                var materia = new Materia // creo el objeto
                {
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion,
                    ProfesorId = request.ProfesorId
                };
                _materia.ListadoMaterias.Add(materia); // lo agrego

                // verifico que se guarde correctamente
                var obj = await _materia.SaveChangesAsync();
                if (obj > 0)
                    return Unit.Value;
                else
                    throw new Exception("Error al guardar los datos de la materia");


            }
        }
    }
}
