using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Afastamentos_V2.core.Dtos.Afastamentos;
using POC_Afastamentos_V2.core.Dtos.SolicitarAfastamentos;
using POC_Afastamentos_V2.core.ports.inbound;

namespace POC_Afastamentos_V2.adapters.drivin.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class SolicitarAfastamentosController : ControllerBase
    {
        private readonly ISolicitarAfastamentoUseCase _SolAfastUseCase;

        public SolicitarAfastamentosController(ISolicitarAfastamentoUseCase SolAfastUseCase)
        {
            _SolAfastUseCase = SolAfastUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> SolicitarFeriasSobrestadas([FromBody] SolicitarFeriasSobrestadasDto dto)
        {
            try
            {
                int resultado = await _SolAfastUseCase.CriarAsync(dto);
                if (resultado > 0)
                {
                    return CreatedAtAction(nameof(CriarAfastamento), new { id = resultado }, dto);
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


          
