namespace POC_Afastamentos_V2.core.UseCases.validations;

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
