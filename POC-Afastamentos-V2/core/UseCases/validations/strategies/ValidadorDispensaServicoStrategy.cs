using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.domain.valueobjects;

namespace POC_Afastamentos_V2.core.UseCases.validations.strategies;

public class ValidadorDispensaServicoStrategy : IValidadorAfastamentoStrategy
{
    public bool PodeValidar(DetalhesAfastamento detalhes)
    {
        return detalhes is DetalhesDispensaServico;
    }

    public ResultadoValidacao Validar(SolicitacaoAfastamento solicitacao, IEnumerable<RegraAfastamento> regras)
    {
        var dispensa = (DetalhesAfastamento) solicitacao.DetalhesAfastamento;

        // regras específicas de DS

        return ResultadoValidacao.Sucesso();
    }
}
