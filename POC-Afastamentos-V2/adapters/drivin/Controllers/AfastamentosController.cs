using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Afastamentos_V2.core.Dtos.Afastamentos;
using POC_Afastamentos_V2.core.ports.inbound;

namespace POC_Afastamentos_V2.adapters.drivin.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class AfastamentosController : ControllerBase
    {
        private readonly IAfastamentoUseCase _afastamentoUseCase;

        public AfastamentosController(IAfastamentoUseCase afastamentoUseCase)
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

        [HttpPut]
        public async Task<IActionResult> AtualizarAfastamento([FromBody] AlterarAfastamentoDto dto)
        {
            try
            {
                var resultado = await _afastamentoUseCase.AtualizarAsync(dto);
                return Ok(resultado);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar afastamento: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterAfastamento(int id)
        {
            try
            {
                var resultado = await _afastamentoUseCase.ObterAsync(a => a.Id == id);
                return Ok(resultado);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter afastamento: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> ObterTodosAfastamentos()
        {
            try
            {
                var resultado = await _afastamentoUseCase.ObterTodosAsync();
                return Ok(resultado);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }


          
