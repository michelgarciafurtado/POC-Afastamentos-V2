namespace POC_Afastamentos_V2.core.Dtos.SolicitarAfastamentos
{
    public record SolicitarLicencaPremioSobrestadaDto:SolicitarAfastamentoDto
    {
        public string NumBolInt { get; init; } = default!;
        public int QtdDias { get; init; } = default!;
    }
}
