namespace POC_Afastamentos_V2.core.Dtos
{
    public record SolicitarLicPaterGestDto:SolicitarAfastamentoDto
    {
        public string NomeFilho { get; init; } = default!;
        public string urlCertNasc { get; set; }
    }
}
