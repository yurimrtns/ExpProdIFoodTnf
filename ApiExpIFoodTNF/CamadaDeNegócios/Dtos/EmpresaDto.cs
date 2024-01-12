using Tnf.Dto;

namespace CamadaDeNegócios.Dtos;

public class EmpresaDto : RequestAllDto
{   
    public int Id { get; set; }
    public string? Nome { get; set; }

}
