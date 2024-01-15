using AutoMapper;
using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;

namespace CamadaDeNegócios.Profiles;

public class ExpProdIFoodProfile: Profile
{
    public ExpProdIFoodProfile()
    {
        CreateMap<ExpProdIFoodDto, ExpProdIFood>().ReverseMap();
    }
}
