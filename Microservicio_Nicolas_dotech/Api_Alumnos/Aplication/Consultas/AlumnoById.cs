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
    /// <summary>
    /// clase que se encarga de hacer la consulta para un alumno 
    /// en particular según el ID que le pase.
    /// </summary>
    public class AlumnoById
    {
        public class AlumnoUnico : MediatR.IRequest<AlumnoDto>
        {
            public int AlumnoUnicoId { get; set; }
        }
        /// <summary>
        /// clase que implementa toda la lógica 
        /// </summary>
        public class Logica : IRequestHandler<AlumnoUnico, AlumnoDto>
        {
            // hago una inyección de dependencia para luego hacer un mapeo

            private readonly AlumnosContext _alumnos;
            private readonly IMapper _mapeo;

            public Logica(AlumnosContext alumnosContext, IMapper mapper)
            {
                _alumnos = alumnosContext;
                _mapeo = mapper;
            }

            // hago el mapeo para luego consultar en la BD
            public async Task<AlumnoDto> Handle(AlumnoUnico request, CancellationToken cancellationToken)
            {
                var alumno = await _alumnos.ListadoAlumnos.Where(x => x.AlumnoId == request.AlumnoUnicoId).FirstOrDefaultAsync();
                if (alumno == null)
                    throw new Exception("No se encontró al alumno buscado");


                var alumnoDto = _mapeo.Map<Alumno, AlumnoDto>(alumno);
                return alumnoDto;
            }
        }
    }
}
