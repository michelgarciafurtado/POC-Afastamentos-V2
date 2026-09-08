using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.Dtos.Afastamentos;
using System.Linq.Expressions;

namespace POC_Afastamentos_V2.core.ports.inbound;

public interface IAfastamentoUseCase
{
    Task<int> CriarAsync(NovoAfastamentoDto dto);
    Task<IEnumerable<AfastamentoDto>> ListarAsync(Expression<Func<Afastamentos, bool>> predicate);
    Task<AfastamentoDto> ObterAsync(Expression<Func<Afastamentos, bool>> predicate);
    Task<bool> AlterarStatus(AlterarStatusAfastamentoDto dto);
    Task<AfastamentoDto> AtualizarAsync(AlterarAfastamentoDto dto);
    Task<IEnumerable<AfastamentoDto>> ObterTodosAsync();
}
