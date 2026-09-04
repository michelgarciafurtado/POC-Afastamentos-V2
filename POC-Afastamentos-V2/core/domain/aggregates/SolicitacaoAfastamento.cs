using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.domain.valueobjects;

namespace POC_Afastamentos_V2.core.domain.aggregates
{
    public class SolicitacaoAfastamento
    {
        public Guid Id { get; set; }
        public string PolicialRe { get; set; }
        public Policial Policial { get; set; }
        public string OpmCod { get; set; }
        public Opm Opm { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataInicio { get; set; }
        public int NumeroDias { get; set; } = 0;
        public string Motivo { get; set; }
        public int AfastamentoId { get; set; }
        public Afastamentos TipoAfastamento { get; set; }
        public DetalhesAfastamento DetalhesAfastamento { get; set; }
    }
}
