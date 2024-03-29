﻿using CamadaDeNegócios.Entities;
using Tnf.Dto;

namespace CamadaDeNegócios.Dtos;

public class ExpProdIFoodDto : RequestAllDto
{
    public int Id { get; set; }
    public int IdEmpresa { get; set; }
    public int IdCategoria { get; set; }
    public int IdSegmento { get; set; }
    public int IdLojaIFood { get; set; }
    public string? Ativo { get; set; }
    public Empresa? Empresa { get; set; }
    public Categoria? Categoria { get; set; }
    public Segmento? Segmento { get; set; }
}
