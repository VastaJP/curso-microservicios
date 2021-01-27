using Api_Profesor.Aplication.Consultas;
using Api_Profesor.Aplication.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Profesor.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        // hago una inyección de dependencia usando el mediatR
        private readonly IMediator mediatR;
        
        //constructor
        public ProfesorController(IMediator mediator)
        {
            mediatR = mediator;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<Unit>> Registrar(Registro.Ejecutar datos)
        {
            return await mediatR.Send(datos);
        }
        [HttpGet("GetProfesores")]
        public async Task<ActionResult<List<ProfesorDTO>>> GetProfesores()
        {
            return await mediatR.Send(new ListadoProfesores.Ejecutar());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfesorDTO>> GetProfesorById(int id)
        {
            return await mediatR.Send(new ProfesorById.ProfesorUnico { ProfeId = id });
        }


    }
}
