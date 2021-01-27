using Api_Profesor.Aplication.DTO;
using Api_Profesor.Model;
using Api_Profesor.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api_Profesor.Aplication.Consultas
{
    public class ListadoProfesores
    {
        // clase que se encarga de consultar por todos los profesores
        public class Ejecutar : IRequest<List<ProfesorDTO>> { }
        public class Logica : IRequestHandler<Ejecutar, List<ProfesorDTO>>
        {
            // declaro las variables para hacer una inyección de dependencia
            private readonly ProfesorContext profesor;
            private readonly IMapper _mapeo;
            
            // constructor
            public Logica(ProfesorContext profesorContext, IMapper mapper)
            {
                profesor = profesorContext;
                _mapeo = mapper;

            }

            /// <summary>
            /// realizo el mapeo para la consulta a la BD
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<List<ProfesorDTO>> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                var profe = await profesor.Datos.ToListAsync();
                var profeDTO = _mapeo.Map<List<Profesor>, List<ProfesorDTO>>(profe);

                return profeDTO;
            }
        }
    }
}
