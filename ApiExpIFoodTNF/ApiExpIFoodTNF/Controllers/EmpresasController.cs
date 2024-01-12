using Microsoft.AspNetCore.Mvc;
using CamadaDeNegócios.Dtos;
using CamadaDeNegócios.Repository;
using CamadaDeNegócios.Entities;

namespace ApiExpIFood.Controllers;

[ApiController]
[Route("[controller]")]
public class EmpresasController : TnfController
{
    private readonly IEmpresaRepository _repo;
    

    public EmpresasController(IEmpresaRepository repo)
    {
        _repo = repo;
        

    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] EmpresaDto empresaDto)
    {   

        var mapEmpresa = empresaDto.MapTo<Empresa>();


        var e = await _repo.InsertAsync(mapEmpresa);

        return CreateResponseOnPost(e);
    }

    [HttpGet]
    public async Task<IActionResult> GetEmpresas([FromQuery] EmpresaDto empresasDto)
    {
        if (empresasDto == null) return NotFound();
        var e = await _repo.GetAllAsync(empresasDto);
        return CreateResponseOnGetAll(e);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmpresa(int id)
    {
        var empresa = await _repo.GetAsync(id);
        if (empresa == null) return NotFound();

        return CreateResponseOnGet(empresa);
    }

    [HttpPut]
    public async Task<IActionResult> PutEmpresa([FromBody] EmpresaDto atualizarEmpresaDto)
    {
       var empresaDto = await _repo.GetAsync(atualizarEmpresaDto.Id);
        if (empresaDto == null) return NotFound();

        var empresa = atualizarEmpresaDto.MapTo<Empresa>();
        empresa = await _repo.UpdateAsync(empresa);
        var toDto = empresa.MapTo<EmpresaDto>();

        return CreateResponseOnPut(toDto);
    }
}
