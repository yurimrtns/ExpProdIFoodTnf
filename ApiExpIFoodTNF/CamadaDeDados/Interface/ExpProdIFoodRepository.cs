using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;
using CamadaDeNegócios.Repository;
using Microsoft.EntityFrameworkCore;
using Tnf.Dto;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace CamadaDeDados.Interface;

public class ExpProdIFoodRepository : EfCoreRepositoryBase<ExpIFoodContext, ExpProdIFood>, IExpProdFoodRepository
{
    public ExpProdIFoodRepository(IDbContextProvider<ExpIFoodContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<IListDto<ExpProdIFoodDto>> GetAllAsync(ExpProdIFoodDto expProdIFoodDto)
    {
        var query = Table.AsQueryable();

        return await query.ToListDtoAsync<ExpProdIFood, ExpProdIFoodDto>(expProdIFoodDto);
    }

    public async Task<ExpProdIFoodDto> GetAsync(int id)
    {
        var empresa = await GetAll(e => e.Id == id).FirstOrDefaultAsync();

        return empresa.MapTo<ExpProdIFoodDto>();
    }
}
