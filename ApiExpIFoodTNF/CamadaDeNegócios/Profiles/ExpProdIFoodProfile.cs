using AutoMapper;
using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;

namespace CamadaDeNegócios.Profiles;

internal class ExpProdIFoodProfile: Profile
{
    public ExpProdIFoodProfile()
    {
        CreateMap<ExpProdIFood, ExpProdIFoodDto>().ReverseMap();
    }
}
