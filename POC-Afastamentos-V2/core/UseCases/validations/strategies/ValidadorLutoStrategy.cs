using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.domain.valueobjects;

namespace POC_Afastamentos_V2.core.UseCases.validations.strategies
{
    public class ValidadorLutoStrategy : IValidadorAfastamentoStrategy
    {
        public bool PodeValidar(DetalhesAfastamento detalhes)
        {
            return detalhes is DetalhesLuto;
        }

        public ResultadoValidacao Validar( SolicitacaoAfastamento solicitacao, IEnumerable<RegraAfastamento> regras)
        {
            var detalhes = (DetalhesLuto)solicitacao.DetalhesAfastamento;

            var regra = regras.FirstOrDefault(r => r.TipoRegra == "Parentesco" &&
                                 r.Valor == detalhes.Parentesco.ToString());
            if (regra.qtd == solicitacao.NumeroDias)
                return ResultadoValidacao.Sucesso();

            return ResultadoValidacao.Falha($"Número de dias incorreto para o parentesco {detalhes.Parentesco}");
            
        }
    }
}
