using Api_Profesor.Model;
using Api_Profesor.Persistence;
using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api_Profesor.Aplication.Consultas
{
    public class Registro
    {
        public class Ejecutar: IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int Edad { get; set; }
            public DateTime FechaIncorporacion { get; set; }
            public string MateriaId { get; set; }
        }
        // acá seteo cuales quiero que sean las condiciones que valide
        public class Validaciones : AbstractValidator<Ejecutar>
        {
            public Validaciones()
            {
               RuleFor(x =>x.Nombre).NotEmpty();
               RuleFor(x =>x.Apellido).NotEmpty();
               RuleFor(x =>x.Edad).NotEmpty();
               RuleFor(x =>x.FechaIncorporacion).NotEmpty();
               RuleFor(x => x.MateriaId).NotEmpty();
            }
        }
        /// <summary>
        /// clase que implementa la lógica en relación a la bd
        /// </summary>
        public class Logica : IRequestHandler<Ejecutar>
        {
            // hago la inyección de dependencia

            private readonly ProfesorContext _profesor;
            public Logica(ProfesorContext profesorContext)
            {
                _profesor = profesorContext;
            }

            // clase que hace el insert del objeto profe
            public async Task<Unit> Handle(Ejecutar request, CancellationToken cancellationToken)
            {

                var profe = new Profesor
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Edad = request.Edad,
                    FechaIncorporacion = request.FechaIncorporacion,
                    MateriaId = request.MateriaId
                };
                _profesor.Datos.Add(profe);

                // verifico que se haya guardado correctamente
                var value = await _profesor.SaveChangesAsync();
                if (value > 0)
                    return Unit.Value;
                else
                    throw new Exception("Error al guardar los datos del profesor");

            }
        }


    }
}
