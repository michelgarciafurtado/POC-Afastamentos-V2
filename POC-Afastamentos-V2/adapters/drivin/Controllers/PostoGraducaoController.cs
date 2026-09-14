using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Afastamentos_V2.core.Dtos.PostoGraduacao;
using POC_Afastamentos_V2.core.ports.inbound;

namespace POC_Afastamentos_V2.adapters.drivin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostoGraduacaoController : ControllerBase
{
    private readonly IPostoGraduacaoUseCase _postoGraduacaoUseCase;

    public PostoGraduacaoController(IPostoGraduacaoUseCase postoGraduacaoUseCase)
    {
        _postoGraduacaoUseCase = postoGraduacaoUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> CriarPostoGraduacao([FromBody] NovoPostoGraduacaoDto dto)
    {
        try
        {
            var postoGraduacao = await _postoGraduacaoUseCase.CriarAsync(dto);
            return CreatedAtAction(nameof(CriarPostoGraduacao), new { id = postoGraduacao }, postoGraduacao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult> ObterTodosAsync()
    {
        try
        {
            var graduacoes = await _postoGraduacaoUseCase.ObterTodosAsync();
            if (graduacoes == null || !graduacoes.Any())
                return NoContent();
            return Ok(graduacoes);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
        }
        
    }

    }

