

using AutoMapper;
using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;

namespace CamadaDeNegócios.Profiles;

public class CategoriaProfile: Profile
{
    public CategoriaProfile()
    {
        CreateMap<CategoriaDto, Categoria>().ReverseMap();
    }
}
