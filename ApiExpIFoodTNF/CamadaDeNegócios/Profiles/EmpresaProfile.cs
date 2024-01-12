using AutoMapper;
using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;

namespace CamadaDeNegócios.Profiles;

public class EmpresaProfile : Profile
{
    public EmpresaProfile()
    {
        CreateMap<EmpresaDto, Empresa>().ReverseMap();
    }
}
