using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;
using Tnf.Dto;
using Tnf.Repositories;

namespace CamadaDeNegócios.Repository;
public interface IExpProdFoodRepository : IRepository<ExpProdIFood>
{
    Task<ExpProdIFoodDto> GetAsync(int id);
    Task<IListDto<ExpProdIFoodDto>> GetAllAsync(ExpProdIFoodDto expProdIFoodDto);

}
