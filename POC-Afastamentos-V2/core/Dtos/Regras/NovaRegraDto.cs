using System.ComponentModel.DataAnnotations;

namespace POC_Afastamentos_V2.core.Dtos.Regras
{
    public class NovaRegraDto
    {
        [Required(ErrorMessage = "Id do afastamento deve ser informado")]
        public int TipoAfastamentoId { get; set; }
        [Required(ErrorMessage = "O tipo da regra deve ser informado")]
        [StringLength(150)]
        public required string TipoRegra { get; set; }
        [Required(ErrorMessage = "O valor da regra deve ser informado")]
        [StringLength(150)]
        public required string Valor { get; set; }
        [Required(ErrorMessage = "A frequencia da regra deve ser informada")]
        [StringLength(150)]
        public required string Frequencia { get; set; }
        public int? DiasMinimo { get; set; } = null;
        public int? DiasMaximo { get; set; } = null;
        public int? Qtd { get; set; } = null;
    }
}
