namespace POC_Afastamentos_V2.core.Dtos.Regras
{
    public record RegraDto(int id, int tipoAfastamentoId, string descricaoAfastamento, string tipoRegra, string valor, string frequencia, int diasMinimo, int diasMaximo, int qtd);
}
