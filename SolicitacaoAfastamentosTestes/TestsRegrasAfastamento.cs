using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using POC_Afastamentos_V2.adapters.drivin.Controllers;
using POC_Afastamentos_V2.core.Dtos.Regras;
using POC_Afastamentos_V2.core.ports.inbound;
using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.domain.valueobjects;

namespace SolicitacaoAfastamentosTestes
{
    public class TestsRegrasAfastamento
    {
        Afastamentos Luto  = new Afastamentos(1, "Luto");
        Afastamentos DS = new Afastamentos(2, "Dispensa do Serviço");
        RegraAfastamento regra1Luto, regra2Luto, regra1DS;
        List<RegraAfastamento> Regras;

        [SetUp]
        public void Setup()
        {
            Regras = new List<RegraAfastamento>();
            regra1Luto = new RegraAfastamento()
            {
                Id = 1,
                TipoAfastamentoId = 1,
                TipoAfastamento = Luto,
                TipoRegra = "Parentesco",
                Valor = GrauParentesco.Pai.ToString(),
                DiasMinimo = 8,
                DiasMaximo = 8,
                qtd = 8
            };
            Regras.Add(regra1Luto);
            regra2Luto = new RegraAfastamento()
            {
                Id = 2,
                TipoAfastamentoId = 1,
                TipoAfastamento = Luto,
                TipoRegra = "Parentesco",
                Valor = GrauParentesco.Avô.ToString(),
                DiasMinimo = 2,
                DiasMaximo = 2,
                qtd = 2
            };
            Regras.Add(regra2Luto);
            regra1DS = new RegraAfastamento()
            {
                Id = 3,
                TipoAfastamentoId = DS.Id,
                TipoAfastamento = DS,
                TipoRegra = "Limite",
                Frequencia = "Anual",
                DiasMinimo = 1,
                DiasMaximo = 6,
                qtd = 6
            };
            Regras.Add(regra1DS);
        }

        private static RegraDto ToDto(RegraAfastamento r)
        {
            return new RegraDto(r.Id, r.TipoAfastamentoId, r.TipoAfastamento?.Nome ?? string.Empty, r.TipoRegra, r.Valor, r.Frequencia, r.DiasMinimo, r.DiasMaximo, r.qtd);
        }
        class FakeRegraUseCase : IRegraAfastamentoUseCase
        {
            public bool ThrowOnCriar { get; set; }
            public bool ThrowOnListar { get; set; }
            public bool ThrowOnObter { get; set; }
            public bool ThrowOnAtualizar { get; set; }

            public int CriarReturnId { get; set; } = 1;
            public IEnumerable<RegraDto> ListarReturn { get; set; } = new List<RegraDto>();
            public RegraDto ObterReturn { get; set; }
            public RegraDto AtualizarReturn { get; set; }

            public Task<int> CriarAsync(NovaRegraDto dto)
            {
                if (ThrowOnCriar) throw new Exception("erro criar");
                return Task.FromResult(CriarReturnId);
            }

            public Task<IEnumerable<RegraDto>> ListarAsync(FiltroRegraDto regraDto)
            {
                if (ThrowOnListar) throw new Exception("erro listar");
                return Task.FromResult(ListarReturn);
            }

            public Task<RegraDto> ObterAsync(int RegraId)
            {
                if (ThrowOnObter) throw new Exception("erro obter");
                return Task.FromResult(ObterReturn);
            }

            public Task<bool> AlterarStatus(AlterarRegraDto dto)
            {
                return Task.FromResult(true);
            }

            public Task<RegraDto> AtualizarAsync(AlterarRegraDto dto)
            {
                if (ThrowOnAtualizar) throw new Exception("erro atualizar");
                return Task.FromResult(AtualizarReturn);
            }

            public Task<IEnumerable<RegraDto>> ObterTodosAsync()
            {
                if (ThrowOnListar) throw new Exception("erro listar todos");
                return Task.FromResult(ListarReturn);
            }
        }

