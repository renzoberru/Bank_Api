using AutoMapper;
using Bank_Api.DTO;
using BaseDatos.Modelo;

namespace Bank_Api.Configuracion
{
    public class PerfilMapper : Profile
    {
        protected internal PerfilMapper()
        {
            CreateMap<Banco, BancoDto>();
            CreateMap<BancoCreadorDto, Banco>();
        }
    }
}
