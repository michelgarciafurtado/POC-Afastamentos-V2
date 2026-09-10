namespace POC_Afastamentos_V2.core.Dtos.PostoGraduacao;

public sealed record PostoGraduacaoDto(
    int PosCod,
    string Sigla,
    string Descricao,
    int Nivel,
    bool Ativo
);
