using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.Dtos.Afastamentos;
using POC_Afastamentos_V2.core.Dtos.SolicitarAfastamentos;
using POC_Afastamentos_V2.core.ports.inbound;
using POC_Afastamentos_V2.core.ports.outbound;

namespace POC_Afastamentos_V2.core.UseCases
{
    public class SolicitarAfastamentoUseCase : ISolicitarAfastamentoUseCase
    {
        public Task<NovoAfastamentoDto> CriarAfastamento(SolicitarAfastamentoDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
