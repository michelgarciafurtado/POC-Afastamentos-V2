namespace POC_Afastamentos_V2.core.Dtos.PostoGraduacao
{
    public sealed record AlterarPostoGraduacaoDto(
        int PosCod,
        string? Sigla,
        string? Descricao,
        int? Nivel
    );
}
