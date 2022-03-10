using AutoMapper;
using Capa.Entidades;
using Capa.Entidades.ViewModel;

namespace Capa.Presentacion.Mappin
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Empleado, EmpleadoViewModel>();
            CreateMap<EmpleadoViewModel, Empleado>();
        }
    }
}
