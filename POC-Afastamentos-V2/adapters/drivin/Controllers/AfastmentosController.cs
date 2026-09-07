using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Afastamentos_V2.core.Dtos.Afastamentos;
using POC_Afastamentos_V2.core.ports.inbound;

namespace POC_Afastamentos_V2.adapters.drivin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AfastmentosController : ControllerBase
    {
        private readonly IAfastamentoUseCase _afastamentoUseCase;

        public AfastmentosController(IAfastamentoUseCase afastamentoUseCase)
        {
            _afastamentoUseCase = afastamentoUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CriarAfastamento([FromBody] NovoAfastamentoDto dto)
        {
            try
            {
                int resultado = await _afastamentoUseCase.CriarAsync(dto);
                if (resultado > 0)
                {
                    return CreatedAtAction(nameof(CriarAfastamento), new { id = dto.id }, dto);
                }
                else
                {
                    return BadRequest("Não foi possível criar o afastamento.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao criar afastamento: {ex.Message}");
            }
        }
    }
}
