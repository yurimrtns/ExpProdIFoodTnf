using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;
using CamadaDeNegócios.Repository;
using Microsoft.EntityFrameworkCore;
using Tnf.Dto;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace CamadaDeDados.Interface;

public class CategoriaRepository : EfCoreRepositoryBase<ExpIFoodContext, Categoria>, ICategoriaRepository
{
    public CategoriaRepository(IDbContextProvider<ExpIFoodContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<IListDto<CategoriaDto>> GetAllAsync(CategoriaDto categoriaDto)
    {
        var query = Table.AsQueryable().AsNoTracking();

        return await query.ToListDtoAsync<Categoria, CategoriaDto>(categoriaDto);
    }

    public async Task<CategoriaDto> GetAsync(int id)
    {
        var categoria = await GetAll(c => c.Id == id).FirstOrDefaultAsync();

        return categoria.MapTo<CategoriaDto>();
    }
}
