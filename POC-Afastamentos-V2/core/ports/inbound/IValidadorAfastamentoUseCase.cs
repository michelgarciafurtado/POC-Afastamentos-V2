using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.domain.valueobjects;
using POC_Afastamentos_V2.core.UseCases;

namespace POC_Afastamentos_V2.core.ports.inbound
{
    public interface IValidadorAfastamento
    {

        Task<ResultadoValidacao> ValidarAsync(SolicitacaoAfastamento solicitacaoAfastamento);
    }
}
