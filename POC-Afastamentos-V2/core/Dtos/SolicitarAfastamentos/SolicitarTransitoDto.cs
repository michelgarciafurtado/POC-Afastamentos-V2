namespace POC_Afastamentos_V2.core.Dtos.SolicitarAfastamentos
{
    public record SolicitarTransitoDto:SolicitarAfastamentoDto
    {
        public bool Ate150km { get; set; } = false;
        public bool Acima150km { get; set;} = false;
        public string NumBolG { get; init; } = default!;
    }
}
