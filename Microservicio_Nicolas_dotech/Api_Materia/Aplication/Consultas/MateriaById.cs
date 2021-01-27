using Api_Materia.Aplication.DTO;
using Api_Materia.Model;
using Api_Materia.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api_Materia.Aplication.Consultas
{
    /// <summary>
    /// clase que se encarga de hacer la consulta para un alumno 
    /// en particular según el ID que le pase.
    /// </summary>
    public class MateriaById
    {
        public class MateriaUnica : MediatR.IRequest<MateriaDto>
        {
            public int MateriaUnicaId { get; set; }
        }

        /// <summary>
        ///  clase que implementa toda la lógica 
        /// </summary>
        public class Logica : IRequestHandler<MateriaUnica, MateriaDto>
        {
            // hago una inyección de dependencia para luego hacer un mapeo

            private readonly MateriaContext _materia;
            private readonly IMapper _mapeo;

            public Logica(MateriaContext materiaContext, IMapper mapper)
            {
                _materia = materiaContext;
                _mapeo = mapper;
            }

            // hago el mapeo para luego consultar en la BD
            public async Task<MateriaDto> Handle(MateriaUnica request, CancellationToken cancellationToken)
            {
                var materia = await _materia.ListadoMaterias.Where(x => x.MateriaId == request.MateriaUnicaId).FirstOrDefaultAsync();
                if (materia == null)
                    throw new Exception("No se encontró al alumno buscado");


                var alumnoDto = _mapeo.Map<Materia, MateriaDto>(materia);
                return alumnoDto;
            }
        }






    }
}
