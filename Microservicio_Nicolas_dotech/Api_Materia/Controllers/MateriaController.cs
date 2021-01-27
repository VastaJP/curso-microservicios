using Api_Materia.Aplication.Consultas;
using Api_Materia.Aplication.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api_Materia.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        // hago una inyección de dependencia usando el mediatR para que despues la comunicación sea más fácil
        private readonly IMediator _mediatoR;
        public MateriaController(IMediator mediator)
        {
            _mediatoR = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Registrar(Registro.Ejecutar datos_materia)
        {
            return await _mediatoR.Send(datos_materia);
        }
        [HttpGet("getMaterias")]
        public async Task<ActionResult<List<MateriaDto>>> GetMaterias()
        {
            return await _mediatoR.Send(new Listado_Materias.Ejecutar());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MateriaDto>> GetMateriaById(int id)
        {
            return await _mediatoR.Send(new MateriaById.MateriaUnica { MateriaUnicaId = id });
        }
    }
}
