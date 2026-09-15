using POC_Afastamentos_V2.core.domain.aggregates;
using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.domain.valueobjects;

namespace SolicitacaoAfastamentosTestes
{
    public class Tests
    {
        Afastamentos Luto  = new Afastamentos(1, "Luto");
        Afastamentos DS = new Afastamentos(2, "Dispensa do Serviço");
        Opm DP = new Opm("204000000", "Diretoria de Pessoal");
        Policial solicitante ;
        Policial interessado ;
        PostoGraduacao PSgtPM = new PostoGraduacao(5, "1 Sgt PM", "Primeiro Sargento Policial Militar", 13);
        PostoGraduacao SdPM = new PostoGraduacao(1, "Sd PM", "Soldado Policial Militar", 17);
        RegraAfastamento regra1Luto, regra2Luto, regra1DS;
        [SetUp]
        public void Setup()
        {
            solicitante = new Policial("987654", 2, "Carlos Augusto ", "328.844.548-44", PSgtPM.PosCod, PSgtPM, "1234", DP);
            interessado = new Policial("123456", 1, "João da Silva", "123.456.789-00", SdPM.PosCod, SdPM, "1234", DP);
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
        }

        [Test]
        public void TestSolicitarDS()
        {
            SolicitacaoAfastamento SolLuto = new SolicitacaoAfastamento();
            SolLuto.Id = Guid.NewGuid();
            SolLuto.SolicitanteRe = solicitante.ReDg;
            SolLuto.InteressadoRe = interessado.ReDg;
            SolLuto.OpmCod = DP.OpmCod;
            SolLuto.DataPedido = DateTime.Now;
            SolLuto.DataInicio = DateTime.Now;
            SolLuto.TipoAfastamentoId = Luto.Id;
            SolLuto.TipoAfastamento = Luto;
            SolLuto.Motivo = "Falecimento de familiar";
            SolLuto.DetalhesAfastamento = new DetalhesLuto("Antonio da Silva",GrauParentesco.Pai,"urlCertObito");
            Assert.Pass();
        }
    }
}
