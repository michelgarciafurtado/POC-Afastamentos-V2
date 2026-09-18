using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.domain.valueobjects;
using POC_Afastamentos_V2.core.ports.inbound;

namespace POC_Afastamentos_V2.core.UseCases.validations
{
    public class ValidadorDispensaServicoStrategy : IValidadorAfastamentoStrategy
    {
        public bool PodeValidar(DetalhesAfastamento detalhes)
        {
            return detalhes is DetalhesDispensaServico;
        }

        public ResultadoValidacao Validar(DetalhesAfastamento detalhes, IEnumerable<RegraAfastamento> regras)
        {
            var dispensa = (DetalhesDispensaServico)detalhes;

            // regras específicas de DS

            return ResultadoValidacao.Sucesso();
        }
    }
}
