using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.ports.outbound;

namespace POC_Afastamentos_V2.core.UseCases.validations;

public class ValidadorAfastamentoUseCase : IValidadorAfastamentoUseCase
{
    private readonly IRegrasAfastamentoRepository _regrasRepository;

    private readonly IEnumerable<IValidadorAfastamentoStrategy> _strategies;

    public ValidadorAfastamentoUseCase(IRegrasAfastamentoRepository regrasRepository,
                    IEnumerable<IValidadorAfastamentoStrategy> strategies)
    {
        _regrasRepository = regrasRepository;
        _strategies = strategies;
    }

    public async Task<ResultadoValidacao> ValidarAsync(SolicitacaoAfastamento solicitacao)
    {
        var regras = await _regrasRepository.ObterRegrasPorIdAsync(solicitacao.TipoAfastamentoId);

        if (regras == null || !regras.Any())
            return  ResultadoValidacao.Falha($"Nenhuma Regra foi localizada para o tipo {solicitacao.DetalhesAfastamento.GetType}");

        var strategy = _strategies.FirstOrDefault(s => s.PodeValidar(solicitacao.DetalhesAfastamento));

        if (strategy == null)
            return ResultadoValidacao.Falha($"Nenhum validador cadastrado para o tipo {solicitacao.DetalhesAfastamento.GetType}");

        ResultadoValidacao resultadoValidacao = strategy.Validar(solicitacao, regras);
        return resultadoValidacao;
    }

}

