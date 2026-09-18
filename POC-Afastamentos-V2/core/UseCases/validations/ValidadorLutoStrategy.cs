using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.domain.valueobjects;
using POC_Afastamentos_V2.core.ports.inbound;

namespace POC_Afastamentos_V2.core.UseCases.validations
{
    public class ValidadorLutoStrategy : IValidadorAfastamentoStrategy
    {
        public bool PodeValidar(DetalhesAfastamento detalhes)
        {
            return detalhes is DetalhesLuto;
        }

        public ResultadoValidacao Validar(
            DetalhesAfastamento detalhes,
            IEnumerable<RegraAfastamento> regras)
        {
            var luto = (DetalhesLuto)detalhes;

            // regras específicas de luto

            return ResultadoValidacao.Sucesso();
        }
    }
}
