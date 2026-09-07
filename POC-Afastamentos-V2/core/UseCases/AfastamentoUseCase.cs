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

        public async Task<int> CriarAsync(NovoAfastamentoDto dto)
        {
            Afastamentos novoAfastamento = new Afastamentos(dto.id,dto.Nome);
            await _afastamentoRepository.AdicionarAsync(novoAfastamento);
            int sucesso =  await _afastamentoRepository.CommitAsync();
            if (sucesso == 0)
                return new Exception("Não foi possível criar o afastamento.").HResult;
            return sucesso;
        }

        public async Task<IEnumerable<AfastamentoDto>> ListarAsync(Expression<Func<Afastamentos, bool>> predicate)
        {
            var afastamentos = await _afastamentoRepository.BuscarAsync(predicate);
            return afastamentos.Select(a => new AfastamentoDto(a.Id, a.Nome, a.Ativo));
        }

        public Task<AfastamentoDto> ObterAsync(Expression<Func<Afastamentos, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
