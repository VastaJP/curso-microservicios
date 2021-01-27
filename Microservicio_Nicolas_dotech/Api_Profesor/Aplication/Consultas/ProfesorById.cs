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
    /// <summary>
    /// clase que se encarga de hacer la consulta para un profesor ne particular según el ID que le pase.
    /// </summary>
    public class ProfesorById
    {
        public class ProfesorUnico : MediatR.IRequest<ProfesorDTO>
        {
            public int ProfeId { get; set; }
        }
        /// <summary>
        /// clase que implementa toda la lógica 
        /// </summary>
        public class Logica : IRequestHandler<ProfesorUnico, ProfesorDTO>
        {
            // hago una inyección de dependencia para luego hacer un mapeo

            private readonly ProfesorContext _profesor;
            private readonly IMapper _mapeo;

            public Logica(ProfesorContext profesorContext, IMapper mapper)
            {
                _profesor = profesorContext;
                _mapeo = mapper;
            }

            // hago el mapeo para luego consultar en la BD
            public async Task<ProfesorDTO> Handle(ProfesorUnico request, CancellationToken cancellationToken)
            {
                var profe = await _profesor.Datos.Where(x => x.ProfesorId == request.ProfeId).FirstOrDefaultAsync();
                if (profe == null)
                    throw new Exception("No se encontró el profesor buscado");


                var profeDto = _mapeo.Map<Profesor, ProfesorDTO>(profe);
                return profeDto;
            }
        }
    }
}
