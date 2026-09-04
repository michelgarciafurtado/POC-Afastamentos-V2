using POC_Afastamentos_V2.core.Dtos;

namespace POC_Afastamentos_V2.core.ports.inbound;

public interface ISolicitarAfastamentoUseCase
{
    Task<AfastamentoCriadoDto> CriarAfastamento(SolicitarAfastamentoDto dto);
}
