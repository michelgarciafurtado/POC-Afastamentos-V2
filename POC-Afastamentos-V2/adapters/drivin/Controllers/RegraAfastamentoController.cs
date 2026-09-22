

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
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarRegra([FromBody] AlterarRegraDto dto)
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterAsync(int id)
    {

    }

}
