using Api_Alumnos.Aplication.DTO;
using Api_Alumnos.Model;
using Api_Alumnos.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api_Alumnos.Aplication.Consultas
{
    // clase que se encarga de consultar por todos los alumnos
    public class Listado_Alumnos
    {
        public class Ejecutar : IRequest<List<AlumnoDto>> { }

        public class Logica : IRequestHandler<Ejecutar, List<AlumnoDto>>
        {
            // declaro las variables para hacer una inyección de dependencia

            private readonly AlumnosContext _alumnosContext;
            private readonly IMapper _mapeo;

            public Logica(AlumnosContext context, IMapper mapeo)
            {
                _alumnosContext = context;
                _mapeo = mapeo;
            }

            /// <summary>
            /// hago el mapeo para la consulta a la BD
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<List<AlumnoDto>> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                var alumno = await _alumnosContext.ListadoAlumnos.ToListAsync();
                var alumnoDto = _mapeo.Map<List<Alumno>, List<AlumnoDto>>(alumno);

                return alumnoDto;
            }
        }

    }
}
