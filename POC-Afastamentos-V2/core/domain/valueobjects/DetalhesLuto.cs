namespace POC_Afastamentos_V2.core.domain.valueobjects;

public record DetalhesLuto(string NomeFalecido, GrauParentesco Parentesco, string urlCertObito) : DetalhesAfastamento;

public enum GrauParentesco
{
    Pai,
    Mae,
    Irmão,
    Irmã,
    Conjuge,
    Filhoª,
    Sogra,
    Avó,
    Avô,
}