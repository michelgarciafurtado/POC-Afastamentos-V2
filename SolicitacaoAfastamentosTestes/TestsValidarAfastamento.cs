using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using POC_Afastamentos_V2.core.UseCases.validations;
using POC_Afastamentos_V2.core.UseCases.validations.strategies;
using POC_Afastamentos_V2.core.ports.outbound;
using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.domain.valueobjects;

namespace SolicitacaoAfastamentosTestes
{
    [TestFixture]
    public class TestsValidarAfastamento
    {
        private class FakeRegrasRepository : IRegrasAfastamentoRepository
        {
            private readonly IEnumerable<RegraAfastamento> _regras;

            public FakeRegrasRepository(IEnumerable<RegraAfastamento> regras)
            {
                _regras = regras;
            }

            public Task<IEnumerable<RegraAfastamento>> ObterRegrasPorIdAsync(int tipoAfastamentoId)
            {
                return Task.FromResult(_regras);
            }
        }

        [Test]
        public async Task Luto_Com_8_dias_retorna_sucesso()
        {
            var detalhes = new DetalhesLuto("Joao", GrauParentesco.Pai, "url");
            var solicitacao = new SolicitacaoAfastamento
            {
                TipoAfastamentoId = 1,
                DetalhesAfastamento = detalhes,
                NumeroDias = 8
            };

            var regras = new List<RegraAfastamento>
            {
                new RegraAfastamento { TipoRegra = "Parentesco", Valor = detalhes.Parentesco.ToString(), qtd = 8 }
            };

            var repo = new FakeRegrasRepository(regras);
            var strategies = new List<IValidadorAfastamentoStrategy> { new ValidadorLutoStrategy() };

            var usecase = new ValidadorAfastamentoUseCase(repo, strategies);

            var resultado = await usecase.ValidarAsync(solicitacao);

            Assert.That(resultado.Valido, NUnit.Framework.Is.True, "Resultado esperado como válido para 8 dias de luto");
        }

        [Test]
        public async Task Luto_Com_2_dias_retorna_sucesso()
        {
            var detalhes = new DetalhesLuto("Maria", GrauParentesco.Mae, "url");
            var solicitacao = new SolicitacaoAfastamento
            {
                TipoAfastamentoId = 1,
                DetalhesAfastamento = detalhes,
                NumeroDias = 2
            };

            var regras = new List<RegraAfastamento>
            {
                new RegraAfastamento { TipoRegra = "Parentesco", Valor = detalhes.Parentesco.ToString(), qtd = 2 }
            };

            var repo = new FakeRegrasRepository(regras);
            var strategies = new List<IValidadorAfastamentoStrategy> { new ValidadorLutoStrategy() };

            var usecase = new ValidadorAfastamentoUseCase(repo, strategies);

            var resultado = await usecase.ValidarAsync(solicitacao);

            Assert.That(resultado.Valido, NUnit.Framework.Is.True, "Resultado esperado como válido para 2 dias de luto");
        }

        [Test]
        public async Task Luto_Com_periodo_errado_deve_falhar()
        {
            var detalhes = new DetalhesLuto("Ana", GrauParentesco.Irmão, "url");
            var solicitacao = new SolicitacaoAfastamento
            {
                TipoAfastamentoId = 1,
                DetalhesAfastamento = detalhes,
                NumeroDias = 2
            };

            var regras = new List<RegraAfastamento>
            {
                // regra indica 8 dias para esse parentesco, mas solicitacao pede 2 -> deve falhar
                new RegraAfastamento { TipoRegra = "Parentesco", Valor = detalhes.Parentesco.ToString(), qtd = 8 }
            };

            var repo = new FakeRegrasRepository(regras);
            var strategies = new List<IValidadorAfastamentoStrategy> { new ValidadorLutoStrategy() };

            var usecase = new ValidadorAfastamentoUseCase(repo, strategies);

            var resultado = await usecase.ValidarAsync(solicitacao);

            Assert.That(resultado.Valido, NUnit.Framework.Is.False, "Resultado esperado como inválido quando o número de dias não bate com a regra");
            Assert.That(resultado.Mensagem, NUnit.Framework.Does.Contain("Número de dias incorreto"));
        }
    }
}
