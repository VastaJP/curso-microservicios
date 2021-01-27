
using Api_Materia.Aplication.DTO;
using Api_Materia.Model;
using AutoMapper;

namespace Api_Materia.Aplication
{
    /// <summary>
    /// clase que realiza el mapeo acutomático
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Materia, MateriaDto>();
        }
    }
}
