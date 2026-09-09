using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.Dtos.Afastamentos;
using POC_Afastamentos_V2.core.Dtos.Opms;
using System.Linq.Expressions;

namespace POC_Afastamentos_V2.core.ports.inbound;

public interface IOpmUseCase
{
    Task<int> CriarAsync(NovaOpmDto dto);
    Task<IEnumerable<OpmDto>> ListarAsync(FiltroOpmDto opmDto);
    Task<OpmDto> ObterAsync(string opmCod);
    Task<bool> AlterarStatus(AlterarStatusOpmDto dto);
    Task<OpmDto> AtualizarAsync(AlterarOpmDto dto);
    Task<IEnumerable<OpmDto>> ObterTodosAsync();
}
