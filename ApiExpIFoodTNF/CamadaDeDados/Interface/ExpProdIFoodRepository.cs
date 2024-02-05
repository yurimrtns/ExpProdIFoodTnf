using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;
using CamadaDeNegócios.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Tnf.Dto;
using Tnf.EntityFrameworkCore;
using Tnf.EntityFrameworkCore.Repositories;

namespace CamadaDeDados.Interface;

public class ExpProdIFoodRepository : EfCoreRepositoryBase<ExpIFoodContext, ExpProdIFood>, IExpProdFoodRepository
{
    public ExpProdIFoodRepository(IDbContextProvider<ExpIFoodContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<IListDto<ExpProdIFoodDto>> BuscaTodos(ExpProdIFoodBuscaDto expProdIFoodDto)
    {
        var query = Table.AsQueryable().AsNoTracking();
        query = query
            .Include(x => x.Empresa)
            .Include(x => x.Segmento)
            .Include(x => x.Categoria);
        var test = query.ToList();


        return await query.ToListDtoAsync<ExpProdIFood, ExpProdIFoodDto>(expProdIFoodDto);
    }

    public async Task<ExpProdIFoodDto> GetProdutoPorId(int id)
    {
        var produto = await GetAll(e => e.Id == id)
            .Include(x => x.Empresa)
            .Include(x => x.Segmento)
            .Include(x => x.Categoria)
            .FirstOrDefaultAsync();

        return produto.MapTo<ExpProdIFoodDto>();
    }

    public async Task<ExpProdIFoodDto> GetAsync(int id)
    {
        var produto = await GetAll(e => e.Id == id)
            .Include(x => x.Empresa)
            .Include(x => x.Segmento)
            .Include(x => x.Categoria)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        return produto.MapTo<ExpProdIFoodDto>();
    }

    //public async Task<ExpProdIFoodDto> Atualizar(ExpProdIFoodDto exp)
    //{
    //    var query = Table.Where(x => x.Id == exp.Id)
    //        .Include(p => p.Empresa)
    //        .Include(p => p.Categoria)
    //        .Include(p => p.Segmento)
    //        .FirstOrDefault();

    //    if(exp.Empresa.Count() > 0)
    //    {
    //        foreach(var empresa in exp.Empresa)
    //        {
    //            var emp = query.Empresa.Where(x => x.Nome == empresa.Nome).FirstOrDefault();
    //            emp.Nome = empresa.Nome;
    //        }
    //    }

    //    if (exp.Segmento.Count() > 0)
    //    {
    //        foreach (var segmento in exp.Segmento)
    //        {
    //            var seg = query.Segmento.Where(x => x.Nome == segmento.Nome).FirstOrDefault();
    //            seg.Nome = segmento.Nome;
    //        }
    //    }

    //    if (exp.Categoria.Count() > 0)
    //    {
    //        foreach (var categoria in exp.Categoria)
    //        {
    //            var cat = query.Empresa.Where(x => x.Nome == categoria.Nome).FirstOrDefault();
    //            cat.Nome = categoria.Nome;
    //        }
    //    }

    //    var retorno = await UpdateAsync(query);
    //    return retorno.MapTo<ExpProdIFoodDto>();
    //}

}
