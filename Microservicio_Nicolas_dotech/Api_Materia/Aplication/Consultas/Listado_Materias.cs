using Api_Materia.Aplication.DTO;
using Api_Materia.Model;
using Api_Materia.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Api_Materia.Aplication.Consultas
{
    // clase que se encarga de consultar por todas las materias
    public class Listado_Materias
    {
        public class Ejecutar : IRequest<List<MateriaDto>> { }
        public class Logica : IRequestHandler<Ejecutar, List<MateriaDto>>
        {
            // declaro las variables para hacer una inyección de dependencia

            private readonly MateriaContext materiaContext;
            private readonly IMapper _mapeo;
            public Logica(MateriaContext context, IMapper mapeo)
            {
                materiaContext = context;
                _mapeo = mapeo;
            }
            /// <summary>
            /// hago el mapeo para la consulta a la BD
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            public async Task<List<MateriaDto>> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                var materia = await materiaContext.ListadoMaterias.ToListAsync();
                var materiaDTO = _mapeo.Map<List<Materia>, List<MateriaDto>>(materia);
                return materiaDTO;
            }
        }
















    }
}
