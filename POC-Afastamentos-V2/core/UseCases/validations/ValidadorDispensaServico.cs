using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.domain.valueobjects;

namespace POC_Afastamentos_V2.core.UseCases.validations
{
    public class ValidadorDispensaServico : IValidadorAfastamento
    {
        public TipoAfastamento TipoAfastamento => TipoAfastamento.DispensaServico;
        public async Task ValidarAsync(SolicitacaoAfastamento solicitacaoAfastamento)
        {
            if(solicitacaoAfastamento.NumeroDias <= 6)
                throw new Exception("Dispensa de serviço deve ser superior a 6 dias.");
        }
    }
}