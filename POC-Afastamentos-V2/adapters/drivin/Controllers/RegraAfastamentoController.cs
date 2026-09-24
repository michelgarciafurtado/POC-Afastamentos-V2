

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Afastamentos_V2.core.Dtos.Regras;
using POC_Afastamentos_V2.core.ports.inbound;

namespace POC_Afastamentos_V2.adapters.drivin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegraAfastamentoController : ControllerBase
{
    private readonly IRegraAfastamentoUseCase _regraUseCase;

    public RegraAfastamentoController(IRegraAfastamentoUseCase regraUseCase)
    {
        _regraUseCase = regraUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> CriarRegra([FromBody] NovaRegraDto dto)
    {
        var resultado = await _regraUseCase.CriarAsync(dto);
        return CreatedAtAction(nameof(CriarRegra), new { id = resultado }, dto);
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarRegra([FromBody] AlterarRegraDto dto)
    {
        var atualizado = await _regraUseCase.AtualizarAsync(dto);
        if (atualizado == null)
            return NotFound();

        return Ok(atualizado);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterAsync(int id)
    {
        var regra = await _regraUseCase.ObterAsync(id);
        if (regra == null)
            return NotFound();

        return Ok(regra);
    }

    [HttpGet]
    public async Task<IActionResult> FiltrarRegras([FromBody] FiltroRegraDto filtro)
    {
        IEnumerable<RegraDto> resultados;

        if (filtro == null)
        {
            resultados = await _regraUseCase.ObterTodosAsync();
        }
        else
        {
            resultados = await _regraUseCase.ListarAsync(filtro);
        }

        return Ok(new { Regras = resultados });
    }

}
