using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Repository;
using CamadaDeNegócios.Entities;

namespace ApiExpIFood.Controllers;

[ApiController]
[Route("[controller]")]
public class SegmentosController : TnfController
{
    private readonly ISegmentoRepository _repo;

    public SegmentosController(ISegmentoRepository repo)
    {
        _repo = repo;

    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] SegmentoDto segmentoDto)
    {
        var mapSegmento = segmentoDto.MapTo<Segmento>();

        var s = await _repo.InsertAsync(mapSegmento);

        return CreateResponseOnPost(s);
    }


    [HttpGet]
    public async Task<IActionResult> GetSegmentos([FromQuery] SegmentoDto segmentoDto)
    {   
        //INVERTIDO POR TESTE
       var segmento = await _repo.GetAllAsync(segmentoDto);
        if(segmento == null) return NotFound();

        return CreateResponseOnGetAll(segmento);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetSegmento(int id)
    {
        var segmento = await _repo.GetAsync(id);
        if(segmento == null) return NotFound();

        return CreateResponseOnGet(segmento);
    }


    [HttpPut]
    public async Task<IActionResult> PutSegmento([FromBody] SegmentoDto atualizarSegmentoDto)
    {
        var segmentoDto = await _repo.GetAsync(atualizarSegmentoDto.Id);
        if(segmentoDto == null) return NotFound();

        var segmento = atualizarSegmentoDto.MapTo<Segmento>();
        segmento = await _repo.UpdateAsync(segmento);
        var toDto = segmento.MapTo<SegmentoDto>();

        return CreateResponseOnPut(toDto);
    }
}