        [Test]
        public async Task CriarRegra_Sucesso_DeveRetornarCreated()
        {
            var fake = new FakeRegraUseCase { CriarReturnId = 5 };
            var controller = new RegraAfastamentoController(fake);
            var dto = new NovaRegraDto { TipoAfastamentoId = 1, TipoRegra = "T", Valor = "V", Frequencia = "F" };

            var result = await controller.CriarRegra(dto);

            Assert.That(result, Is.InstanceOf<CreatedAtActionResult>());
            var created = (CreatedAtActionResult)result;
            Assert.That(created.RouteValues?[(string)"id"], Is.EqualTo(5));
            Assert.That(created.Value, Is.EqualTo(dto));
        }

        [Test]
        public void CriarRegra_Falha_DeveLancarExcecao()
        {
            var fake = new FakeRegraUseCase { ThrowOnCriar = true };
            var controller = new RegraAfastamentoController(fake);
            var dto = new NovaRegraDto { TipoAfastamentoId = 1, TipoRegra = "T", Valor = "V", Frequencia = "F" };

            Assert.ThrowsAsync<Exception>(async () => await controller.CriarRegra(dto));
        }

        [Test]
        public async Task AtualizarRegra_Sucesso_DeveRetornarOkComDto()
        {
            var regra = ToDto(regra1Luto);
            var fake = new FakeRegraUseCase { AtualizarReturn = regra };
            var controller = new RegraAfastamentoController(fake);
            var dto = new AlterarRegraDto { Id = 10, TipoAfastamentoId = 1, TipoRegra = "T", Valor = "V", Frequencia = "F" };

            var result = await controller.AtualizarRegra(dto);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var ok = (OkObjectResult)result;
            Assert.That(ok.Value, Is.EqualTo(regra));
        }

        [Test]
        public async Task AtualizarRegra_Falha_DeveRetornarNotFound()
        {
            var fake = new FakeRegraUseCase { AtualizarReturn = null };
            var controller = new RegraAfastamentoController(fake);
            var dto = new AlterarRegraDto { Id = 100, TipoAfastamentoId = 1, TipoRegra = "T", Valor = "V", Frequencia = "F" };

            var result = await controller.AtualizarRegra(dto);

            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task ObterAsync_Sucesso_DeveRetornarOkComDto()
        {
            var regra = ToDto(regra2Luto);
            var fake = new FakeRegraUseCase { ObterReturn = regra };
            var controller = new RegraAfastamentoController(fake);

            var result = await controller.ObterAsync(7);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var ok = (OkObjectResult)result;
            Assert.That(ok.Value, Is.EqualTo(regra));
        }

        [Test]
        public async Task ObterAsync_Falha_DeveRetornarNotFound()
        {
            var fake = new FakeRegraUseCase { ObterReturn = null };
            var controller = new RegraAfastamentoController(fake);

            var result = await controller.ObterAsync(999);

            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task FiltrarRegras_Sucesso_ComFiltro_DeveRetornarRegras()
        {
            var lista = new List<RegraDto> { ToDto(regra1Luto), ToDto(regra2Luto) };
            var fake = new FakeRegraUseCase { ListarReturn = lista };
            var controller = new RegraAfastamentoController(fake);
            var filtro = new FiltroRegraDto(1, "T");

            var result = await controller.FiltrarRegras(filtro);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var ok = (OkObjectResult)result;
            // value is anonymous object { Regras = resultados }
            var value = ok.Value as dynamic;
            Assert.That(value, Is.Not.Null);
            Assert.That(value.Regras, Is.Not.Null);
        }

        [Test]
        public async Task FiltrarRegras_Sucesso_FiltroNulo_DeveRetornarTodos()
        {
            var lista = new List<RegraDto> { ToDto(regra1DS) };
            var fake = new FakeRegraUseCase { ListarReturn = lista };
            var controller = new RegraAfastamentoController(fake);

            var result = await controller.FiltrarRegras(null);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var ok = (OkObjectResult)result;
            var value = ok.Value as dynamic;
            Assert.That(value, Is.Not.Null);
            Assert.That(value.Regras, Is.Not.Null);
        }

        [Test]
        public void FiltrarRegras_Falha_DeveLancarExcecao()
        {
            var fake = new FakeRegraUseCase { ThrowOnListar = true };
            var controller = new RegraAfastamentoController(fake);
            var filtro = new FiltroRegraDto(1, "T");

            Assert.ThrowsAsync<Exception>(async () => await controller.FiltrarRegras(filtro));
        }
    }
}
