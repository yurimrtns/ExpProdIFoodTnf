using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;
using CamadaDeNegócios.Repository;
using Microsoft.EntityFrameworkCore;
using Tnf.Dto;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace CamadaDeDados.Interface;

public class SegmentoRepository : EfCoreRepositoryBase<ExpIFoodContext, Segmento>, ISegmentoRepository
{
    public SegmentoRepository(IDbContextProvider<ExpIFoodContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<IListDto<SegmentoDto>> GetAllAsync(SegmentoDto segmentoDto)
    {
        var query = Table.AsQueryable().AsNoTracking();

        return await query.ToListDtoAsync<Segmento, SegmentoDto>(segmentoDto);
    }

    public async Task<SegmentoDto> GetAsync(int id)
    {
        var segmento = await GetAll(s => s.Id == id).FirstOrDefaultAsync();

        return segmento.MapTo<SegmentoDto>();
    }
}
