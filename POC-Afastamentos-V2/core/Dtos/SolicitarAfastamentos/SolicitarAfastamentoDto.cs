namespace POC_Afastamentos_V2.core.Dtos.SolicitarAfastamentos;

public abstract record SolicitarAfastamentoDto
{
    public string Re { get; init; } = default!;
    public string Dc { get; init; } = default!;
    public int PosCodigo { get; init; } = default!;
    public string OpmCod { get; init; } = default!;
    public DateTime DataInicial { get; init; } = default!;
    public int NumDias { get; init; } = default!;
    public string Motivo { get; init; } = default!;
}
