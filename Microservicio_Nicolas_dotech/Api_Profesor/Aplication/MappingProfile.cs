using Api_Profesor.Aplication.DTO;
using Api_Profesor.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Profesor.Aplication
{
    /// <summary>
    /// clase que se encarga de realizar el mapeo automático
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Profesor, ProfesorDTO>();
        }
    }
}
