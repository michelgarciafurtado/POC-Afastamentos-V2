using Microsoft.AspNetCore.Http.HttpResults;
using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.Dtos.Afastamentos;
using POC_Afastamentos_V2.core.ports.inbound;
using POC_Afastamentos_V2.core.ports.outbound;
using System.Linq.Expressions;

namespace POC_Afastamentos_V2.core.UseCases
{
    public class AfastamentoUseCase : IAfastamentoUseCase
    {
        private readonly IGenericRepository<Afastamentos> _afastamentoRepository;

        public AfastamentoUseCase(IGenericRepository<Afastamentos> afastamentoRepository)
        {
            _afastamentoRepository = afastamentoRepository;
        }

        public async Task<bool> AlterarStatus(AlterarStatusAfastamentoDto dto)
        {
            var afastamento = _afastamentoRepository.BuscarAsync(a => a.Id == dto.id).Result.FirstOrDefault();
            if (afastamento == null)
                throw new InvalidOperationException("Afastamento não encontrado");

            int sucesso = await _afastamentoRepository.CommitAsync();
            return sucesso > 0;
        }

        public async Task<AfastamentoDto> AtualizarAsync(AlterarAfastamentoDto dto)
        {
           var afastamento = _afastamentoRepository.BuscarAsync(a => a.Id == dto.id).Result.FirstOrDefault();
            if (afastamento == null)
                throw new InvalidOperationException("Afastamento não encontrado");
            afastamento.AlterarNome(dto.nome);
            _afastamentoRepository.Atualizar(afastamento);
            var sucesso = await _afastamentoRepository.CommitAsync();
            if (sucesso > 0)
                return new AfastamentoDto(afastamento.Id, afastamento.Nome, afastamento.Ativo);
            else
                throw new InvalidOperationException("Não foi possível atualizar o afastamento");
        }

        public async Task<int> CriarAsync(NovoAfastamentoDto dto)
        {
            Afastamentos novoAfastamento = new Afastamentos(dto.Nome);
            await _afastamentoRepository.AdicionarAsync(novoAfastamento);
           return  await _afastamentoRepository.CommitAsync();
           
        }

        public async Task<IEnumerable<AfastamentoDto>> ListarAsync(Expression<Func<Afastamentos, bool>> predicate)
        {
            var afastamentos = await _afastamentoRepository.BuscarAsync(predicate);
            return afastamentos.Select(a => new AfastamentoDto(a.Id, a.Nome, a.Ativo));
        }

        public async Task<AfastamentoDto> ObterAsync(Expression<Func<Afastamentos, bool>> predicate)
        {
            IEnumerable<Afastamentos> listAfast = await _afastamentoRepository.BuscarAsync(predicate);
            var afastamento = listAfast.FirstOrDefault();
            if (afastamento == null)
                throw new InvalidOperationException("Afastamento não encontrado");
            return new AfastamentoDto(afastamento.Id, afastamento.Nome, afastamento.Ativo);
        }
        public async Task<IEnumerable<AfastamentoDto>> ObterTodosAsync()
        {
            IEnumerable<Afastamentos> listAfast = await _afastamentoRepository.BuscarAsync(null);
          
            if (listAfast == null)
                throw new InvalidOperationException("Falha em recuperar a lista de afastamentos");
            IEnumerable<AfastamentoDto> afastamentosDtos = listAfast.Select(a => new AfastamentoDto
            (
                a.Id,
                a.Nome,
                a.Ativo
            ));
            return afastamentosDtos;
        }
    }
}
