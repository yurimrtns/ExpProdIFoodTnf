using AutoMapper;
using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;

namespace CamadaDeNegócios.Profiles;

public class SegmentoProfile: Profile
{
    public SegmentoProfile()
    {
        CreateMap<SegmentoDto, Segmento>().ReverseMap();

    }
}
