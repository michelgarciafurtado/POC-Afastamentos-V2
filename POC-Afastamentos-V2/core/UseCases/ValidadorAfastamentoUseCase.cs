using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.domain.valueobjects;
using POC_Afastamentos_V2.core.ports.inbound;
using POC_Afastamentos_V2.core.ports.outbound;

namespace POC_Afastamentos_V2.core.UseCases;

public class ValidadorAfastamentoUseCase : IValidadorAfastamento
{
    private readonly IRegrasAfastamentoRepository _regrasRepository;

    //Dictionary com valor composto entende que o ultimo argumento na chave de valor é o tipo de retorno
    private static readonly Dictionary<Type, Func<DetalhesAfastamento, IEnumerable<RegraAfastamento>, ResultadoValidacao>> Validadores = new()
    {
        { typeof(DetalhesLuto), ( det, reg) => (ResultadoValidacao)ValidarRegrasLuto((DetalhesLuto)det, reg) },
        { typeof(DetalhesDispensaServico), ( det, reg) => (ResultadoValidacao)ValidarRegrasDispensa((DetalhesDispensaServico)det, reg) }
        // Adicione os novos tipos de detalhes aqui conforme surgirem
    };

    public ValidadorAfastamentoUseCase(IRegrasAfastamentoRepository regrasRepository)
    {
        _regrasRepository = regrasRepository;
    }

    public async Task<ResultadoValidacao> ValidarAsync(SolicitacaoAfastamento solicitacao)
    {
        var regras = await _regrasRepository.ObterRegrasPorIdAsync(solicitacao.TipoAfastamentoId);

        if (regras == null || !regras.Any())
            throw new ArgumentException("Regras não foram localizadas");

        var tipoDetalhe = solicitacao.DetalhesAfastamento.GetType();

        if (Validadores.TryGetValue(tipoDetalhe, out var validador))
        {
            // Executa o validador do dicionário e retorna o ResultadoValidacao dele
            return validador(solicitacao.DetalhesAfastamento, regras);
        }

        return ResultadoValidacao.Falha($"Nenhum validador cadastrado para o tipo {tipoDetalhe.Name}");

    }

    

    private static ResultadoValidacao ValidarRegrasDispensa(DetalhesAfastamento det, IEnumerable<RegraAfastamento> reg)
    {
        return ValidarRegrasDispensa((DetalhesDispensaServico)det, reg);
    }

    private static ResultadoValidacao ValidarRegrasLuto(DetalhesAfastamento det, IEnumerable<RegraAfastamento> reg)
    {
        return ValidarRegrasLuto((DetalhesLuto)det, reg);
    }

    
}
public class ResultadoValidacao
{
    public bool Valido { get; private set; }
    public string Mensagem { get; private set; }

    // Construtor privado para forçar o uso dos métodos estáticos abaixo
    private ResultadoValidacao() { }

    // Métodos utilitários para criar o resultado de forma limpa
    public static ResultadoValidacao Sucesso() => new() { Valido = true, Mensagem = string.Empty };
    public static ResultadoValidacao Falha(string mensagem) => new() { Valido = false, Mensagem = mensagem };
}
