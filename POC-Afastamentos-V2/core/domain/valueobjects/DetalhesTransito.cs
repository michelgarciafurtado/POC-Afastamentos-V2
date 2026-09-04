namespace POC_Afastamentos_V2.core.domain.valueobjects
{
    public record DetalhesTransito(bool ate150Km, bool acima150Km, string NumBolGSobrestamento) : DetalhesAfastamento
    {
    }
}
