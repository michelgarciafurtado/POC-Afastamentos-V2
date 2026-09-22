using System.ComponentModel.DataAnnotations;

namespace POC_Afastamentos_V2.core.Dtos.Regras
{
    public class AlterarRegraDto
    {
        [Required(ErrorMessage ="O Id da regra é obirgatório")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Id do afastamento deve ser informado")]
        public int TipoAfastamentoId { get; set; }
        [Required(ErrorMessage ="O tipo da regra deve ser informado")]
        [StringLength(150)]
        public string TipoRegra { get; set; }
        [Required(ErrorMessage = "O valor da regra deve ser informado")]
        [StringLength(150)]
        public string Valor { get; set; }
        [Required(ErrorMessage = "A frequencia da regra deve ser informada")]
        [StringLength(150)]
        public string Frequencia { get; set; }
        public int? DiasMinimo { get; set; }
        public int? DiasMaximo { get; set; }
        public int? qtd { get; set; }
    }
}
