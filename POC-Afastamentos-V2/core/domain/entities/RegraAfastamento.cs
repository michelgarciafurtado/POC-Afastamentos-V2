namespace POC_Afastamentos_V2.core.domain.entities;
public class RegraAfastamento
{
    public int Id { get; set; }
    public int TipoAfastamentoId { get; set; }
    public Afastamentos TipoAfastamento { get; set; }
    public string TipoRegra { get; set; }
    public string Valor { get; set; }
    public string Frequencia { get; set; }
    public int DiasMinimo { get; set; }
    public int DiasMaximo { get; set; }
    public int qtd { get; set; }
}