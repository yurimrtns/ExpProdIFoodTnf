using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;
using Tnf.Dto;
using Tnf.Repositories;

namespace CamadaDeNegócios.Repository;
    public interface IEmpresaRepository : IRepository<Empresa>
    {
    Task<EmpresaDto> GetAsync(int id);
    Task<IListDto<EmpresaDto>> GetAllAsync(EmpresaDto empresaDto);

    }
