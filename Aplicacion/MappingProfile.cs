namespace Aplicacion
{
    using Aplicacion.Companias;
    using AutoMapper;
    using Dominio;
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Compania, CompaniaDto>();
        }
    }
}
