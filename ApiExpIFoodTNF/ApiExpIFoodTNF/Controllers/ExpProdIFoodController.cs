using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Entities;
using CamadaDeNegócios.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiExpIFood.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpProdIFoodController : TnfController
{
    private readonly IExpProdFoodRepository _repo;

    public ExpProdIFoodController(IExpProdFoodRepository repo)
    {
        _repo = repo;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> PostProduto([FromBody] ExpProdIFoodDto expProdIFoodDto)
    {
        var mapProd = expProdIFoodDto.MapTo<ExpProdIFood>();

        var Prod = await _repo.InsertAsync(mapProd);

        return CreateResponseOnPost(Prod);
    }

    [HttpGet]
    public async Task<IActionResult> GetProdutos([FromQuery] ExpProdIFoodDto expProdIFoodDto)
    {
        if (expProdIFoodDto == null) return NotFound();

        var prod = await _repo.GetAllAsync(expProdIFoodDto);

        return CreateResponseOnGetAll(prod);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduto(int id)
    {
        var prod = await _repo.GetAsync(id);
        if (prod == null) return NotFound();

        return CreateResponseOnGet(prod);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProduto([FromBody] ExpProdIFoodDto atualizarExpProdIFoodDto)
    {
        var prodDto = await _repo.GetAsync(atualizarExpProdIFoodDto.Id);
        if (prodDto == null) return NotFound();

        var prod = atualizarExpProdIFoodDto.MapTo<ExpProdIFood>();
        prod = await _repo.UpdateAsync(prod);
        var toDto = prod.MapTo<ExpProdIFoodDto>();

        return CreateResponseOnPut(toDto);
    }
}
