namespace POC_Afastamentos_V2.core.Dtos.SolicitarAfastamentos;

public record SolicitarFeriasSobrestadasDto:SolicitarAfastamentoDto
{
    public string NumBolInt { get; init; } = default!;
    public int QtdDias { get; init; } = default!;
    public string PafAno { get; init; } = default!;

}
