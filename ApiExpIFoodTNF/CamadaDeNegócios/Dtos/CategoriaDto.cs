using CamadaDeNegócios.Entities;
using Tnf.Dto;

namespace CamadaDeNegócios.Dtos;

public class CategoriaDto : RequestAllDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
}
