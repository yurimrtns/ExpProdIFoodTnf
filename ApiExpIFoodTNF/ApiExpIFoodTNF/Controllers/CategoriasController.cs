using CamadaDeDados;
using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;
using CamadaDeNegócios.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiExpIFood.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriasController : TnfController
{
    private readonly ICategoriaRepository _repo;

    public CategoriasController(ICategoriaRepository repo)
    {
        _repo = repo;

    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] CategoriaDto categoriaDto)
    {
        
        var mapCategoria = categoriaDto.MapTo<Categoria>();

        var c = await _repo.InsertAsync(mapCategoria);

        return CreateResponseOnPost(c);
    }

    [HttpGet]
    public async Task<IActionResult> GetCategorias([FromQuery] CategoriaDto categoriaDto )
    {
        if( categoriaDto == null ) return NotFound();
        var c = await _repo.GetAllAsync(categoriaDto);

        return CreateResponseOnGetAll(c);
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoria(int id)
    {
        var categoria = await _repo.GetAsync(id);
        if(categoria == null ) return NotFound();

        return CreateResponseOnGet(categoria);
    }

    [HttpPut]
    public async Task <IActionResult> PutCategoria([FromBody] CategoriaDto atualizarCategoriaDto)
    {
        var categoriaDto = await _repo.GetAsync(atualizarCategoriaDto.Id);
        if( categoriaDto == null )return NotFound();

        var categoria = atualizarCategoriaDto.MapTo<Categoria>();
        categoria = await _repo.UpdateAsync(categoria);
        var toDto = categoria.MapTo<CategoriaDto>();

        return CreateResponseOnPut(toDto);
    }
}
