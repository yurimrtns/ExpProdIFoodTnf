using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;
using CamadaDeNegócios.Repository;
using Microsoft.EntityFrameworkCore;
using Tnf.Dto;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace CamadaDeDados.Interface;

public class EmpresaRepository : EfCoreRepositoryBase<ExpIFoodContext, Empresa>, IEmpresaRepository
{

    public EmpresaRepository(IDbContextProvider<ExpIFoodContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    

    public async Task<EmpresaDto> GetAsync(int id)
    {
        Console.WriteLine(this.Context.Database.GenerateCreateScript());
        var empresa = await GetAll(e => e.Id == id).FirstOrDefaultAsync();

        return empresa.MapTo<EmpresaDto>();
    }

    public async Task<IListDto<EmpresaDto>> GetAllAsync(EmpresaDto empresaDto)
    {
        var query = Table.AsQueryable().AsNoTracking();

        return await query.ToListDtoAsync<Empresa, EmpresaDto>(empresaDto);
    }

}
