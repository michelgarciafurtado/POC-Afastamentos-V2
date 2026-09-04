namespace POC_Afastamentos_V2.core.Dtos;

public record SolicitarNupciasDto:SolicitarAfastamentoDto
{
    public string NomeConjuge { get; init; } = default!;
    public string UrlCertCasamento { get; set; } 
}
