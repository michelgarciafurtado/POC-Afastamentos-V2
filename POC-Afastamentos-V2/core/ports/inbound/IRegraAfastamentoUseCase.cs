using POC_Afastamentos_V2.core.Dtos.Opms;
using POC_Afastamentos_V2.core.Dtos.Regras;

namespace POC_Afastamentos_V2.core.ports.inbound
{
    public interface IRegraAfastamentoUseCase
    {
        Task<int> CriarAsync(NovaRegraDto dto);
        Task<IEnumerable<RegraDto>> ListarAsync(FiltroRegraDto opmDto);
        Task<OpmDto> ObterAsync(int RegraId);
        Task<bool> AlterarStatus(AlterarRegraDto dto);
        Task<OpmDto> AtualizarAsync(AlterarRegraDto dto);
        Task<IEnumerable<RegraDto>> ObterTodosAsync();
    }
}
