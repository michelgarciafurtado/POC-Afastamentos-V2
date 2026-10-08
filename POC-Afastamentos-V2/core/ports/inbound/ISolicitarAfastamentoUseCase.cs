using POC_Afastamentos_V2.core.Dtos.Afastamentos;
using POC_Afastamentos_V2.core.Dtos.SolicitarAfastamentos;

namespace POC_Afastamentos_V2.core.ports.inbound;

public interface ISolicitarAfastamentoUseCase
{
    Task<NovoAfastamentoDto> CriarAfastamento(SolicitarAfastamentoDto dto);
    Task<int> CriarAsync(SolicitarAfastamentoDto dto);
}
