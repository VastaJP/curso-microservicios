using Api_Alumnos.Aplication.DTO;
using Api_Alumnos.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Alumnos.Aplication
{
    /// <summary>
    /// clase que realiza el mapeo acutomático
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Alumno, AlumnoDto>();
        }
    }
}
