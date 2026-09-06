using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.domain.valueobjects;

namespace POC_Afastamentos_V2.core.UseCases.validations
{
    public interface IValidadorAfastamento
    {
        TipoAfastamento TipoAfastamento { get; }

        Task ValidarAsync(SolicitacaoAfastamento solicitacaoAfastamento);
    }
}
