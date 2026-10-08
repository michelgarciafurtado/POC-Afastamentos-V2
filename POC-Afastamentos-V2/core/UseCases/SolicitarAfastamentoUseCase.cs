using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.Dtos.Afastamentos;
using POC_Afastamentos_V2.core.Dtos.SolicitarAfastamentos;
using POC_Afastamentos_V2.core.domain.valueobjects;
using POC_Afastamentos_V2.core.ports.inbound;
using POC_Afastamentos_V2.core.ports.outbound;
using POC_Afastamentos_V2.core.domain.aggregates;

namespace POC_Afastamentos_V2.core.UseCases
{
    public class SolicitarAfastamentoUseCase : ISolicitarAfastamentoUseCase
    {
        private readonly ISolicitarAfastamentoRepository _repository;

        public SolicitarAfastamentoUseCase(ISolicitarAfastamentoRepository repository)
        {
            _repository = repository;
        }

        public Task<NovoAfastamentoDto> CriarAfastamento(SolicitarAfastamentoDto dto)
        {
            // manter compatibilidade mínima: não implementado
            throw new NotImplementedException();
        }

        public async Task<int> CriarAsync(SolicitarAfastamentoDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var solicitacao = new SolicitacaoAfastamento
            {
                Id = Guid.NewGuid(),
                SolicitanteRe = dto.Re,
                InteressadoRe = dto.Dc,
                OpmCod = dto.OpmCod,
                DataPedido = DateTime.UtcNow,
                DataInicio = dto.DataInicial,
                NumeroDias = dto.NumDias,
                Motivo = dto.Motivo,
                TipoAfastamentoId = 0
            };

            // mapear DetalhesAfastamento conforme o tipo concreto do DTO
            switch (dto)
            {
                case SolicitarLutoDto luto:
                    solicitacao.DetalhesAfastamento = new DetalhesLuto(luto.NomeParente, luto.GrauParentesco, luto.urlCertObito);
                    break;
                case SolicitarTransitoDto transito:
                    solicitacao.DetalhesAfastamento = new DetalhesTransito(transito.Ate150km, transito.Acima150km, transito.NumBolG);
                    break;
                case SolicitarDispensaRecompensaDto dr:
                    // propriedade pode estar sem modificador; usar nome conhecido
                    solicitacao.DetalhesAfastamento = new DetalhesDispensaRecompensa((dr as dynamic).NumBolInt);
                    break;
                case SolicitarDispensaServicoDto ds:
                    // Não há qtd no DTO, usar NumBolG convertido se possível, senão 0
                    int qtd = 0;
                    if (int.TryParse((ds as dynamic).NumBolG, out var parsed)) qtd = parsed;
                    solicitacao.DetalhesAfastamento = new DetalhesDispensaServico(ds);
                    break;
                case SolicitarFeriasSobrestadasDto fs:
                    solicitacao.DetalhesAfastamento = new DetalhesFeriasSobrestadas(fs.NumBolInt, fs.QtdDias, fs.PafAno);
                    break;
                case SolicitarLicencaPremioDto lp:
                    solicitacao.DetalhesAfastamento = new DetalhesLicencaPremio(lp.NumBolG);
                    break;
                case SolicitarLicencaPremioSobrestadaDto lps:
                    solicitacao.DetalhesAfastamento = new DetalhesLicencaPremioSobrestada(lps.NumBolInt, lps.QtdDias);
                    break;
                case SolicitarLicPaterGestDto lg:
                    solicitacao.DetalhesAfastamento = new DetalhesLicPaterGest(lg.NomeFilho, lg.urlCertNasc);
                    break;
                case SolicitarNupciasDto n:
                    solicitacao.DetalhesAfastamento = new DetalhesNupcias(n.NomeConjuge, n.UrlCertCasamento);
                    break;
                default:
                    solicitacao.DetalhesAfastamento = null;
                    break;
            }

            await _repository.AdicionarAsync(solicitacao);
            var sucesso = await _repository.CommitAsync();
            return sucesso;
        }
    }
}
