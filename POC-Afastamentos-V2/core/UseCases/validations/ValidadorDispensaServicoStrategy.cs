using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.domain.valueobjects;
using POC_Afastamentos_V2.core.ports.inbound;

namespace POC_Afastamentos_V2.core.UseCases.validations
{
    public class ValidadorDispensaServicoStrategy : IValidadorAfastamentoStrategy
    {
        public bool PodeValidar(DetalhesAfastamento detalhes)
        {
            throw new NotImplementedException();
        }

        public ResultadoValidacao Validar(DetalhesAfastamento detalhes, IEnumerable<RegraAfastamento> regras)
        {
            throw new NotImplementedException();
        }
    }
}
