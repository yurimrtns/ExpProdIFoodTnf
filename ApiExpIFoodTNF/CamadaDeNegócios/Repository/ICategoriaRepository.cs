using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;
using Tnf.Dto;
using Tnf.Repositories;

namespace CamadaDeNegócios.Repository;

public interface ICategoriaRepository: IRepository<Categoria>
{
    Task<CategoriaDto> GetAsync(int id);
    Task<IListDto<CategoriaDto>> GetAllAsync(CategoriaDto categoriaDto);
}
