namespace POC_Afastamentos_V2.core.Dtos;

public record SolicitarLicencaPremioDto:SolicitarAfastamentoDto
{
    public string NumBolG { get; init; } = default!;
}
