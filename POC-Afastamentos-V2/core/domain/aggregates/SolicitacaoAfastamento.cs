using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.domain.valueobjects;

namespace POC_Afastamentos_V2.core.domain.aggregates;

public class SolicitacaoAfastamento
{
    public Guid Id { get; set; }
    public string SolicitanteRe { get; set; }
    public Policial Solicitante { get; set; }
    public string InteressadoRe { get; set; }
    public Policial Interessado { get; set; }
    public string OpmCod { get; set; }
    public Opm Opm { get; set; }
    public DateTime DataPedido { get; set; }
    public DateTime DataInicio { get; set; }
    public int NumeroDias { get; set; } = 0;
    public string Motivo { get; set; }
    public int TipoAfastamentoId { get; set; }
    public Afastamentos TipoAfastamento { get; set; }
    public DetalhesAfastamento DetalhesAfastamento { get; set; }

    public bool ValidarDiasAfastamento()
    {
        if (TipoAfastamentoId == null)
            throw new ArgumentException("Tipo de afastamento não pode ser nulo.");
        if (NumeroDias < DetalhesAfastamento.DiasMinimo || NumeroDias > DetalhesAfastamento.DiasMaximo)
            return false;
        return true;
    }
}
    public enum TipoDoc
    {
        CertidaoNascimento = 1,
        CertidaoCasamento = 2,
        CertidaoObito = 3,
    }

    
