using Microsoft.EntityFrameworkCore;
using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.Dtos.PostoGraduacao;
using POC_Afastamentos_V2.core.ports.outbound;

namespace POC_Afastamentos_V2.core.ports.inbound
{
    public class PostoGraduacaoUseCase : IPostoGraduacaoUseCase
    {
        private readonly IGenericRepository<PostoGraduacao> _genericRepository;

        public PostoGraduacaoUseCase(IGenericRepository<PostoGraduacao> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<bool> AlterarStatusAsync(int postoGraduacaoCod, bool ativo)
        {
            var postoGraduacao = _genericRepository.BuscarAsync(p => p.PosCod == postoGraduacaoCod).Result.FirstOrDefault();
           if (postoGraduacao == null)
                throw new Exception($"Posto de Graduação com código {postoGraduacaoCod} não encontrado.");
            
           
            if (ativo == true)
                    postoGraduacao.AtivarPosto();
                else
                    postoGraduacao.InativarPosto();
            
            _genericRepository.Atualizar(postoGraduacao);
            await _genericRepository.CommitAsync();

            return true;
        }

        public async Task<PostoGraduacaoDto> AtualizarAsync(AlterarPostoGraduacaoDto dto)
        {
            var postoGraduacao = _genericRepository.BuscarAsync(p => p.PosCod == dto.PosCod).Result.FirstOrDefault();
            if (postoGraduacao == null)
                throw new Exception($"Posto de Graduação com código {dto.PosCod} não encontrado.");
            postoGraduacao = new PostoGraduacao
            (
                dto.PosCod,
                dto.Sigla ?? postoGraduacao.Sigla,
                dto.Descricao ?? postoGraduacao.Descricao,
                dto.Nivel ?? postoGraduacao.Nivel
            );

            _genericRepository.Atualizar(postoGraduacao);
            var sucesso = await _genericRepository.CommitAsync();
            if(sucesso == 0)
                throw new Exception($"Erro ao atualizar o Posto de Graduação com código {dto.PosCod}.");
            
            return new PostoGraduacaoDto
            (
                postoGraduacao.PosCod,
                postoGraduacao.Sigla,
                postoGraduacao.Descricao,
                postoGraduacao.Nivel,
                postoGraduacao.Ativo
            );
        }

        public Task<int> CriarAsync(NovoPostoGraduacaoDto dto)
        {
           PostoGraduacao postoGraduacao = new PostoGraduacao(dto.PosCod, dto.Sigla, dto.Descricao, dto.Nivel);
            _genericRepository.AdicionarAsync(postoGraduacao);
            return _genericRepository.CommitAsync();
        }

        public async Task<bool> ExcluirAsync(int postoGraduacaoCod)
        {
            var postoGraduacao = _genericRepository.BuscarAsync(p => p.PosCod == postoGraduacaoCod).Result.FirstOrDefault();
            if (postoGraduacao == null)
                throw new Exception($"Posto de Graduação com código {postoGraduacaoCod} não encontrado.");
            _genericRepository.Remover(postoGraduacao);
            var success = await _genericRepository.CommitAsync();
            return success > 0;
        }

        public async Task<IEnumerable<PostoGraduacaoDto>> ListarAsync(FiltroPostoGraduacaoDto dto)
        {
            IQueryable<PostoGraduacao> query = _genericRepository.Queryable();

            if(string.IsNullOrEmpty(dto.Sigla) == false)
                query = query.Where(p => p.Sigla.Contains(dto.Sigla));
            if(string.IsNullOrEmpty(dto.Descricao) == false)
                query = query.Where(p => p.Descricao.Contains(dto.Descricao));

            var result = await query.ToListAsync();
            return result.Select(p => new PostoGraduacaoDto(
                p.PosCod,
                p.Sigla,
                p.Descricao,
                p.Nivel,
                p.Ativo
            ));
        }

        public async Task<PostoGraduacaoDto> ObterAsync(int postoGraduacaoCod)
        {
            var postoGraduacao = _genericRepository.BuscarAsync(p => p.PosCod == postoGraduacaoCod).Result.FirstOrDefault();
            if(postoGraduacao == null)
                throw new Exception($"Posto de Graduação com código {postoGraduacaoCod} não encontrado.");

            return new PostoGraduacaoDto(
                postoGraduacao.PosCod,
                postoGraduacao.Sigla,
                postoGraduacao.Descricao,
                postoGraduacao.Nivel,
                postoGraduacao.Ativo
            );
        }

        public async Task<IEnumerable<PostoGraduacaoDto>> ObterTodosAsync()
        {
            var result = await _genericRepository.ObterTodosAsync();
            return result.Select(p => new PostoGraduacaoDto(
                p.PosCod,
                p.Sigla,
                p.Descricao,
                p.Nivel,
                p.Ativo
            ));
        }
    }
}
