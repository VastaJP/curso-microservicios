using Api_Alumnos.Aplication.Consultas;
using Api_Alumnos.Aplication.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Alumnos.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        // hago una inyección de dependencia usando el mediatR para que despues la comunicación sea más fácil
        private readonly IMediator _mediatoR;
        public AlumnoController(IMediator mediator)
        {
            _mediatoR = mediator;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<Unit>> Registrar(Registro.Ejecutar datos_alumno)
        {
            return await _mediatoR.Send(datos_alumno);
        }
        [HttpGet("getAlumnos")]
        public async Task<ActionResult<List<AlumnoDto>>> GetAlumnos()
        {
            return await _mediatoR.Send(new Listado_Alumnos.Ejecutar());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlumnoDto>> GetAlumnoById(int id)
        {
            return await _mediatoR.Send(new AlumnoById.AlumnoUnico { AlumnoUnicoId = id });
        }

    }
}
