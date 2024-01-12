using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;
using Tnf.Dto;
using Tnf.Repositories;

namespace CamadaDeNegócios.Repository;
    public interface ISegmentoRepository: IRepository<Segmento>
    {
    Task<SegmentoDto> GetAsync(int id);
    Task<IListDto<SegmentoDto>> GetAllAsync(SegmentoDto segmentoDto);

}
