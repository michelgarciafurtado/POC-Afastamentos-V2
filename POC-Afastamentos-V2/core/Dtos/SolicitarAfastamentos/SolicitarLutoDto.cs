using POC_Afastamentos_V2.core.domain.valueobjects;

namespace POC_Afastamentos_V2.core.Dtos.SolicitarAfastamentos
{
    public record SolicitarLutoDto:SolicitarAfastamentoDto
    {
        public string NomeParente { get; init; } = default!;
        public GrauParentesco GrauParentesco { get; init; } = default!;
        public string urlCertObito { get; set; }
    }
}
