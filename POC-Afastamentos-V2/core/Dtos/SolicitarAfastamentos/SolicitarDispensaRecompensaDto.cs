namespace POC_Afastamentos_V2.core.Dtos.SolicitarAfastamentos;

public record SolicitarDispensaRecompensaDto:SolicitarAfastamentoDto
{
    string NumBolInt { get; init; } = default!;
}
