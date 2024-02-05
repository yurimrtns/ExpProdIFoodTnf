using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;
using Tnf.Dto;
using Tnf.Repositories;

namespace CamadaDeNegócios.Repository;
public interface IExpProdFoodRepository : IRepository<ExpProdIFood>
{
    Task<ExpProdIFoodDto> GetAsync(int id);
    Task<IListDto<ExpProdIFoodDto>> BuscaTodos(ExpProdIFoodBuscaDto expProdIFoodDto);
    Task<ExpProdIFoodDto> GetProdutoPorId(int id);

    //Task<ExpProdIFoodDto> Atualizar(ExpProdIFoodDto expProdIFoodDto);

}
