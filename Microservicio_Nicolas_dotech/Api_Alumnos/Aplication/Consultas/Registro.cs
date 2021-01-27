using Api_Alumnos.Model;
using Api_Alumnos.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api_Alumnos.Aplication.Consultas
{
    // clase que registra a un alumno
    // uso el patrón CQRS
    public class Registro
    {
        public class Ejecutar : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime FechaNacimiento { get; set; }
        }

        // acá valido que se cumplan las condiciones que pido al momento de registrar un alumno
        public class ValidarCondiciones : AbstractValidator<Ejecutar>
        {
            // señalo que ninguna prop tenga null
            public ValidarCondiciones()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Apellido).NotEmpty();
                RuleFor(x => x.FechaNacimiento).NotEmpty();
            }
        }
        /// <summary>
        /// clase que contiene toda la lógica en relación a la BD
        /// </summary>
        public class Logica : IRequestHandler<Ejecutar>
        {
            private readonly AlumnosContext _alumnos;

            public Logica(AlumnosContext alumnos)
            {
                _alumnos = alumnos;
            }

            // con esta clase inserto el objeto alumno en la BD
            public async Task<Unit> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                var alumno = new Alumno // creo el objeto
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    FechaNacimiento = request.FechaNacimiento
                };
                _alumnos.ListadoAlumnos.Add(alumno); // lo agrego

                // verifico que se guarde correctamente
                var obj = await _alumnos.SaveChangesAsync();
                if (obj > 0)
                    return Unit.Value;
                else
                    throw new Exception("Error al guardar los datos del alumno");


            }
        }
    }
}
