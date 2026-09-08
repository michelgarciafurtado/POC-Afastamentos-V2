using POC_Afastamentos_V2.core.domain.entities;
using POC_Afastamentos_V2.core.Dtos.Opms;
using POC_Afastamentos_V2.core.ports.inbound;
using POC_Afastamentos_V2.core.ports.outbound;
using System.Linq.Expressions;

namespace POC_Afastamentos_V2.core.UseCases
{
    public class OpmUseCase : IOpmUseCase
    {
        private readonly IGenericRepository<Opm> _opmRepository;

        public OpmUseCase(IGenericRepository<Opm> opmRepository)
        {
            _opmRepository = opmRepository;
        }

        public async Task<bool> AlterarStatus(AlterarStatusOpmDto dto)
        {
            var Opm = await _opmRepository.BuscarAsync(o => o.OpmCod == dto.OpmCod);
            if (Opm == null)
                return false;

            Opm.Status = dto.Ativo;
            await _opmRepository.Atualizar(Opm);
            return true;
        }

        public Task<OpmDto> AtualizarAsync(AlterarOpmDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<int> CriarAsync(NovaOpmDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OpmDto>> ListarAsync(Expression<Func<Opm, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<OpmDto> ObterAsync(Expression<Func<Opm, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OpmDto>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
