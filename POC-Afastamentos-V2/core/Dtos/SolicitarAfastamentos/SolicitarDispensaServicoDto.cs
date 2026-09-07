namespace POC_Afastamentos_V2.core.Dtos.SolicitarAfastamentos;

public record SolicitarDispensaServicoDto: SolicitarAfastamentoDto
{
    public string NumBolG { get; init; } = default!;

}
