namespace POC_Afastamentos_V2.core.Dtos.Opms;

public sealed record FiltroOpmDto(
    string? OpmCod,
    string? NomeOpm,
    int? OpmNivel,
    string? LocalOpm,
    bool? Ativo
);
