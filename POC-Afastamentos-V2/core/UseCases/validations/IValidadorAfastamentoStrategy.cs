using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.domain.valueobjects;
using POC_Afastamentos_V2.core.UseCases;

namespace POC_Afastamentos_V2.core.UseCases.validations;

public interface IValidadorAfastamentoStrategy
{
    bool PodeValidar(DetalhesAfastamento detalhes);

    ResultadoValidacao Validar(
        SolicitacaoAfastamento solicitacao, IEnumerable<RegraAfastamento> regras);
}
