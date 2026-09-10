using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Afastamentos_V2.core.Dtos.Opms;
using POC_Afastamentos_V2.core.ports.inbound;


namespace POC_Opms_V2.adapters.drivin.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class OpmsController : ControllerBase
    {
        private readonly IOpmUseCase _opmUseCase;

        public OpmsController (IOpmUseCase opmUseCase)
        {
            _opmUseCase = opmUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CriarOpm([FromBody] NovaOpmDto dto)
        {
            try
            {
                int resultado = await _opmUseCase.CriarAsync(dto);
                if (resultado > 0)
                {
                    return CreatedAtAction(nameof(CriarOpm), new { id = resultado }, dto);
                }
                else
                {
                    return BadRequest("Não foi possível criar o Opm.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao criar Opm: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarOpm([FromBody] AlterarOpmDto dto)
        {
            try
            {
                var resultado = await _opmUseCase.AtualizarAsync(dto);
                return Ok(resultado);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar Opm: {ex.Message}");
            }
        }

        [HttpGet("{OpmCod}")]
        public async Task<IActionResult> ObterOpm(string OpmCod)
        {
            try
            {
                var resultado = await _opmUseCase.ObterAsync(OpmCod);
                return Ok(resultado);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao obter Opm: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> ObterTodosOpms()
        {
            try
            {
                var resultado = await _opmUseCase.ObterTodosAsync();
                return Ok(resultado);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }


          
